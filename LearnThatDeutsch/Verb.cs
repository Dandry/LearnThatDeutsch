using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    [Serializable]
    class Verb : Word
    {
        public Verb(WordType wordType, string german, string polish) : base(wordType, german, polish)
        {
            this.PolishTranslation = polish;
            this.GermanTranslation = german;
        }
    }
}
