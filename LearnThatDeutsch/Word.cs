using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    [Serializable]
    public abstract class Word
    {
        public string PolishTranslation { get;  set; }
        public string GermanTranslation { get; set; }
        public string WordTypeString { get; private set; }

        public Word (WordType wordType, string german, string polish)
        {
            this.PolishTranslation = polish;
            this.GermanTranslation = german;
            
            switch (wordType)
            {
                case WordType.Noun:
                    WordTypeString = "rzecz.";
                    break;
                case WordType.Verb:
                    WordTypeString = "czas.";
                    break;
                case WordType.Adjective:
                    WordTypeString = "przym.";
                    break;
            }
        }
    }
}
