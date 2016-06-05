namespace LearnThatDeutsch
{
    partial class SetEditWindow
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
            this.setNameTextBox = new System.Windows.Forms.TextBox();
            this.setNameLabel = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setNameTextBox
            // 
            this.setNameTextBox.Location = new System.Drawing.Point(12, 35);
            this.setNameTextBox.Name = "setNameTextBox";
            this.setNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.setNameTextBox.TabIndex = 0;
            // 
            // setNameLabel
            // 
            this.setNameLabel.AutoSize = true;
            this.setNameLabel.Location = new System.Drawing.Point(9, 19);
            this.setNameLabel.Name = "setNameLabel";
            this.setNameLabel.Size = new System.Drawing.Size(40, 13);
            this.setNameLabel.TabIndex = 1;
            this.setNameLabel.Text = "Nazwa";
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(12, 64);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(94, 25);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Utwórz";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(112, 64);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SetEditWindow
            // 
            this.AcceptButton = this.setButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(194, 101);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.setNameLabel);
            this.Controls.Add(this.setNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetEditWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nowy zestaw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox setNameTextBox;
        private System.Windows.Forms.Label setNameLabel;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button cancelButton;
    }
}