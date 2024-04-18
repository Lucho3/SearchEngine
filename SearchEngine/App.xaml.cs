using SearchEngine.Database.Models;
using SearchEngine.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SearchEngine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var types = new List<Type> { typeof(Car), typeof(Project), typeof(Person) };
            var searchViewModel = new SearchViewModel(types);
            var mainWindow = new MainWindow { DataContext = searchViewModel };
            mainWindow.Show();
        }
    }

}
