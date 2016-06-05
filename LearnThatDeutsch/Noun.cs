using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    [Serializable]
    class Noun : Word
    {
        public Article Article { get; private set; }

        public Noun(WordType wordType, Article article, string german, string polish)
            : base(wordType, german, polish)
        {
            this.PolishTranslation = polish;
            this.GermanTranslation = german;
            this.Article = article;
        }
    }
}
