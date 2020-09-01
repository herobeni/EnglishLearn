using System;
using System.Collections.Generic;

namespace EnglishLearn.Models
{
    [Serializable]
    class Words
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public DateTime Date { get; }
        public List<Tags> Tagses { get; set; }
        public Words(string word, string translation, string transcription)
        {
            Word = word;
            Translation = translation;
            Transcription = transcription;
            Date = DateTime.Now;
        }
    }
}
