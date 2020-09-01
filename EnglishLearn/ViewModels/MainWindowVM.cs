using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Data;
using System.Windows.Input;
using EnglishLearn.Commands;
using EnglishLearn.Models;
using GalaSoft.MvvmLight.CommandWpf;
using Prism.Mvvm;

namespace EnglishLearn.ViewModels
{
    class MainWindowVM : BindableBase
    {
        public ICommand newWordCommand { get; private set; }
        public ICommand sortCommand { get; private set; }
        public ICommand deleteCommand { get; private set; }
        public ICommand Serialization
        {
            get
            {
                return new RelayCommand<CancelEventArgs>(
                    (args) =>
                    {
                        using (FileStream fl = new FileStream("Words.dat", FileMode.Create))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(fl, _wordsList);
                        }

                    });
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<string>(
                    (text) =>
                    {
                        _wordsSearch = new ObservableCollection<Words>();
                        if (text == "")
                        {
                            ViewList.Source = _wordsList;
                            ViewList.View.Refresh();
                        }
                        else
                        {
                            IEnumerable<Words> SearchWords = null;
                            if (text == AddWord)
                            {
                                SearchWords = from Words in _wordsList
                                              where Words.Word.ToLower().StartsWith(text.ToLower())
                                              select Words;
                            }
                            if (text == AddTranslation)
                            {
                                SearchWords = from Words in _wordsList
                                              where Words.Translation.ToLower().StartsWith(text.ToLower())
                                              select Words;
                            }
                            if (text == AddTranscription)
                            {
                                SearchWords = from Words in _wordsList
                                              where Words.Transcription.ToLower().StartsWith(text.ToLower())
                                              select Words;
                            }
                            foreach (var VARIABLE in SearchWords)
                            {
                                _wordsSearch.Add(VARIABLE);
                            }

                            ViewList.Source = _wordsSearch;
                            ViewList.View.Refresh();
                        }

                    });
            }
        }
        private string _addWord = "";
        public string AddWord
        {
            get { return _addWord; }
            set
            {
                _addWord = value;
                RaisePropertyChanged("AddWord");
            }
        }

        private string _addTranslation = "";
        public string AddTranslation
        {
            get { return _addTranslation; }
            set
            {
                _addTranslation = value;
                RaisePropertyChanged("AddTranslation");
            }
        }

        private string _addTranscription = "";
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

        private ObservableCollection<Words> _wordsSearch;

        private ObservableCollection<Words> _wordsList;

        public ReadOnlyObservableCollection<Words> WordsList
        {
            get { return new ReadOnlyObservableCollection<Words>(_wordsList); }
        }
        public MainWindowVM()
        {
            using (FileStream fs = new FileStream("Words.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formater = new BinaryFormatter();
                if (fs.Length > 0)
                    _wordsList = (ObservableCollection<Words>)formater.Deserialize(fs);
                else _wordsList = new ObservableCollection<Words>();
            }
            deleteCommand = new DeleteCommand(this);
            newWordCommand = new AddWordCommand(this);
            sortCommand = new SortCommand(this);
            ViewList = new CollectionViewSource();
            ViewList.Source = _wordsList;
        }

        public void AddNewWord()
        {
            _wordsList.Add(new Words(AddWord, AddTranslation, AddTranscription));
            ViewList.View.Refresh();
        }

        public void DeleteWord()
        {
            _wordsList.Remove(_selectedItem);
            ViewList.View.Refresh();
        }

        public void Sort(string mode)
        {
            var SortWords = from Words in WordsList select Words;
            switch (mode)
            {
                case "1":
                    SortWords = from Words in _wordsList orderby Words.Date select Words;
                    break;
                case "2":
                    SortWords = from Words in _wordsList orderby Words.Word select Words;
                    break;
                case "3":
                    SortWords = from Words in _wordsList orderby Words.Translation select Words;
                    break;
            }
            _wordsList = new ObservableCollection<Words>();
            foreach (var VARIABLE in SortWords)
            {
                _wordsList.Add(VARIABLE);
            }

            ViewList.Source = _wordsList;
            ViewList.View.Refresh();
        }

    }
}
