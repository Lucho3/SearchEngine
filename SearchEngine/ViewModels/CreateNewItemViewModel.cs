using SearchEngine.Database.Models;
using SearchEngine.Database.Reositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SearchEngine.ViewModels
{
    public class CreateNewItemViewModel
    {
        public ObservableCollection<SearchCriteria> Properties { get; set; }
        public ICommand SaveCommand { get; set; }
        public event EventHandler<ISearchable> ItemCreated;

        private object _repository;
        private Type _itemType;

        public CreateNewItemViewModel(Type selectedType, string year)
        {
            _itemType = selectedType;
            Type repositoryGenericType = typeof(BaseRepository<>).MakeGenericType(_itemType);
            _repository = Activator.CreateInstance(repositoryGenericType);
            Properties = new ObservableCollection<SearchCriteria>();
            InitializeProperties(selectedType, year);
            SaveCommand = new CommandDelegate(SaveItem);
        }

        private void InitializeProperties(Type itemType, string year)
        {
            if (_itemType != null)
            {
                //Suzdava runtime instancia s reflection ot selekted type
                var instance = (ISearchable)Activator.CreateInstance(_itemType);
                foreach (var key in instance.GetProperties().Keys)
                {
                    if (key.ToLower().Contains("year"))
                    {
                        Properties.Add(new SearchCriteria { Key = key, Value = year });
                    }
                    else
                    {
                        Properties.Add(new SearchCriteria { Key = key, Value = string.Empty });
                    }
                }
            }
        }

        private void SaveItem()
        {
            var newItem = Activator.CreateInstance(_itemType);
            foreach (var prop in Properties)
            {
                var trimedKey = prop.Key.Replace(" ", "");
                var propertyInfo = _itemType.GetProperty(trimedKey);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(newItem, Convert.ChangeType(prop.Value, propertyInfo.PropertyType), null);
                }
            }
            var addMethod = _repository.GetType().GetMethod("Add");
            addMethod.Invoke(_repository, [newItem]);
            ItemCreated.Invoke(null, null);
        }
    }
}