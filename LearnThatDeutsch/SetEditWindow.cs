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
    public partial class SetEditWindow : Form
    {
        bool isNewSet;
        MainWindow mainWindow;

        public SetEditWindow(MainWindow mainWindow, bool isNewSet, string setName)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;

            if (isNewSet)
            {
                this.Text = "Nowy zestaw";
                this.setButton.Text = "Utwórz";
            }
            else
            {
                this.Text = "Edytuj zestaw";
                this.setButton.Text = "Zapisz";
                this.setNameTextBox.Text = setName;
            }

            this.isNewSet = isNewSet;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            mainWindow.CreateOrEditSet(isNewSet, setNameTextBox.Text);
            this.Close();
        }
    }
}
