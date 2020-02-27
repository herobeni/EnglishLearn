using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Words(string w,string translation,string transcription)
        {
            Word = w;
            Translation = translation;
            Transcription = transcription;
            Date=DateTime.Now;
        }
    }
}
