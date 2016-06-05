using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    [Serializable]
    public class DictionarySet
    {
        public List<Word> words { get; private set; }
        private DateTime dateModified;
        public int ID { get; set; }
        public string Name { get; private set; }
        public string DateModifiedFormatted 
        { 
            get
            {
                return dateModified.ToString("dd-MM-yyyy HH:mm");
            }
        }

        public DictionarySet(string name, int index)
        {
            this.Name = name;
            this.dateModified = DateTime.Now;
            this.ID = index;
            words = new List<Word>();
        }

        public void ChangeName(string name)
        {
            this.Name = name;
            this.dateModified = DateTime.Now;
        }

        public void ChangeModificationTime()
        {
            this.dateModified = DateTime.Now;
        }

        public void CreateNewWord(WordType wordType, Article article, string german, string polish)
        {
            words.Add(new Noun(wordType, article, german, polish));
        }

        public void CreateNewWord(WordType wordType, string polish, string german)
        {
            if (wordType == WordType.Verb)
                words.Add(new Verb(wordType, polish, german));
            else
                words.Add(new Adjective(wordType, polish, german));
        }

        public bool CheckIfWordAlreadyCreated(string germanTranslation, string polishTranslation)
        {
            germanTranslation = germanTranslation.ToLower();
            polishTranslation = polishTranslation.ToLower();

            foreach (Word w in words)
            {
                if (w.PolishTranslation.ToLower() == polishTranslation || w.GermanTranslation.ToLower() == germanTranslation)
                    return true;
            }
            return false;
        }

        public void SortWordList(int columnIndex)
        {
            switch (columnIndex)
            {
                case 2:
                    words = words.OrderBy(o => o.GermanTranslation).ToList();
                    break;
                case 3:
                    words = words.OrderBy(o => o.PolishTranslation).ToList();
                    break;
            }
                
        }

        public void ReplaceOldWordWithNew(int wordIndex)
        {
            int lastIndex = words.Count - 1;
            Word lastWord = words[lastIndex];
            words.RemoveAt(wordIndex);
            words.Insert(wordIndex, lastWord);
            words.RemoveAt(lastIndex);
        }

    }
}
