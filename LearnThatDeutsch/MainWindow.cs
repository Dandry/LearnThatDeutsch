using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnThatDeutsch
{
    public partial class MainWindow : Form
    {
        List<DictionarySet> dictionarySets;
        DictionarySet currentSet = null;
        DictionarySetsComparer setsComparer = new DictionarySetsComparer();
        string dictionaryFileName = "LearnThatDeutsch.dat";
        string fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
        Quiz quiz;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BASIC PROGRAM ELEMENTS
        /// </summary>
        private void ShowProgramInfo()
        {
            string info = this.Text + Environment.NewLine;
            info += "v1.0" + Environment.NewLine;
            info += "October 2015" + Environment.NewLine;
            info += "Autor: Daniel Andraszewski" + Environment.NewLine;
            info += "daniel.andraszewski@gmail.com" + Environment.NewLine;

            MessageBox.Show(info, "O programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void informacjeOProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProgramInfo();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDictionary();

            }
            catch
            {
                dictionarySets = new List<DictionarySet>();
                SaveDictionary();
                LoadDictionary();
            }
            InitializeDictionaryAndQuizComponents();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var closePrompt = MessageBox.Show("Czy na pewno chcesz wyjść z programu?", "Zamknięcie programu", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            if (closePrompt == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveDictionary();
        }

        private void SaveDictionary()
        {
            using (Stream output = File.Create(fileLocation + dictionaryFileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, dictionarySets);
            }
        }

        private void LoadDictionary()
        {

            using (Stream input = File.OpenRead(fileLocation + dictionaryFileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                dictionarySets = (List<DictionarySet>)bf.Deserialize(input);
            }
        }

        private void InitializeDictionaryAndQuizComponents()
        {
            //both dictionary and quiz
            UpdateSetList();
            //dictionary
            UpdateControlState();
            UpdateModificationDate();
            UpdateWordList();
            //quiz
            for (int i = 0; i < quizSetCheckedListBox.Items.Count; i++)
                quizSetCheckedListBox.SetItemChecked(i, true);
            UpdateQuizSets();
        }

        private void UpdateSetList()
        {
            dictionarySets.Sort(setsComparer);
            setsListBox.Items.Clear();
            quizSetCheckedListBox.Items.Clear();
            foreach (DictionarySet ds in dictionarySets)
            {
                quizSetCheckedListBox.Items.Add(ds);
                setsListBox.Items.Add(ds);
            }
            if (setsListBox.Items.Count > 0)
                setsListBox.SelectedIndex = 0;
            SaveDictionary();
        }

        /// <summary>
        /// DICTIONARY ELEMENTS
        /// </summary>
        public void CreateOrEditSet(bool isNewSet, string name)
        {
            if (isNewSet)
            {
                int index = dictionarySets.Count;
                dictionarySets.Add(new DictionarySet(name, index));
                UpdateSetList();
            }
            else
            {
                int selectedSet = setsListBox.SelectedIndex;
                dictionarySets[selectedSet].ChangeName(name);
            }
        }

        public void UpdateWordList()
        {
            SaveDictionary();
            if (currentSet != null)
            {
                wordsListView.Items.Clear();
                int index = 1;

                foreach (Word w in currentSet.words)
                {
                    ListViewItem newItem = null;
                    if (w is Noun)
                    {
                        if (nounCheckBox.Checked)
                        {
                            newItem = new ListViewItem("" + index);
                            newItem.SubItems.Add(((Noun)w).Article.ToString());
                        }
                    }
                    else
                    {
                        if (w is Verb && verbCheckBox.Checked || w is Adjective && adjectiveCheckBox.Checked)
                        {
                            newItem = new ListViewItem("" + index);
                            newItem.SubItems.Add("--");
                        }
                    }

                    if (newItem != null)
                    {
                        newItem.SubItems.Add(w.GermanTranslation);
                        newItem.SubItems.Add(w.PolishTranslation);
                        newItem.SubItems.Add(w.WordTypeString);
                        wordsListView.Items.Add(newItem);
                    }
                    index++;
                }
            }
            else
                wordsListView.Items.Clear();

            UpdateWordsCount();
            UpdateModificationDate();
        }
        
        private void addNewSetButton_Click(object sender, EventArgs e)
        {
            bool isNewSet = true;
            string name = "";
            var setName = new SetEditWindow(this, isNewSet, name);
            setName.Show();
        }

        private void editSetButton_Click(object sender, EventArgs e)
        {
            LaunchCreateOrEditSetWindow(sender);
        }

        private void removeSet_Click(object sender, EventArgs e)
        {
            int selectedSet = setsListBox.SelectedIndex;
            var popup = MessageBox.Show("Czy na pewno chcesz usunąć zestaw '" + dictionarySets[selectedSet].Name + "'?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (popup == DialogResult.Yes)
            {
                dictionarySets.RemoveAt(selectedSet);
                UpdateSetList();
                UpdateControlState();
            }
        }
        
        private void addWordButton_Click(object sender, EventArgs e)
        {
            if (currentSet != null)
            {
                List<Word> setWordList = currentSet.words;

                var wordEditWindow = new WordEditWindow(this, currentSet);
                wordEditWindow.Show();
            }
            else
                MessageBox.Show("Nie zaznaczono żadnego zestawu.", "Nie można dodać słowa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void EditOrDeleteWord(object sender)
        {
            if (wordsListView.SelectedItems.Count > 0)
            {
                int selectedListIndex = wordsListView.FocusedItem.Index;
                ListViewItem selectedItem = wordsListView.Items[selectedListIndex];
                int selectedWordIndex = Int32.Parse(selectedItem.SubItems[0].Text) - 1;

                if (sender == editWordButton)
                {
                    Word wordToEdit = currentSet.words[selectedWordIndex];
                    var wordEditWindow = new WordEditWindow(this, currentSet, wordToEdit, selectedWordIndex);
                    wordEditWindow.Show();
                }
                else
                {
                    var message = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone słowo?", "Usunięcie słowa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (message == DialogResult.Yes)
                    {
                        currentSet.words.RemoveAt(selectedWordIndex);
                    }
                }
                currentSet.ChangeModificationTime();
                UpdateWordList();
            }
            else
            {
                string description = "Nie wybrano słowa do ";
                if (sender == editWordButton)
                    description += "edycji.";
                else
                    description += "usunięcia.";
                MessageBox.Show(description, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UpdateModificationDate()
        {
            // print and update modification date of a current dictionary set
            if (setsListBox.Items.Count > 0)
            {
                int selectedSet = setsListBox.SelectedIndex;
                lastModificationLabel.Text = dictionarySets[selectedSet].DateModifiedFormatted;
                lastModificationLabel.Visible = true;
                ostatniaModyfikacjaLabel.Visible = true;
            }
        }

        private void UpdateWordsCount()
        {
            // count number of words in selected set and also the total number
            int totalWordCount = 0;
            foreach (DictionarySet ds in dictionarySets)
                totalWordCount += ds.words.Count;

            wordCountLabel.Text = "Liczba słów:" + Environment.NewLine;
            if (currentSet != null)
            {
                int setWordCount = currentSet.words.Count;
                wordCountLabel.Text += "W zestawie - " + setWordCount + Environment.NewLine;
            }
            wordCountLabel.Text += "Ogółem - " + totalWordCount;
        }

        private void UpdateControlState()
        {
            // dictionary elements accessibility control based on check if any set has been
            // checked/selected
            if (setsListBox.SelectedIndex != -1)
            {
                articlesGroupBox.Enabled = true;
                tipLabel.Enabled = true;
                addWordButton.Enabled = true;
                editWordButton.Enabled = true;
                deleteWordButton.Enabled = true;
                wordsListView.Enabled = true;
                editSetButton.Enabled = true;
                removeSetButton.Enabled = true;
            }
            else
            {
                articlesGroupBox.Enabled = false;
                tipLabel.Enabled = false;
                addWordButton.Enabled = false;
                editWordButton.Enabled = false;
                deleteWordButton.Enabled = false;
                wordsListView.Enabled = false;
                editSetButton.Enabled = false;
                removeSetButton.Enabled = false;
            }
        }

        /// <summary>
        /// DICTIONARY CONTROLS
        /// </summary>
        private void LaunchCreateOrEditSetWindow(object sender)
        {
            bool isNewSet = true;
            if (sender == editSetButton)
            {
                isNewSet = false;  
                if (setsListBox.SelectedItem == null)
                {
                    MessageBox.Show("Nie wybrano zestawu do edycji!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            DictionarySet selectedSet = (DictionarySet)setsListBox.SelectedItem;
            string name = selectedSet.Name;
            var setName = new SetEditWindow(this, isNewSet, name);
            setName.Show();
        }

        private void editWordButton_Click(object sender, EventArgs e)
        {
            EditOrDeleteWord(sender);
        }

        private void deleteWordButton_Click(object sender, EventArgs e)
        {
            EditOrDeleteWord(sender);
        }

        private void wordsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // alphabetical sort of selected set's wordlist by column
            if (currentSet != null)
            {
                int columnIndex = e.Column;
                currentSet.SortWordList(columnIndex);
                UpdateWordList();
            }
        }

        private void nounCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWordList();
        }

        private void verbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWordList();
        }

        private void adjectiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWordList();
        }

        /// <summary>
        /// QUIZ ELEMENTS
        /// </summary> 
        private void InitializeQuiz()
        {
            // update the Quiz instance by passing a List<DictionarySet> of chosen dictionary sets for the quiz with chosen types of words
            List<DictionarySet> selectedSets = quizSetCheckedListBox.CheckedItems.Cast<DictionarySet>().ToList();
            quiz = new Quiz(selectedSets, quizNounCheckBox.Checked, quizVerbCheckBox.Checked, quizAdjectiveCheckBox.Checked);
        }

        private void UpdateQuizSets()
        {
            InitializeQuiz();
            quizWordsNumericUpDown.Maximum = quiz.NumberOfWordsAvailable;
            quizWordsNumericUpDown.Value = quiz.NumberOfWordsAvailable;
        }

        private void StartQuiz()
        {
            InitializeQuiz();
            int numberOfWords = (int)quizWordsNumericUpDown.Value;
            quiz.StartQuiz(numberOfWords, simplifiedQuizTypeRadioButton.Checked, germanPolishCheckBox.Checked, polishGermanCheckBox.Checked);
            tabControl.TabPages.Remove(dictionaryTab);
            quizProgressBar.Maximum = numberOfWords;
            quizRulesCheckBox.Enabled = false;
            UpdateQuizArticleGroupBox();
            startQuiz.Text = "Zakończ quiz";

            if (simplifiedQuizTypeRadioButton.Checked)
                simplifiedQuizPanel.Visible = true;
            else
                advancedQuizPanel.Visible = true;

            PrintAnotherWord();
        }

        private void StopQuiz()
        {
            string summary = quiz.StopQuiz();
            tabControl.TabPages.Insert(0, dictionaryTab);
            quizProgressBar.Value = 0;
            quizRulesCheckBox.Enabled = true;
            startQuiz.Text = "Rozpocznij quiz!";
            UpdateQuizSets();
            simplifiedQuizPanel.Visible = false;
            advancedQuizPanel.Visible = false;
            MessageBox.Show(summary, "Quiz zakończony", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void CheckTheWord(string buttonText)
        {
            if (simplifiedQuizPanel.Visible)
            {
                quiz.CheckTheWord(buttonText, CheckSelectedQuizArticleRadioButton());
            }
            else
            {
                quiz.CheckTheWord(buttonText);
            }

            if (quiz.WordCount < (int)quizWordsNumericUpDown.Value)
            {
                PrintAnotherWord();
                quizProgressBar.Increment(1);
            }
            else
            {
                advancedQuizPanel.Visible = false;
                simplifiedQuizPanel.Visible = false;
                StopQuiz();
            }
        }

        private void PrintAnotherWord()
        {
            if (simplifiedQuizTypeRadioButton.Checked)
            {
                Queue<string> wordList = quiz.PickAWord_Simplified();
                UpdateQuizArticleGroupBox();
                quizWordLabel.Text = wordList.Dequeue();
                simplifiedQuizButton1.Text = wordList.Dequeue();
                simplifiedQuizButton2.Text = wordList.Dequeue();
                simplifiedQuizButton3.Text = wordList.Dequeue();
            }
            else
            {
                advancedQuizWordLabel.Text = quiz.PickAWord_Advanced();
                advancedQuizWordTextBox.Text = "";
            }
        }

        public string CheckIfWordAlreadyCreated(string germanTranslation, string polishTranslation)
        {
            foreach (DictionarySet ds in dictionarySets)
            {
                if (ds.CheckIfWordAlreadyCreated(germanTranslation, polishTranslation))
                    return ds.Name;
            }
            return "";
        }

        private void UpdateQuizArticleGroupBox()
        {
            bool isANoun = quiz.CheckIfCurrentWordIsANounAndTranslatedFromPolish();
            if (isANoun)
                simplifiedQuizArticleGroupBox.Visible = true;
            else
                simplifiedQuizArticleGroupBox.Visible = false;

            simplifiedQuizArticleRadioButton_der.Checked = false;
            simplifiedQuizArticleRadioButton_die.Checked = false;
            simplifiedQuizRadioButton_das.Checked = false;
        }

        private Article CheckSelectedQuizArticleRadioButton()
        {
            if (simplifiedQuizArticleRadioButton_der.Checked)
                return Article.der;
            else if (simplifiedQuizArticleRadioButton_die.Checked)
                return Article.die;
            else if (simplifiedQuizRadioButton_das.Checked)
                return Article.das;
            return Article.notSet;
        }

        /// <summary>
        /// QUIZ CONTROLS
        /// </summary>
        private void startQuiz_Click(object sender, EventArgs e)
        {
            // handling quiz start and quiz end events
            if (quiz.NumberOfWordsAvailable >= 10)
            {
                bool gameOn = quiz.QuizOn;
                if (!gameOn)
                {
                    StartQuiz();
                }
                else
                {
                    StopQuiz();
                }
            }
            else
            {
                if (setsListBox.Items.Count == 0)
                    MessageBox.Show("Do słownika nie dodano żadnych zestawów.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("W zaznaczonych zestawach musi znajdować się w sumie co najmniej 10 słów.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
        }

        private void quizSetCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // invoked method: check/uncheck event first, then update quiz selected sets
            // and check whether startQuiz button should be enabled
            this.BeginInvoke((MethodInvoker)(
           () =>
           {
               if (quizSetCheckedListBox.CheckedItems.Count == 0)
               {
                   startQuiz.Enabled = false;
               }
               else
               {
                   startQuiz.Enabled = true;     
               }
               UpdateQuizSets();
           }
           ));  
        }  

        private void quizNounCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateQuizSets();
        }

        private void quizVerbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateQuizSets();
        }

        private void quizAdjectiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateQuizSets();
        }

        private void germanPolishCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // at least one checkbox must be checked: if current is being unchecked and other is uncheck aswell,
            // check the other one
            if (!germanPolishCheckBox.Checked)
                if (!polishGermanCheckBox.Checked)
                    polishGermanCheckBox.Checked = true;
        }

        private void polishGermanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // at least one checkbox must be checked: if current is being unchecked and other is uncheck aswell,
            // check the other one
            if (!polishGermanCheckBox.Checked)
                if (!germanPolishCheckBox.Checked)
                    germanPolishCheckBox.Checked = true;
        }

        private void simplifiedQuizButton1_Click(object sender, EventArgs e)
        {
            CheckTheWord(((Button)sender).Text);
        }

        private void simplifiedQuizButton2_Click(object sender, EventArgs e)
        {
            CheckTheWord(((Button)sender).Text);
        }

        private void simplifiedQuizButton3_Click(object sender, EventArgs e)
        {
            CheckTheWord(((Button)sender).Text);
        }

        private void setCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModificationDate();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == quizTab)
                UpdateQuizSets();  
        }

        private void advancedQuizCheckButton_Click(object sender, EventArgs e)
        {
            CheckTheWord(advancedQuizWordTextBox.Text);
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "ä";
        }

        private void aUpperButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "Ä";
        }

        private void oButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "ö";
        }

        private void oUpperButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "Ö";
        }

        private void uButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "ü";
        }

        private void uUpperButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "Ü";
        }

        private void ssButton_Click(object sender, EventArgs e)
        {
            advancedQuizWordTextBox.Text += "ß";
        }

        private void setsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setsListBox.Items.Count > 0)
            {
                currentSet = (DictionarySet)setsListBox.SelectedItem;
                UpdateWordList();
            }
            UpdateControlState();
        }
    }
}
