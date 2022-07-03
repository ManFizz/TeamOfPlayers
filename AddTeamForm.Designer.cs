namespace TeamOfPlayers
{
    partial class AddTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTeamForm));
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSport2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.textBoxTeam = new System.Windows.Forms.TextBox();
            this.textBoxFIO2 = new System.Windows.Forms.TextBox();
            this.AddPlayerButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Вид спорта";
            // 
            // textBoxSport2
            // 
            this.textBoxSport2.Location = new System.Drawing.Point(167, 144);
            this.textBoxSport2.Name = "textBoxSport2";
            this.textBoxSport2.Size = new System.Drawing.Size(100, 20);
            this.textBoxSport2.TabIndex = 32;
            this.textBoxSport2.TextChanged += new System.EventHandler(this.textBoxSport2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Роль";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Команда";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Фамилия Имя Отчество";
            // 
            // textBoxRole
            // 
            this.textBoxRole.Location = new System.Drawing.Point(167, 107);
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.Size = new System.Drawing.Size(100, 20);
            this.textBoxRole.TabIndex = 27;
            this.textBoxRole.TextChanged += new System.EventHandler(this.textBoxRole_TextChanged);
            // 
            // textBoxTeam
            // 
            this.textBoxTeam.Location = new System.Drawing.Point(167, 73);
            this.textBoxTeam.Name = "textBoxTeam";
            this.textBoxTeam.Size = new System.Drawing.Size(100, 20);
            this.textBoxTeam.TabIndex = 26;
            this.textBoxTeam.TextChanged += new System.EventHandler(this.textBoxTeam_TextChanged);
            // 
            // textBoxFIO2
            // 
            this.textBoxFIO2.Location = new System.Drawing.Point(167, 34);
            this.textBoxFIO2.Name = "textBoxFIO2";
            this.textBoxFIO2.Size = new System.Drawing.Size(100, 20);
            this.textBoxFIO2.TabIndex = 25;
            this.textBoxFIO2.TextChanged += new System.EventHandler(this.textBoxFIO2_TextChanged);
            // 
            // AddPlayerButton2
            // 
            this.AddPlayerButton2.Location = new System.Drawing.Point(106, 176);
            this.AddPlayerButton2.Name = "AddPlayerButton2";
            this.AddPlayerButton2.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerButton2.TabIndex = 8;
            this.AddPlayerButton2.Text = "Добавить";
            this.AddPlayerButton2.UseVisualStyleBackColor = true;
            this.AddPlayerButton2.Click += new System.EventHandler(this.AddPlayerButton2_Click);
            // 
            // AddTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 221);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSport2);
            this.Controls.Add(this.AddPlayerButton2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxFIO2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxRole);
            this.Controls.Add(this.textBoxTeam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddTeamForm";
            this.Text = "Добавить игрока команды";
            this.Load += new System.EventHandler(this.AddTeamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSport2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRole;
        private System.Windows.Forms.TextBox textBoxTeam;
        private System.Windows.Forms.TextBox textBoxFIO2;
        private System.Windows.Forms.Button AddPlayerButton2;
    }
}