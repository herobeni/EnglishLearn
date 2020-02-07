using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using EnglishLearn.Commands;
using EnglishLearn.Models;
using EnglishLearn.Views;
using GalaSoft.MvvmLight.CommandWpf;
using Prism.Mvvm;

namespace EnglishLearn.ViewModels
{
    class MainWindowVM:BindableBase
    {
        public ICommand buttonCommand { get; private set; }
        public ICommand sortCommand { get; private set; }
        public ICommand deleteCommand { get; private set; }
        public ICommand WindowClosing
        {
            get
            {
                return new RelayCommand<CancelEventArgs>(
                    (args) =>
                    {
                        using(FileStream fl = new FileStream("Words.dat",FileMode.Create))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(fl,wordsList);
                        }
                        
                    });
            }
        }
        
        private string _addWord;
        public string AddWord
        {
            get { return _addWord; }
            set
            {
                _addWord = value;
                RaisePropertyChanged("AddWord");
            }
        }
        private string _addTranslation;
        public string AddTranslation
        {
            get { return _addTranslation; }
            set
            {
                _addTranslation = value;
                RaisePropertyChanged("AddTranslation");
            }
        }
        private string _addTranscription;
        public string AddTranscription
        {
            get { return _addTranscription; }
            set
            {
                _addTranscription = value;
                RaisePropertyChanged("AddTranscription");
            }
        }
        private Words _selectedItem;
        public Words SelectedItemWords
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItemWords");
            }
        }
        public CollectionViewSource ViewList { get; set; }
        private ObservableCollection<Words> wordsSearch;
        private ObservableCollection<Words> wordsList;
        public ReadOnlyObservableCollection<Words> WordsList
        {
            get { return new ReadOnlyObservableCollection<Words>(wordsList); }
        }
        public MainWindowVM()
        {
            
            using (FileStream fs = new FileStream("Words.dat",FileMode.OpenOrCreate))
            {
                BinaryFormatter formater = new BinaryFormatter();
                if(fs.Length>0)
                wordsList = (ObservableCollection<Words>) formater.Deserialize(fs);
                else wordsList= new ObservableCollection<Words>();
            }
            deleteCommand= new DeleteCommand(this);
            buttonCommand= new AddWordCommand(this);
            sortCommand = new SortCommand(this);
            ViewList= new CollectionViewSource();
            ViewList.Source = wordsList;
        }
        public void AddNewWord()
        {
            wordsList.Add(new Words(AddWord,AddTranslation,AddTranscription));
            ViewList.View.Refresh();
        }

        public void DeleteWord()
        {
            wordsList.Remove(_selectedItem);
            ViewList.View.Refresh();
        }

        public void Sort(string mode)
        {
            var SortWords = from Words in WordsList select Words;
            switch (mode)
            {
                case "1": SortWords = from Words in wordsList orderby Words.Date select Words;
                    break;
                case "2": SortWords = from Words in wordsList orderby Words.Word select Words;
                    break;
                case "3": SortWords = from Words in wordsList orderby Words.Translation select Words;
                    break;
            }
            wordsList=new ObservableCollection<Words>();
            foreach(var VARIABLE in SortWords)
            {
                wordsList.Add(VARIABLE);
            }

            ViewList.Source = wordsList;
            ViewList.View.Refresh();
        }
        
    }
}
