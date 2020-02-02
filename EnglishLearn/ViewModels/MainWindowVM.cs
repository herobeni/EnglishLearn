using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using EnglishLearn.Commands;
using EnglishLearn.Models;
using EnglishLearn.Views;
using Prism.Mvvm;

namespace EnglishLearn.ViewModels
{
    class MainWindowVM:BindableBase
    {
        public ICommand buttonCommand { get; private set; }
        public CollectionViewSource ViewList { get; set; }
        private ObservableCollection<Words> wordsList = new ObservableCollection<Words>();

        public ReadOnlyObservableCollection<Words> WordsList
        {
            get { return new ReadOnlyObservableCollection<Words>(wordsList); }
        }

        
        private string addWord;
        public string AddWord
        {
            get { return addWord; }
            set
            {
                addWord = value;
                RaisePropertyChanged(AddWord);
            }
        }
        private string _addTranslation;
        public string AddTranslation
        {
            get { return _addTranslation; }
            set
            {
                _addTranslation = value;
                RaisePropertyChanged(AddTranslation);
            }
        }
        private string _addTranscription;

        public string AddTranscription
        {
            get { return _addTranscription; }
            set
            {
                _addTranscription = value;
                RaisePropertyChanged(AddTranscription);
            }
        }

        public MainWindowVM()
        {

            buttonCommand= new AddWordCommand(this);
            ViewList= new CollectionViewSource();
            ViewList.Source = wordsList;
        }

        public void AddNewWord()
        {
            wordsList.Add(new Words(AddWord,AddTranslation,AddTranscription));
            ViewList.View.Refresh();
        }
    }
}
