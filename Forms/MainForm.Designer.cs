using System.Windows.Forms;

namespace TeamOfPlayers.Forms
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._playerDisplay = new System.Data.DataTable();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this._teamDisplay = new System.Data.DataTable();
            this.DeletePlayerButton = new System.Windows.Forms.Button();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.textBoxRole2 = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.LabelAge = new System.Windows.Forms.Label();
            this.LableRole = new System.Windows.Forms.Label();
            this.ReportPanel = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.ClearPlayerButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchPlayer = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.ClearTeamButton = new System.Windows.Forms.Button();
            this.SearchButton2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSearchTeam2 = new System.Windows.Forms.TextBox();
            this.textBoxSearchTeam1 = new System.Windows.Forms.TextBox();
            this.DeleteTeamButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SavePalyersButton = new System.Windows.Forms.Button();
            this.SaveTeamsButton = new System.Windows.Forms.Button();
            this.SaveReportButton = new System.Windows.Forms.Button();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.LoadFilePlayersButton = new System.Windows.Forms.Button();
            this.LoadFileTeamsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DevButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this._playerDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this._teamDisplay)).BeginInit();
            this.ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(30, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(365, 380);
            this.dataGridView1.TabIndex = 6;
            // 
            // _playerDisplay
            // 
            this._playerDisplay.TableName = "Таблица игроков";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(447, 40);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(365, 380);
            this.dataGridView2.TabIndex = 7;
            // 
            // _teamDisplay
            // 
            this._teamDisplay.TableName = "Таблица игроков команды";
            // 
            // DeletePlayerButton
            // 
            this.DeletePlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.DeletePlayerButton.ForeColor = System.Drawing.Color.Red;
            this.DeletePlayerButton.Location = new System.Drawing.Point(243, 17);
            this.DeletePlayerButton.Name = "DeletePlayerButton";
            this.DeletePlayerButton.Size = new System.Drawing.Size(115, 23);
            this.DeletePlayerButton.TabIndex = 9;
            this.DeletePlayerButton.Text = "Удалить найденое";
            this.DeletePlayerButton.UseVisualStyleBackColor = false;
            this.DeletePlayerButton.Click += new System.EventHandler(this.DeletePlayerButton_Click);
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(246, 39);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(103, 23);
            this.GenerateReportButton.TabIndex = 11;
            this.GenerateReportButton.Text = "Создать отчет";
            this.GenerateReportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GenerateReportButton.UseVisualStyleBackColor = true;
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // textBoxRole2
            // 
            this.textBoxRole2.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRole2.Location = new System.Drawing.Point(128, 41);
            this.textBoxRole2.Name = "textBoxRole2";
            this.textBoxRole2.Size = new System.Drawing.Size(100, 20);
            this.textBoxRole2.TabIndex = 16;
            this.textBoxRole2.Tag = "Поиск";
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(6, 39);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(100, 20);
            this.textBoxAge.TabIndex = 17;
            // 
            // LabelAge
            // 
            this.LabelAge.AutoSize = true;
            this.LabelAge.Location = new System.Drawing.Point(3, 23);
            this.LabelAge.Name = "LabelAge";
            this.LabelAge.Size = new System.Drawing.Size(49, 13);
            this.LabelAge.TabIndex = 19;
            this.LabelAge.Text = "Возраст";
            // 
            // LableRole
            // 
            this.LableRole.AutoSize = true;
            this.LableRole.Location = new System.Drawing.Point(125, 23);
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
            this.ReportPanel.Controls.Add(this.textBoxAge);
            this.ReportPanel.Controls.Add(this.textBoxRole2);
            this.ReportPanel.Controls.Add(this.GenerateReportButton);
            this.ReportPanel.Location = new System.Drawing.Point(867, 429);
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
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView3.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView3.Location = new System.Drawing.Point(867, 40);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(365, 380);
            this.dataGridView3.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ClearPlayerButton);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxSearchPlayer);
            this.panel1.Controls.Add(this.DeletePlayerButton);
            this.panel1.Location = new System.Drawing.Point(30, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 98);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(22, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "*Поиск ищет полное совпадение и чувствителен к регистру";
            // 
            // ClearPlayerButton
            // 
            this.ClearPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.ClearPlayerButton.Location = new System.Drawing.Point(243, 46);
            this.ClearPlayerButton.Name = "ClearPlayerButton";
            this.ClearPlayerButton.Size = new System.Drawing.Size(115, 23);
            this.ClearPlayerButton.TabIndex = 31;
            this.ClearPlayerButton.Text = "Обновить таблицу";
            this.ClearPlayerButton.UseVisualStyleBackColor = false;
            this.ClearPlayerButton.Click += new System.EventHandler(this.ClearSearchButton1_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(155, 31);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 30;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "ФИО";
            // 
            // textBoxSearchPlayer
            // 
            this.textBoxSearchPlayer.Location = new System.Drawing.Point(49, 33);
            this.textBoxSearchPlayer.Name = "textBoxSearchPlayer";
            this.textBoxSearchPlayer.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchPlayer.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.ClearTeamButton);
            this.panel2.Controls.Add(this.SearchButton2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxSearchTeam2);
            this.panel2.Controls.Add(this.textBoxSearchTeam1);
            this.panel2.Controls.Add(this.DeleteTeamButton);
            this.panel2.Location = new System.Drawing.Point(447, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 98);
            this.panel2.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(19, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(311, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "*Поиск ищет полное совпадение и чувствителен к регистру";
            // 
            // ClearTeamButton
            // 
            this.ClearTeamButton.BackColor = System.Drawing.Color.Transparent;
            this.ClearTeamButton.Location = new System.Drawing.Point(246, 46);
            this.ClearTeamButton.Name = "ClearTeamButton";
            this.ClearTeamButton.Size = new System.Drawing.Size(110, 23);
            this.ClearTeamButton.TabIndex = 31;
            this.ClearTeamButton.Text = "Обновить таблицу";
            this.ClearTeamButton.UseVisualStyleBackColor = false;
            this.ClearTeamButton.Click += new System.EventHandler(this.ClearButton2_Click);
            // 
            // SearchButton2
            // 
            this.SearchButton2.Location = new System.Drawing.Point(158, 33);
            this.SearchButton2.Name = "SearchButton2";
            this.SearchButton2.Size = new System.Drawing.Size(75, 23);
            this.SearchButton2.TabIndex = 30;
            this.SearchButton2.Text = "Поиск";
            this.SearchButton2.UseVisualStyleBackColor = true;
            this.SearchButton2.Click += new System.EventHandler(this.SearchButton2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Команда";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "ФИО";
            // 
            // textBoxSearchTeam2
            // 
            this.textBoxSearchTeam2.Location = new System.Drawing.Point(72, 49);
            this.textBoxSearchTeam2.Name = "textBoxSearchTeam2";
            this.textBoxSearchTeam2.Size = new System.Drawing.Size(80, 20);
            this.textBoxSearchTeam2.TabIndex = 26;
            // 
            // textBoxSearchTeam1
            // 
            this.textBoxSearchTeam1.Location = new System.Drawing.Point(72, 23);
            this.textBoxSearchTeam1.Name = "textBoxSearchTeam1";
            this.textBoxSearchTeam1.Size = new System.Drawing.Size(80, 20);
            this.textBoxSearchTeam1.TabIndex = 25;
            // 
            // DeleteTeamButton
            // 
            this.DeleteTeamButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteTeamButton.ForeColor = System.Drawing.Color.Red;
            this.DeleteTeamButton.Location = new System.Drawing.Point(246, 17);
            this.DeleteTeamButton.Name = "DeleteTeamButton";
            this.DeleteTeamButton.Size = new System.Drawing.Size(110, 23);
            this.DeleteTeamButton.TabIndex = 9;
            this.DeleteTeamButton.Text = "Удалить найденое";
            this.DeleteTeamButton.UseVisualStyleBackColor = false;
            this.DeleteTeamButton.Click += new System.EventHandler(this.DeletePlayerButton2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label10.Location = new System.Drawing.Point(25, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(235, 29);
            this.label10.TabIndex = 27;
            this.label10.Text = "Справочник \"Игроки\"";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label11.Location = new System.Drawing.Point(442, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(318, 29);
            this.label11.TabIndex = 28;
            this.label11.Text = "Справочник \"Игроки команд\"";
            // 
            // SavePalyersButton
            // 
            this.SavePalyersButton.Location = new System.Drawing.Point(315, 533);
            this.SavePalyersButton.Name = "SavePalyersButton";
            this.SavePalyersButton.Size = new System.Drawing.Size(75, 23);
            this.SavePalyersButton.TabIndex = 29;
            this.SavePalyersButton.Text = " Сохранить";
            this.SavePalyersButton.UseVisualStyleBackColor = true;
            this.SavePalyersButton.Click += new System.EventHandler(this.SavePlayersButton_Click);
            // 
            // SaveTeamsButton
            // 
            this.SaveTeamsButton.Location = new System.Drawing.Point(730, 533);
            this.SaveTeamsButton.Name = "SaveTeamsButton";
            this.SaveTeamsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveTeamsButton.TabIndex = 30;
            this.SaveTeamsButton.Text = " Сохранить";
            this.SaveTeamsButton.UseVisualStyleBackColor = true;
            this.SaveTeamsButton.Click += new System.EventHandler(this.SaveTeamsButton_Click);
            // 
            // SaveReportButton
            // 
            this.SaveReportButton.Location = new System.Drawing.Point(1022, 525);
            this.SaveReportButton.Name = "SaveReportButton";
            this.SaveReportButton.Size = new System.Drawing.Size(75, 23);
            this.SaveReportButton.TabIndex = 31;
            this.SaveReportButton.Text = " Сохранить";
            this.SaveReportButton.UseVisualStyleBackColor = true;
            this.SaveReportButton.Click += new System.EventHandler(this.SaveReportButton_Click);
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.AddPlayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddPlayerButton.Location = new System.Drawing.Point(41, 533);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerButton.TabIndex = 32;
            this.AddPlayerButton.Text = "Добавить";
            this.AddPlayerButton.UseVisualStyleBackColor = false;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.BackColor = System.Drawing.Color.Transparent;
            this.AddTeamButton.Location = new System.Drawing.Point(459, 533);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(75, 23);
            this.AddTeamButton.TabIndex = 33;
            this.AddTeamButton.Text = "Добавить";
            this.AddTeamButton.UseVisualStyleBackColor = false;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // LoadFilePlayersButton
            // 
            this.LoadFilePlayersButton.Location = new System.Drawing.Point(234, 533);
            this.LoadFilePlayersButton.Name = "LoadFilePlayersButton";
            this.LoadFilePlayersButton.Size = new System.Drawing.Size(75, 23);
            this.LoadFilePlayersButton.TabIndex = 34;
            this.LoadFilePlayersButton.Text = "Загрузить";
            this.LoadFilePlayersButton.UseVisualStyleBackColor = true;
            this.LoadFilePlayersButton.Click += new System.EventHandler(this.LoadFilePlayersButton_Click);
            // 
            // LoadFileTeamsButton
            // 
            this.LoadFileTeamsButton.Location = new System.Drawing.Point(649, 533);
            this.LoadFileTeamsButton.Name = "LoadFileTeamsButton";
            this.LoadFileTeamsButton.Size = new System.Drawing.Size(75, 23);
            this.LoadFileTeamsButton.TabIndex = 35;
            this.LoadFileTeamsButton.Text = "Загрузить";
            this.LoadFileTeamsButton.UseVisualStyleBackColor = true;
            this.LoadFileTeamsButton.Click += new System.EventHandler(this.LoadFileTeamsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(25, 616);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "*Проверка при чтении из файла отключена - люыбе изменения с данными должны провод" + "ится через интерфейс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label3.Location = new System.Drawing.Point(867, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 29);
            this.label3.TabIndex = 36;
            this.label3.Text = "Отчёт \"Кандидаты\"";
            // 
            // DevButton
            // 
            this.DevButton.BackColor = System.Drawing.SystemColors.Control;
            this.DevButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.DevButton.Location = new System.Drawing.Point(1217, 611);
            this.DevButton.Name = "DevButton";
            this.DevButton.Size = new System.Drawing.Size(35, 23);
            this.DevButton.TabIndex = 37;
            this.DevButton.Text = "Dev";
            this.DevButton.UseVisualStyleBackColor = false;
            this.DevButton.Click += new System.EventHandler(this.DevButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1264, 641);
            this.Controls.Add(this.DevButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoadFileTeamsButton);
            this.Controls.Add(this.LoadFilePlayersButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.AddPlayerButton);
            this.Controls.Add(this.SaveReportButton);
            this.Controls.Add(this.SaveTeamsButton);
            this.Controls.Add(this.SavePalyersButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.ReportPanel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 680);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this._playerDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this._teamDisplay)).EndInit();
            this.ReportPanel.ResumeLayout(false);
            this.ReportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button DevButton;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button LoadFilePlayersButton;
        private System.Windows.Forms.Button LoadFileTeamsButton;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button DeletePlayerButton;
        private System.Windows.Forms.Button GenerateReportButton;
        private System.Windows.Forms.TextBox textBoxRole2;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label LabelAge;
        private System.Windows.Forms.Label LableRole;
        private System.Windows.Forms.Panel ReportPanel;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSearchPlayer;
        private Button SearchButton;
        private Label label1;
        private System.Windows.Forms.Button ClearPlayerButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ClearTeamButton;
        private System.Windows.Forms.Button SearchButton2;
        private Label label5;
        private Label label6;
        private TextBox textBoxSearchTeam2;
        private TextBox textBoxSearchTeam1;
        private System.Windows.Forms.Button DeleteTeamButton;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private System.Windows.Forms.Button SavePalyersButton;
        private Button SaveTeamsButton;
        private System.Windows.Forms.Button SaveReportButton;
        private System.Windows.Forms.Button AddPlayerButton;
        private System.Windows.Forms.Button AddTeamButton;
    }
}

