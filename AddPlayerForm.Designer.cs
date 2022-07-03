namespace TeamOfPlayers
{
    partial class AddPlayerForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSport = new System.Windows.Forms.TextBox();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Виды спорта";
            // 
            // textBoxSport
            // 
            this.textBoxSport.Location = new System.Drawing.Point(179, 122);
            this.textBoxSport.Name = "textBoxSport";
            this.textBoxSport.Size = new System.Drawing.Size(100, 20);
            this.textBoxSport.TabIndex = 27;
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.AutoSize = true;
            this.AddPlayerButton.Location = new System.Drawing.Point(100, 168);
            this.AddPlayerButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(100, 23);
            this.AddPlayerButton.TabIndex = 8;
            this.AddPlayerButton.Text = "Добавить";
            this.AddPlayerButton.UseVisualStyleBackColor = true;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Фамилия Имя Отчество";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(179, 44);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(100, 20);
            this.textBoxFIO.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Дата рождения";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(179, 80);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxDate.TabIndex = 30;
            // 
            // AddPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 221);
            this.Controls.Add(this.AddPlayerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFIO);
            this.Name = "AddPlayerForm";
            this.Text = "Добавить игрока";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSport;
        private System.Windows.Forms.Button AddPlayerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDate;
    }
}