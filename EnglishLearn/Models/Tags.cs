using System;
using System.Collections.Generic;

namespace EnglishLearn.Models
{
    [Serializable]
    class Tags
    {
        public string Tag { get; set; }
        public List<Words> WordsWithThisTag;

    }
}
