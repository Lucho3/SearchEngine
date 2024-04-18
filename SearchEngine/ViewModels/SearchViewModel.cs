using SearchEngine.Database;
using SearchEngine.Database.Models;
using SearchEngine.Database.Reositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
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
                }
            }
        }

        public ICommand SearchCommand { get; set; }

        public SearchViewModel(IEnumerable<Type> componentTypes)
        {
            // Dobavqme samo ako implementira Isearchable
            foreach (var type in componentTypes.Where(t => typeof(ISearchable).IsAssignableFrom(t)))
            {
                ComponentTypes.Add(type);
            }

            SearchCommand = new CommandDelegate(ExecuteSearch);
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

        private void ExecuteSearch()
        {
            if (_repository != null)
            {
                var method = _repository.GetType().GetMethod("GetAll");
                var results = ((IEnumerable<ISearchable>)method.Invoke(_repository, null)).ToList();

                foreach (var criterion in searchCriteria)
                {
                    if (!string.IsNullOrEmpty(criterion.Value))
                    {
                        results = results.Where(item => item.GetProperties()[criterion.Key].ToString().Contains(criterion.Value)).ToList();
                    }
                }

                SearchResults.Clear();
                results.ForEach(SearchResults.Add);
            }
        }
    }
}
