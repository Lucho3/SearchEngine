using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SearchEngine.ViewModels
{
    internal class CommandDelegate : ICommand
    {
        private readonly Action _action;

        public CommandDelegate(Action action)
        {
            _action = action;
        }

        public void Execute(object? parameter)
        {
            _action();
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }
}
