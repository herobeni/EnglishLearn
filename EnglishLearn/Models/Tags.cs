using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearn.Models
{
    [Serializable]
    class Tags
    {
        public string Tag { get; set; }
        public List<Words> WordsWithThisTag;

    }
}
