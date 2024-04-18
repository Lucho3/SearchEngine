using MaterialDesignThemes.Wpf;
using SearchEngine.Database;
using SearchEngine.Database.Models;
using SearchEngine.Database.Reositories;
using SearchEngine.Views;
using SearchEngine.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SearchEngine.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private Type _selectedType;
        private object _repository;

        public ObservableCollection<ISearchable> SearchResults { get; set; } = new ObservableCollection<ISearchable>();
        public ObservableCollection<Type> ComponentTypes { get; set; } = new ObservableCollection<Type>();
        public ObservableCollection<SearchCriteria> searchCriteria { get; set; } = new ObservableCollection<SearchCriteria>();

        public Type SelectedType
        {
            get => _selectedType;
            set
            {
                if (_selectedType != value)
                {
                    _selectedType = value;
                    OnPropertyChanged(nameof(SelectedType));
                    GenerateSearchCriteria();
                    InitializeRepository();
                    SearchResults.Clear();
                    OnPropertyChanged(nameof(SearchResults));
                }
            }
        }

        public Action<object>? Open { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CreateCommand { get; private set; }

        public SearchViewModel(IEnumerable<Type> componentTypes)
        {
            // Dobavqme samo ako implementira Isearchable
            foreach (var type in componentTypes.Where(t => typeof(ISearchable).IsAssignableFrom(t)))
            {
                ComponentTypes.Add(type);
            }

            SearchCommand = new CommandDelegate(ExecuteSearch);
        }


        private void ViewModel_ItemCreated(object sender, ISearchable newItem)
        {
            ExecuteSearch();
        }

        private void RefreshList()
        {
            SearchResults.Clear();
            var method = _repository.GetType().GetMethod("GetAll");
            var results = ((IEnumerable<ISearchable>)method.Invoke(_repository, null)).ToList();
            if (results.Any())
            {
                results.ForEach(SearchResults.Add);
            }
        }

        private void InitializeRepository()
        {
            if (SelectedType != null)
            {
                //s reflektion vzima info
                Type repositoryGenericType = typeof(BaseRepository<>).MakeGenericType(SelectedType);
                _repository = Activator.CreateInstance(repositoryGenericType);
            }
        }

        private void GenerateSearchCriteria()
        {
            searchCriteria.Clear();
            if (SelectedType != null)
            {
                //Suzdava runtime instancia s reflection ot selekted type
                var instance = (ISearchable)Activator.CreateInstance(SelectedType);
                foreach (var key in instance.GetProperties().Keys)
                {
                    searchCriteria.Add(new SearchCriteria { Key = key, Value = string.Empty });
                }
            }
        }

        private async void ExecuteSearch() 
        {
            if (_repository != null)
            {
                var method = _repository.GetType().GetMethod("GetAll");

                // Ако нямаме никакви филтри вреъща вс
                var results = ((IEnumerable<ISearchable>)method.Invoke(_repository, null)).ToList();

                ISearchable fallbackResult = null; // тук ще съхраняваме резултата ако няма за дадената година
                string yearValue = "";

                foreach (var criterion in searchCriteria)
                {
                    if (!string.IsNullOrEmpty(criterion.Value))
                    {
                        // Със сигурност има критерии съдържащ израът година така съм мислил приложението
                        if (criterion.Key.ToLower().Contains("year"))
                        {
                            var yearSpecificResults = results.Where(item => item.GetProperties()[criterion.Key].ToString() == criterion.Value).ToList();

                            // Проверявам за сегашната година дали има нещо
                            if (yearSpecificResults.Any())
                            {
                                results = yearSpecificResults;
                            }
                            else
                            {
                                // Ако не взимам първото намерено
                                yearValue = criterion.Value;
                                fallbackResult = results.FirstOrDefault();
                            }
                        }
                        else
                        {
                            results = results.Where(item => item.GetProperties()[criterion.Key].ToString().Contains(criterion.Value)).ToList();
                        }
                    }
                }

                SearchResults.Clear();
                if (results.Any() && fallbackResult == null)
                {
                    results.ForEach(SearchResults.Add);
                }
                else if (fallbackResult != null)
                {
                    await CreateRecord(fallbackResult, yearValue);
                }
            }
        }

        public async Task CreateRecord(ISearchable fallback, string year)
        {
            var customDialog = new CustomDialog
            {
                DataContext = new DialogViewModel()
            };

            var result = (bool)await DialogHost.Show(customDialog, "RootDialog");

            if (result)
            {
                var viewModel = new CreateNewItemViewModel(SelectedType, year);
                //event listenera za klasa da refreshva surcha 
                viewModel.ItemCreated += ViewModel_ItemCreated;

                Open?.Invoke(viewModel);
            }
            else
            {
                // Ако нямаме резултат горе ем явно първото намерено
                SearchResults.Add(fallback);
            }
        }
    }
}
