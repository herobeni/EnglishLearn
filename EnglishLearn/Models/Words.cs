using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearn.Models
{
    class Words
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public string Transcription { get; set; }

        public Words(string w,string translation,string transcription)
        {
            Word = w;
            Translation = translation;
            Transcription = transcription;
        }
    }
}
