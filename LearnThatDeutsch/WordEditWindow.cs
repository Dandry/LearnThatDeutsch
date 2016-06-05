using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnThatDeutsch
{
    public partial class WordEditWindow : Form
    {
        MainWindow mainWindow;
        DictionarySet currentSet;
        int selectedWordIndex = -1;
        Word wordToEdit = null;

        public WordEditWindow(MainWindow mainWindow, DictionarySet dictionarySet)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.wordTypeComboBox.SelectedIndex = 0;
            this.currentSet = dictionarySet;
        }

        public WordEditWindow(MainWindow mainWindow, DictionarySet currentSet, Word wordToEdit, int wordIndex)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.currentSet = currentSet;
            this.selectedWordIndex = wordIndex;
            this.Text = "Edytuj słowo";
            this.wordToEdit = wordToEdit;

            if (wordToEdit is Noun)
            {
                wordTypeComboBox.SelectedIndex = 0;
                Article article = ((Noun)wordToEdit).Article;
                switch (article)
                {
                    case Article.der:
                        articleComboBox.SelectedIndex = 0;
                        break;
                    case Article.die:
                        articleComboBox.SelectedIndex = 1;
                        break;
                    case Article.das:
                        articleComboBox.SelectedIndex = 2;
                        break;
                }
            }

            else if (wordToEdit is Verb)
                wordTypeComboBox.SelectedIndex = 1;
            else
                wordTypeComboBox.SelectedIndex = 2;

            germanTranslationTextBox.Text = wordToEdit.GermanTranslation;
            polishTranslationTextBox.Text = wordToEdit.PolishTranslation;

        }

        private void ResetWindow()
        {
            this.wordTypeComboBox.SelectedIndex = 0;
            this.articleComboBox.SelectedIndex = 0;
            germanTranslationTextBox.Clear();
            polishTranslationTextBox.Clear();
        }

        private void wordTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = wordTypeComboBox.SelectedIndex;
            if (index == 0)
            {
                articleComboBox.Enabled = true;
                articleComboBox.SelectedIndex = 0;
            }
            else
            {
                articleComboBox.Enabled = false;
                articleComboBox.SelectedIndex = -1;
            }
                
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "ä";
        }

        private void aUpperButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "Ä";
        }

        private void oButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "ö";
        }

        private void oUpperButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "Ö";
        }

        private void uButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "ü";
        }

        private void uUpperButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "Ü";
        }

        private void ssButton_Click(object sender, EventArgs e)
        {
            germanTranslationTextBox.Text += "ß";
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            bool isEditedWord = false;

            if (selectedWordIndex >= 0)
                isEditedWord = true;

            string polishTranslation = polishTranslationTextBox.Text;
            string germanTranslation = germanTranslationTextBox.Text;
            WordType wordType;

            string result = mainWindow.CheckIfWordAlreadyCreated(germanTranslation, polishTranslation);
            if (result != "")
            {
                MessageBox.Show("Podane słowo znaduje się już w zestawie '" + result + "'.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            switch (wordTypeComboBox.SelectedIndex)
            {
                case 0:
                    {
                        wordType = WordType.Noun;
                        Article article = 0;

                        switch (articleComboBox.SelectedIndex)
                        {
                            case 0:
                                article = Article.der;
                                break;
                            case 1:
                                article = Article.die;
                                break;
                            case 2:
                                article = Article.das;
                                break;
                        }

                        currentSet.CreateNewWord(wordType, article, germanTranslation, polishTranslation);
                        break;
                    }

                case 1:
                    wordType = WordType.Verb;
                    currentSet.CreateNewWord(wordType, germanTranslation, polishTranslation);
                    break;
                case 2:
                    wordType = WordType.Adjective;
                    currentSet.CreateNewWord(wordType, germanTranslation, polishTranslation);
                    break;
            } 

            if (isEditedWord)
            {
                currentSet.ReplaceOldWordWithNew(selectedWordIndex);
                this.Close();
            }
            currentSet.ChangeModificationTime();
            this.ResetWindow();
            mainWindow.UpdateWordList();
        }
    }
}
