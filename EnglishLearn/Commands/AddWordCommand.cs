using System;
using System.Windows.Input;
using EnglishLearn.ViewModels;

namespace EnglishLearn.Commands
{
    class AddWordCommand : ICommand
    {
        private MainWindowVM _mainWindowVm;

        public AddWordCommand(MainWindowVM main)
        {
            _mainWindowVm = main;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _mainWindowVm.AddNewWord();

        }
    }
}
