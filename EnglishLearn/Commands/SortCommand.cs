using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EnglishLearn.ViewModels;

namespace EnglishLearn.Commands
{
    class SortCommand : ICommand
    {
        private MainWindowVM mainWindowVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SortCommand(MainWindowVM m)
        {
            mainWindowVm = m;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            string i = parameter.ToString();
            mainWindowVm.Sort(i);
        }
        
    }
}
