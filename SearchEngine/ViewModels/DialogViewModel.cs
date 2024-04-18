using MaterialDesignThemes.Wpf;
using SearchEngine.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SearchEngine.ViewModels
{
    internal class DialogViewModel : BaseViewModel
    {
        public ICommand OkCommand { get; }
        public ICommand CloseDialogCommand { get; }

        public DialogViewModel()
        {
            OkCommand = new CommandDelegate(ExecuteOk);
            CloseDialogCommand = new CommandDelegate(ExecuteClose);
        }

        private void ExecuteOk()
        {
            // Handle OK logic here
            DialogHost.CloseDialogCommand.Execute(true, null); // Pass true as a dialog result
        }

        private void ExecuteClose()
        {
            // Handle Close logic here
            DialogHost.CloseDialogCommand.Execute(false, null); // Pass false as a dialog result
        }

    
    }
}
