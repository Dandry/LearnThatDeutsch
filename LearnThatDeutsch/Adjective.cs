using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    [Serializable]
    class Adjective : Word
    {
        public Adjective(WordType wordType, string german, string polish)
            : base(wordType, german, polish)
        {
            this.PolishTranslation = polish;
            this.GermanTranslation = german;
        }
    }
}
