using SearchEngine.ViewModels;
using SearchEngine.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(SearchViewModel mainContext)
        {
            InitializeComponent();
            DataContext = mainContext;
            Loaded += Main_Loaded;
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is SearchViewModel vm)
            {
                vm.Open += (object op) =>
                {
                    var creationWindow = new CreationWindow
                    {
                        DataContext = op
                    };
                    creationWindow.ShowDialog();
                };
            }
        }

    }

}