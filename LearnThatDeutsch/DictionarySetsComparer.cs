using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    class DictionarySetsComparer : IComparer<DictionarySet>
    {
        public int Compare(DictionarySet x, DictionarySet y)
        {
            if (x.ID > y.ID)
                return -1;
            if (x.ID < y.ID)
                return 1;
            else
                return 0;
        }
    }
}
