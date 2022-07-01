using System;
using System.Data;
using System.Windows.Forms;

namespace TeamOfPlayers
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._playerTable = new System.Data.DataTable();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this._teamDataTable = new System.Data.DataTable();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.DeletePlayerButton = new System.Windows.Forms.Button();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.textBoxRole2 = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.LabelReport = new System.Windows.Forms.Label();
            this.LabelAge = new System.Windows.Forms.Label();
            this.LableRole = new System.Windows.Forms.Label();
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSport = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuccesLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSport2 = new System.Windows.Forms.TextBox();
            this.ClearButton2 = new System.Windows.Forms.Button();
            this.SearchButton2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRole = new System.Windows.Forms.TextBox();
            this.textBoxTeam = new System.Windows.Forms.TextBox();
            this.textBoxFIO2 = new System.Windows.Forms.TextBox();
            this.AddPlayerButton2 = new System.Windows.Forms.Button();
            this.DeletePlayerButton2 = new System.Windows.Forms.Button();
            this.PrintHashTableButton = new System.Windows.Forms.Button();
            this.SearchHashButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._playerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._teamDataTable)).BeginInit();
            this.ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(30, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(365, 380);
            this.dataGridView1.TabIndex = 6;
            // 
            // _playerTable
            // 
            this._playerTable.TableName = "Таблица игроков";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(865, 40);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(365, 380);
            this.dataGridView2.TabIndex = 7;
            // 
            // _teamDataTable
            // 
            this._teamDataTable.TableName = "Таблица игроков команды";
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.Location = new System.Drawing.Point(12, 56);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerButton.TabIndex = 8;
            this.AddPlayerButton.Text = "Добавить";
            this.AddPlayerButton.UseVisualStyleBackColor = true;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // DeletePlayerButton
            // 
            this.DeletePlayerButton.Location = new System.Drawing.Point(93, 56);
            this.DeletePlayerButton.Name = "DeletePlayerButton";
            this.DeletePlayerButton.Size = new System.Drawing.Size(75, 23);
            this.DeletePlayerButton.TabIndex = 9;
            this.DeletePlayerButton.Text = "Удалить";
            this.DeletePlayerButton.UseVisualStyleBackColor = true;
            this.DeletePlayerButton.Click += new System.EventHandler(this.DeletePlayerButton_Click);
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(267, 55);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateReportButton.TabIndex = 11;
            this.GenerateReportButton.Text = "Создать отчет";
            this.GenerateReportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GenerateReportButton.UseVisualStyleBackColor = true;
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // textBoxRole2
            // 
            this.textBoxRole2.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRole2.Location = new System.Drawing.Point(133, 58);
            this.textBoxRole2.Name = "textBoxRole2";
            this.textBoxRole2.Size = new System.Drawing.Size(100, 20);
            this.textBoxRole2.TabIndex = 16;
            this.textBoxRole2.Tag = "Поиск";
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(11, 56);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(100, 20);
            this.textBoxAge.TabIndex = 17;
            // 
            // LabelReport
            // 
            this.LabelReport.AutoSize = true;
            this.LabelReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LabelReport.Location = new System.Drawing.Point(14, 12);
            this.LabelReport.Name = "LabelReport";
            this.LabelReport.Size = new System.Drawing.Size(232, 24);
            this.LabelReport.TabIndex = 18;
            this.LabelReport.Text = "Отчёт по общему поиску";
            // 
            // LabelAge
            // 
            this.LabelAge.AutoSize = true;
            this.LabelAge.Location = new System.Drawing.Point(8, 40);
            this.LabelAge.Name = "LabelAge";
            this.LabelAge.Size = new System.Drawing.Size(49, 13);
            this.LabelAge.TabIndex = 19;
            this.LabelAge.Text = "Возраст";
            // 
            // LableRole
            // 
            this.LableRole.AutoSize = true;
            this.LableRole.Location = new System.Drawing.Point(130, 40);
            this.LableRole.Name = "LableRole";
            this.LableRole.Size = new System.Drawing.Size(32, 13);
            this.LableRole.TabIndex = 20;
            this.LableRole.Text = "Роль";
            // 
            // ReportPanel
            // 
            this.ReportPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ReportPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ReportPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ReportPanel.Controls.Add(this.LableRole);
            this.ReportPanel.Controls.Add(this.LabelAge);
            this.ReportPanel.Controls.Add(this.LabelReport);
            this.ReportPanel.Controls.Add(this.textBoxAge);
            this.ReportPanel.Controls.Add(this.textBoxRole2);
            this.ReportPanel.Controls.Add(this.GenerateReportButton);
            this.ReportPanel.Location = new System.Drawing.Point(454, 429);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(365, 90);
            this.ReportPanel.TabIndex = 21;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView3.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView3.Location = new System.Drawing.Point(454, 40);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(365, 380);
            this.dataGridView3.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxSport);
            this.panel1.Controls.Add(this.textBoxDate);
            this.panel1.Controls.Add(this.textBoxFIO);
            this.panel1.Controls.Add(this.AddPlayerButton);
            this.panel1.Controls.Add(this.DeletePlayerButton);
            this.panel1.Location = new System.Drawing.Point(30, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 90);
            this.panel1.TabIndex = 1;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(255, 56);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(103, 23);
            this.ClearButton.TabIndex = 31;
            this.ClearButton.Text = "Очистить поиск";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearSearcButton1_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(174, 56);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 30;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Виды спорта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Дата рождения";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "ФИО";
            // 
            // textBoxSport
            // 
            this.textBoxSport.Location = new System.Drawing.Point(225, 29);
            this.textBoxSport.Name = "textBoxSport";
            this.textBoxSport.Size = new System.Drawing.Size(100, 20);
            this.textBoxSport.TabIndex = 27;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(119, 29);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxDate.TabIndex = 26;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(14, 29);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(100, 20);
            this.textBoxFIO.TabIndex = 25;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(26, 564);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(198, 20);
            this.ErrorLabel.TabIndex = 23;
            this.ErrorLabel.Text = "Сообщение об ошибке";
            // 
            // SuccesLabel
            // 
            this.SuccesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SuccesLabel.AutoSize = true;
            this.SuccesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.SuccesLabel.ForeColor = System.Drawing.Color.Green;
            this.SuccesLabel.Location = new System.Drawing.Point(26, 593);
            this.SuccesLabel.Name = "SuccesLabel";
            this.SuccesLabel.Size = new System.Drawing.Size(301, 20);
            this.SuccesLabel.TabIndex = 24;
            this.SuccesLabel.Text = "Сообщение об успешной операции";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxSport2);
            this.panel2.Controls.Add(this.ClearButton2);
            this.panel2.Controls.Add(this.SearchButton2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxRole);
            this.panel2.Controls.Add(this.textBoxTeam);
            this.panel2.Controls.Add(this.textBoxFIO2);
            this.panel2.Controls.Add(this.AddPlayerButton2);
            this.panel2.Controls.Add(this.DeletePlayerButton2);
            this.panel2.Location = new System.Drawing.Point(865, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 90);
            this.panel2.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Вид спорта";
            // 
            // textBoxSport2
            // 
            this.textBoxSport2.Location = new System.Drawing.Point(255, 29);
            this.textBoxSport2.Name = "textBoxSport2";
            this.textBoxSport2.Size = new System.Drawing.Size(75, 20);
            this.textBoxSport2.TabIndex = 32;
            // 
            // ClearButton2
            // 
            this.ClearButton2.Location = new System.Drawing.Point(255, 56);
            this.ClearButton2.Name = "ClearButton2";
            this.ClearButton2.Size = new System.Drawing.Size(103, 23);
            this.ClearButton2.TabIndex = 31;
            this.ClearButton2.Text = "Очистить поиск";
            this.ClearButton2.UseVisualStyleBackColor = true;
            this.ClearButton2.Click += new System.EventHandler(this.ClearButton2_Click);
            // 
            // SearchButton2
            // 
            this.SearchButton2.Location = new System.Drawing.Point(174, 56);
            this.SearchButton2.Name = "SearchButton2";
            this.SearchButton2.Size = new System.Drawing.Size(75, 23);
            this.SearchButton2.TabIndex = 30;
            this.SearchButton2.Text = "Поиск";
            this.SearchButton2.UseVisualStyleBackColor = true;
            this.SearchButton2.Click += new System.EventHandler(this.SearchButton2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Роль";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Команда";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "ФИО";
            // 
            // textBoxRole
            // 
            this.textBoxRole.Location = new System.Drawing.Point(174, 29);
            this.textBoxRole.Name = "textBoxRole";
            this.textBoxRole.Size = new System.Drawing.Size(75, 20);
            this.textBoxRole.TabIndex = 27;
            // 
            // textBoxTeam
            // 
            this.textBoxTeam.Location = new System.Drawing.Point(93, 29);
            this.textBoxTeam.Name = "textBoxTeam";
            this.textBoxTeam.Size = new System.Drawing.Size(75, 20);
            this.textBoxTeam.TabIndex = 26;
            // 
            // textBoxFIO2
            // 
            this.textBoxFIO2.Location = new System.Drawing.Point(14, 29);
            this.textBoxFIO2.Name = "textBoxFIO2";
            this.textBoxFIO2.Size = new System.Drawing.Size(73, 20);
            this.textBoxFIO2.TabIndex = 25;
            // 
            // AddPlayerButton2
            // 
            this.AddPlayerButton2.Location = new System.Drawing.Point(12, 56);
            this.AddPlayerButton2.Name = "AddPlayerButton2";
            this.AddPlayerButton2.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerButton2.TabIndex = 8;
            this.AddPlayerButton2.Text = "Добавить";
            this.AddPlayerButton2.UseVisualStyleBackColor = true;
            this.AddPlayerButton2.Click += new System.EventHandler(this.AddPlayerButton2_Click);
            // 
            // DeletePlayerButton2
            // 
            this.DeletePlayerButton2.Location = new System.Drawing.Point(93, 56);
            this.DeletePlayerButton2.Name = "DeletePlayerButton2";
            this.DeletePlayerButton2.Size = new System.Drawing.Size(75, 23);
            this.DeletePlayerButton2.TabIndex = 9;
            this.DeletePlayerButton2.Text = "Удалить";
            this.DeletePlayerButton2.UseVisualStyleBackColor = true;
            this.DeletePlayerButton2.Click += new System.EventHandler(this.DeletePlayerButton2_Click);
            // 
            // PrintHashTableButton
            // 
            this.PrintHashTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrintHashTableButton.Location = new System.Drawing.Point(266, 525);
            this.PrintHashTableButton.Name = "PrintHashTableButton";
            this.PrintHashTableButton.Size = new System.Drawing.Size(124, 23);
            this.PrintHashTableButton.TabIndex = 27;
            this.PrintHashTableButton.Text = "Печать хеш-таблицы";
            this.PrintHashTableButton.UseVisualStyleBackColor = true;
            this.PrintHashTableButton.Click += new System.EventHandler(this.PrintHashTableButton_Click);
            // 
            // SearchHashButton
            // 
            this.SearchHashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchHashButton.Location = new System.Drawing.Point(44, 525);
            this.SearchHashButton.Name = "SearchHashButton";
            this.SearchHashButton.Size = new System.Drawing.Size(173, 23);
            this.SearchHashButton.TabIndex = 28;
            this.SearchHashButton.Text = "Поиск в хеш-таблице по ФИО";
            this.SearchHashButton.UseVisualStyleBackColor = true;
            this.SearchHashButton.Click += new System.EventHandler(this.SearchHashButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 641);
            this.Controls.Add(this.SearchHashButton);
            this.Controls.Add(this.PrintHashTableButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SuccesLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.ReportPanel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(1280, 680);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._playerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._teamDataTable)).EndInit();
            this.ReportPanel.ResumeLayout(false);
            this.ReportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button AddPlayerButton;
        private System.Windows.Forms.Button DeletePlayerButton;
        private System.Windows.Forms.Button GenerateReportButton;
        private System.Windows.Forms.TextBox textBoxRole2;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label LabelReport;
        private System.Windows.Forms.Label LabelAge;
        private System.Windows.Forms.Label LableRole;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.DataGridView dataGridView3;
        private Panel panel1;
        private TextBox textBoxSport;
        private TextBox textBoxDate;
        private TextBox textBoxFIO;
        private Button SearchButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label ErrorLabel;
        private Label SuccesLabel;
        private Button ClearButton;
        private Panel panel2;
        private Button ClearButton2;
        private Button SearchButton2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxRole;
        private TextBox textBoxTeam;
        private TextBox textBoxFIO2;
        private Button AddPlayerButton2;
        private Button DeletePlayerButton2;
        private Label label7;
        private TextBox textBoxSport2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn фИОDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn датаРожденияDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn видыСпортаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn фИОDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn командаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn рольDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn видСпортаDataGridViewTextBoxColumn;
        private Button PrintHashTableButton;
        private Button SearchHashButton;
    }
}

