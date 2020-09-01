using System;
using System.Windows.Input;
using EnglishLearn.ViewModels;

namespace EnglishLearn.Commands
{
    class SortCommand : ICommand
    {
        private MainWindowVM _mainWindowVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SortCommand(MainWindowVM m)
        {
            _mainWindowVm = m;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            string i = parameter.ToString();
            _mainWindowVm.Sort(i);
        }

    }
}
