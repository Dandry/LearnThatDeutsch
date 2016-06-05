using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThatDeutsch
{
    class Quiz
    {
        // There are two word lists which store quiz words - first one is for picking a word for a quiz step and then removing it (so words do not repeat)
        // Second one is for giving translations for additional option buttons
        // The third list stores words which were answered incorrectly
        List<Word> quizWords;
        List<Word> supportingWordList;
        List<Word> wrongWords;
        
        Word currentWord;
        Random random;
        string wordToTranslate;
        string wordTranslation;
        int quizWordsNumber;
        bool translateFromGerman;
        bool germanToPolish;
        bool polishToGerman;
        bool simplifiedQuiz;
        public int WordCount { get; private set; }
        public int PositiveScore { get; private set; }
        public int NegativeScore { get; private set; }
        public bool QuizOn { get; set; }
        public int NumberOfWordsAvailable { get; private set; } 

        public Quiz(List<DictionarySet> dictionarySets, bool nounChecked, bool verbChecked, bool adjChecked)
        {
            InitalizeVariables();
            foreach (DictionarySet ds in dictionarySets)
            {
                foreach (Word w in ds.words)
                {
                    if (w is Noun)
                    {
                        if (nounChecked)
                        {
                            quizWords.Add(w);
                            NumberOfWordsAvailable += 1;
                        }
                    }
                    else if (w is Verb)
                    {
                        if (verbChecked)
                        {
                            quizWords.Add(w);
                            NumberOfWordsAvailable += 1;
                        }
                    }
                    else if (w is Adjective)
                    {
                        if (adjChecked)
                        {
                            quizWords.Add(w);
                            NumberOfWordsAvailable += 1;
                        }     
                    }  
                }
            }
        }

        private void InitalizeVariables()
        {
            PositiveScore = 0;
            NegativeScore = 0;
            NumberOfWordsAvailable = 0;
            WordCount = 0;
            QuizOn = false;
            quizWords = new List<Word>();
            supportingWordList = new List<Word>();
            wrongWords = new List<Word>();
        }

        public bool CheckIfCurrentWordIsANounAndTranslatedFromPolish()
        {
            if (!translateFromGerman)
                if (currentWord is Noun)
                    return true;
            return false;
        }

        private bool GetRandomBool()
        {
            int randomNumber = random.Next(2);
            if (randomNumber == 0)
                return true;
            else
                return false;
        }

        private void PickGermanOrPolish()
        {
            if (germanToPolish)
                if (polishToGerman)
                    translateFromGerman = GetRandomBool();
                else
                    translateFromGerman = true;
            else
                translateFromGerman = false;
        }

        public void StartQuiz(int numberOfWordsPicked, bool simplifiedQuiz, bool germanToPolish, bool polishToGerman)
        {
            random = new Random();
            QuizOn = true;
            this.simplifiedQuiz = simplifiedQuiz;
            supportingWordList.AddRange(quizWords);
            this.quizWordsNumber = numberOfWordsPicked;
            PickGermanOrPolish();
            this.germanToPolish = germanToPolish;
            this.polishToGerman = polishToGerman;
        }

        public string StopQuiz()
        {
            QuizOn = false;
            string summary = SummarizeQuiz();
            return summary;
        }

        public void PickRandomWord()
        {
            PickGermanOrPolish();
            WordCount++;
            int wordPicked = random.Next(quizWords.Count);
            currentWord = quizWords[wordPicked];
            quizWords.RemoveAt(wordPicked);
        }

        // method for advanced quiz
        public string PickAWord_Advanced()
        {
            PickRandomWord();
            if (translateFromGerman)
            {
                wordToTranslate = ConvertWordTranslationIfANoun(currentWord);
                wordTranslation = currentWord.PolishTranslation;
            }
            else
            {
                wordToTranslate = currentWord.PolishTranslation;
                wordTranslation = ConvertWordTranslationIfANoun(currentWord);
            }
            return wordToTranslate;
        }

        // method for simplified quiz
        public Queue<string> PickAWord_Simplified()
        {
            PickRandomWord();
            string secondWordTranslation;
            string thirdWordTranslation;
            // Getting two other random words from supporting word list (which contains all the quiz words), check if they don't
            // repeat themselves and add their translations to the queue
            Word secondRandomWord = supportingWordList[random.Next(supportingWordList.Count)];
            Word thirdRandomWord = supportingWordList[random.Next(supportingWordList.Count)];
            while (secondRandomWord.Equals(thirdRandomWord) || currentWord.Equals(secondRandomWord) || currentWord.Equals(thirdRandomWord))
            {
                if (secondRandomWord.Equals(thirdRandomWord))
                    thirdRandomWord = supportingWordList[random.Next(supportingWordList.Count)];
                else if (currentWord.Equals(secondRandomWord))
                    secondRandomWord = supportingWordList[random.Next(supportingWordList.Count)];
                else if (currentWord.Equals(thirdRandomWord))
                    thirdRandomWord = supportingWordList[random.Next(supportingWordList.Count)];
            }
            
            if (translateFromGerman)
            {
                wordToTranslate = ConvertWordTranslationIfANoun(currentWord);
                wordTranslation = currentWord.PolishTranslation;
                secondWordTranslation = secondRandomWord.PolishTranslation;
                thirdWordTranslation = thirdRandomWord.PolishTranslation;
            }
            else
            {
                wordToTranslate = currentWord.PolishTranslation;
                wordTranslation = currentWord.GermanTranslation;
                secondWordTranslation = secondRandomWord.GermanTranslation;
                thirdWordTranslation = thirdRandomWord.GermanTranslation;
            }
            // Initializing queue and adding the word to translate
            Queue<string> wordList = new Queue<string>();
            wordList.Enqueue(wordToTranslate);
            // Adding 3 possible translations (one is true), and shuffling them with help of additional List
            List<string> wordsToShuffle = new List<string>();
            wordsToShuffle.Add(wordTranslation);
            wordsToShuffle.Add(secondWordTranslation);
            wordsToShuffle.Add(thirdWordTranslation);
            while (wordsToShuffle.Count > 0)
            {
                int randomIndex = random.Next(wordsToShuffle.Count);
                wordList.Enqueue(wordsToShuffle[randomIndex]);
                wordsToShuffle.RemoveAt(randomIndex);
            }
            wordsToShuffle = null;
            return wordList;
        }

        // editing the string if the word is a noun - adding the article
        private string ConvertWordTranslationIfANoun(Word currentWord)
        {
            string translation;
            if (currentWord is Noun)
                translation = ((Noun)currentWord).Article + " " + currentWord.GermanTranslation;
            else
                translation = currentWord.GermanTranslation;
            return translation;
        }

        public void CheckTheWord(string insertedWord, Article article)
        {
            if (!translateFromGerman)
            {
                if (currentWord is Noun)
                {
                    insertedWord = article.ToString() + " " + insertedWord;
                    wordTranslation = ((Noun)currentWord).Article.ToString() + " " + wordTranslation;
                }    
            }
            CheckTheWord(insertedWord);
        }

        public void CheckTheWord(string insertedWord)
        {
            if (insertedWord == wordTranslation)
            {
                PositiveScore++;
            }
            else
            {
                NegativeScore++;
                wrongWords.Add(currentWord);
            } 
        }

        private string SummarizeQuiz()
        {
            string summary;
            int accuracy;
            if (WordCount != 0)
                accuracy = PositiveScore * 100 / WordCount;
            else
                accuracy = 0;
            summary = "Liczba poprawnych odpowiedzi: " + PositiveScore + Environment.NewLine;
            summary += "Liczba negatywnych odpowiedzi: " + NegativeScore + Environment.NewLine;
            summary += "Poprawność: " + accuracy + "%" + Environment.NewLine;
            summary += Environment.NewLine;

            if (NegativeScore > 0)
            {
                summary += "Słowa, na które udzielono błędnych odpowiedzi:" + Environment.NewLine;
                foreach (Word w in wrongWords)
                {
                    if (w is Noun)
                    {
                        summary += ((Noun)w).Article.ToString() + " ";
                    }

                    summary += w.GermanTranslation + " - " + w.PolishTranslation + Environment.NewLine;
                }
            }
            else
            {
                summary += "Quiz rozwiązany poprawnie." + Environment.NewLine;
                summary += "Świetna robota!";
            }
            return summary;
        }
    }
}
