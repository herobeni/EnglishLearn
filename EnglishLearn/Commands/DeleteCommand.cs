using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EnglishLearn.Models;
using EnglishLearn.ViewModels;

namespace EnglishLearn.Commands
{
    class DeleteCommand:ICommand
    {
        private MainWindowVM mainWindowVm;

        public DeleteCommand(MainWindowVM main)
        {
            mainWindowVm = main;
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
            mainWindowVm.DeleteWord();
        }
    }
}
