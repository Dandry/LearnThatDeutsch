namespace LearnThatDeutsch
{
    partial class WordEditWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.niemieckieTlumaczenieLabel = new System.Windows.Forms.Label();
            this.polskieTlumaczenieLabel = new System.Windows.Forms.Label();
            this.articleComboBox = new System.Windows.Forms.ComboBox();
            this.germanTranslationTextBox = new System.Windows.Forms.TextBox();
            this.polishTranslationTextBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.wordTypeComboBox = new System.Windows.Forms.ComboBox();
            this.typSlowaLabel = new System.Windows.Forms.Label();
            this.aButton = new System.Windows.Forms.Button();
            this.aUpperButton = new System.Windows.Forms.Button();
            this.oButton = new System.Windows.Forms.Button();
            this.oUpperButton = new System.Windows.Forms.Button();
            this.uButton = new System.Windows.Forms.Button();
            this.uUpperButton = new System.Windows.Forms.Button();
            this.ssButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // niemieckieTlumaczenieLabel
            // 
            this.niemieckieTlumaczenieLabel.AutoSize = true;
            this.niemieckieTlumaczenieLabel.Location = new System.Drawing.Point(15, 61);
            this.niemieckieTlumaczenieLabel.Name = "niemieckieTlumaczenieLabel";
            this.niemieckieTlumaczenieLabel.Size = new System.Drawing.Size(120, 13);
            this.niemieckieTlumaczenieLabel.TabIndex = 0;
            this.niemieckieTlumaczenieLabel.Text = "Niemieckie tłumaczenie";
            // 
            // polskieTlumaczenieLabel
            // 
            this.polskieTlumaczenieLabel.AutoSize = true;
            this.polskieTlumaczenieLabel.Location = new System.Drawing.Point(15, 143);
            this.polskieTlumaczenieLabel.Name = "polskieTlumaczenieLabel";
            this.polskieTlumaczenieLabel.Size = new System.Drawing.Size(102, 13);
            this.polskieTlumaczenieLabel.TabIndex = 1;
            this.polskieTlumaczenieLabel.Text = "Polskie tłumaczenie";
            // 
            // articleComboBox
            // 
            this.articleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.articleComboBox.FormattingEnabled = true;
            this.articleComboBox.Items.AddRange(new object[] {
            "der",
            "die",
            "das"});
            this.articleComboBox.Location = new System.Drawing.Point(18, 78);
            this.articleComboBox.Name = "articleComboBox";
            this.articleComboBox.Size = new System.Drawing.Size(54, 21);
            this.articleComboBox.TabIndex = 2;
            // 
            // germanTranslationTextBox
            // 
            this.germanTranslationTextBox.Location = new System.Drawing.Point(78, 78);
            this.germanTranslationTextBox.Name = "germanTranslationTextBox";
            this.germanTranslationTextBox.Size = new System.Drawing.Size(127, 20);
            this.germanTranslationTextBox.TabIndex = 3;
            // 
            // polishTranslationTextBox
            // 
            this.polishTranslationTextBox.Location = new System.Drawing.Point(18, 159);
            this.polishTranslationTextBox.Name = "polishTranslationTextBox";
            this.polishTranslationTextBox.Size = new System.Drawing.Size(187, 20);
            this.polishTranslationTextBox.TabIndex = 4;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(18, 192);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(105, 25);
            this.setButton.TabIndex = 5;
            this.setButton.Text = "Zapisz";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(129, 192);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 25);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // wordTypeComboBox
            // 
            this.wordTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wordTypeComboBox.FormattingEnabled = true;
            this.wordTypeComboBox.Items.AddRange(new object[] {
            "rzeczownik",
            "czasownik",
            "przymiotnik"});
            this.wordTypeComboBox.Location = new System.Drawing.Point(81, 26);
            this.wordTypeComboBox.Name = "wordTypeComboBox";
            this.wordTypeComboBox.Size = new System.Drawing.Size(124, 21);
            this.wordTypeComboBox.TabIndex = 7;
            this.wordTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.wordTypeComboBox_SelectedIndexChanged);
            // 
            // typSlowaLabel
            // 
            this.typSlowaLabel.AutoSize = true;
            this.typSlowaLabel.Location = new System.Drawing.Point(15, 29);
            this.typSlowaLabel.Name = "typSlowaLabel";
            this.typSlowaLabel.Size = new System.Drawing.Size(60, 13);
            this.typSlowaLabel.TabIndex = 8;
            this.typSlowaLabel.Text = "Typ słowa:";
            // 
            // aButton
            // 
            this.aButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aButton.Location = new System.Drawing.Point(18, 106);
            this.aButton.Name = "aButton";
            this.aButton.Size = new System.Drawing.Size(25, 23);
            this.aButton.TabIndex = 9;
            this.aButton.Text = "ä";
            this.aButton.UseVisualStyleBackColor = true;
            this.aButton.Click += new System.EventHandler(this.aButton_Click);
            // 
            // aUpperButton
            // 
            this.aUpperButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aUpperButton.Location = new System.Drawing.Point(45, 106);
            this.aUpperButton.Name = "aUpperButton";
            this.aUpperButton.Size = new System.Drawing.Size(25, 23);
            this.aUpperButton.TabIndex = 10;
            this.aUpperButton.Text = "Ä";
            this.aUpperButton.UseVisualStyleBackColor = true;
            this.aUpperButton.Click += new System.EventHandler(this.aUpperButton_Click);
            // 
            // oButton
            // 
            this.oButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oButton.Location = new System.Drawing.Point(72, 106);
            this.oButton.Name = "oButton";
            this.oButton.Size = new System.Drawing.Size(25, 23);
            this.oButton.TabIndex = 11;
            this.oButton.Text = "ö";
            this.oButton.UseVisualStyleBackColor = true;
            this.oButton.Click += new System.EventHandler(this.oButton_Click);
            // 
            // oUpperButton
            // 
            this.oUpperButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oUpperButton.Location = new System.Drawing.Point(99, 106);
            this.oUpperButton.Name = "oUpperButton";
            this.oUpperButton.Size = new System.Drawing.Size(25, 23);
            this.oUpperButton.TabIndex = 12;
            this.oUpperButton.Text = "Ö";
            this.oUpperButton.UseVisualStyleBackColor = true;
            this.oUpperButton.Click += new System.EventHandler(this.oUpperButton_Click);
            // 
            // uButton
            // 
            this.uButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uButton.Location = new System.Drawing.Point(126, 106);
            this.uButton.Name = "uButton";
            this.uButton.Size = new System.Drawing.Size(25, 23);
            this.uButton.TabIndex = 13;
            this.uButton.Text = "ü";
            this.uButton.UseVisualStyleBackColor = true;
            this.uButton.Click += new System.EventHandler(this.uButton_Click);
            // 
            // uUpperButton
            // 
            this.uUpperButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uUpperButton.Location = new System.Drawing.Point(153, 106);
            this.uUpperButton.Name = "uUpperButton";
            this.uUpperButton.Size = new System.Drawing.Size(25, 23);
            this.uUpperButton.TabIndex = 14;
            this.uUpperButton.Text = "Ü";
            this.uUpperButton.UseVisualStyleBackColor = true;
            this.uUpperButton.Click += new System.EventHandler(this.uUpperButton_Click);
            // 
            // ssButton
            // 
            this.ssButton.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ssButton.Location = new System.Drawing.Point(180, 106);
            this.ssButton.Name = "ssButton";
            this.ssButton.Size = new System.Drawing.Size(25, 23);
            this.ssButton.TabIndex = 15;
            this.ssButton.Text = "ß";
            this.ssButton.UseVisualStyleBackColor = true;
            this.ssButton.Click += new System.EventHandler(this.ssButton_Click);
            // 
            // WordEditWindow
            // 
            this.AcceptButton = this.setButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(223, 229);
            this.Controls.Add(this.ssButton);
            this.Controls.Add(this.uUpperButton);
            this.Controls.Add(this.uButton);
            this.Controls.Add(this.oUpperButton);
            this.Controls.Add(this.oButton);
            this.Controls.Add(this.aUpperButton);
            this.Controls.Add(this.aButton);
            this.Controls.Add(this.typSlowaLabel);
            this.Controls.Add(this.wordTypeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.polishTranslationTextBox);
            this.Controls.Add(this.germanTranslationTextBox);
            this.Controls.Add(this.articleComboBox);
            this.Controls.Add(this.polskieTlumaczenieLabel);
            this.Controls.Add(this.niemieckieTlumaczenieLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WordEditWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj słowo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label niemieckieTlumaczenieLabel;
        private System.Windows.Forms.Label polskieTlumaczenieLabel;
        private System.Windows.Forms.ComboBox articleComboBox;
        private System.Windows.Forms.TextBox germanTranslationTextBox;
        private System.Windows.Forms.TextBox polishTranslationTextBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox wordTypeComboBox;
        private System.Windows.Forms.Label typSlowaLabel;
        private System.Windows.Forms.Button aButton;
        private System.Windows.Forms.Button aUpperButton;
        private System.Windows.Forms.Button oButton;
        private System.Windows.Forms.Button oUpperButton;
        private System.Windows.Forms.Button uButton;
        private System.Windows.Forms.Button uUpperButton;
        private System.Windows.Forms.Button ssButton;
    }
}