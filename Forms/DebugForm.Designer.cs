using System.ComponentModel;

namespace TeamOfPlayers.Forms
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.DebugTabManager = new System.Windows.Forms.TabControl();
            this.TabPageMain = new System.Windows.Forms.TabPage();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.TabPageTreePlayers = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.TabPageTreeTeams = new System.Windows.Forms.TabPage();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.TabPageTreeTeams2 = new System.Windows.Forms.TabPage();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.TabPageHashTable = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DebugTabManager.SuspendLayout();
            this.TabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView3)).BeginInit();
            this.TabPageTreePlayers.SuspendLayout();
            this.TabPageTreeTeams.SuspendLayout();
            this.TabPageTreeTeams2.SuspendLayout();
            this.TabPageHashTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // DebugTabManager
            // 
            this.DebugTabManager.Controls.Add(this.TabPageMain);
            this.DebugTabManager.Controls.Add(this.TabPageTreePlayers);
            this.DebugTabManager.Controls.Add(this.TabPageTreeTeams);
            this.DebugTabManager.Controls.Add(this.TabPageTreeTeams2);
            this.DebugTabManager.Controls.Add(this.TabPageHashTable);
            this.DebugTabManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugTabManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.DebugTabManager.Location = new System.Drawing.Point(0, 0);
            this.DebugTabManager.Name = "DebugTabManager";
            this.DebugTabManager.SelectedIndex = 0;
            this.DebugTabManager.Size = new System.Drawing.Size(834, 461);
            this.DebugTabManager.TabIndex = 0;
            // 
            // TabPageMain
            // 
            this.TabPageMain.Controls.Add(this.ClearLogButton);
            this.TabPageMain.Controls.Add(this.label1);
            this.TabPageMain.Controls.Add(this.textBox1);
            this.TabPageMain.Controls.Add(this.GenerateButton);
            this.TabPageMain.Controls.Add(this.dataGridView3);
            this.TabPageMain.Location = new System.Drawing.Point(4, 24);
            this.TabPageMain.Margin = new System.Windows.Forms.Padding(8);
            this.TabPageMain.Name = "TabPageMain";
            this.TabPageMain.Size = new System.Drawing.Size(826, 433);
            this.TabPageMain.TabIndex = 2;
            this.TabPageMain.Text = "Main";
            this.TabPageMain.UseVisualStyleBackColor = true;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(693, 36);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(125, 23);
            this.ClearLogButton.TabIndex = 4;
            this.ClearLogButton.Text = "Очистить логи";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(36, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Сгенерировать игроков";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(36, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1000";
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(93, 28);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 20);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Добавить";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView3.Location = new System.Drawing.Point(0, 63);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView3.Size = new System.Drawing.Size(826, 370);
            this.dataGridView3.TabIndex = 0;
            // 
            // TabPageTreePlayers
            // 
            this.TabPageTreePlayers.Controls.Add(this.treeView1);
            this.TabPageTreePlayers.Location = new System.Drawing.Point(4, 24);
            this.TabPageTreePlayers.Name = "TabPageTreePlayers";
            this.TabPageTreePlayers.Size = new System.Drawing.Size(826, 433);
            this.TabPageTreePlayers.TabIndex = 3;
            this.TabPageTreePlayers.Text = "TreePlayers";
            this.TabPageTreePlayers.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(826, 433);
            this.treeView1.TabIndex = 1;
            // 
            // TabPageTreeTeams
            // 
            this.TabPageTreeTeams.Controls.Add(this.treeView2);
            this.TabPageTreeTeams.Location = new System.Drawing.Point(4, 24);
            this.TabPageTreeTeams.Name = "TabPageTreeTeams";
            this.TabPageTreeTeams.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageTreeTeams.Size = new System.Drawing.Size(826, 433);
            this.TabPageTreeTeams.TabIndex = 0;
            this.TabPageTreeTeams.Text = "TreeTeams";
            this.TabPageTreeTeams.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.treeView2.Indent = 27;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(820, 427);
            this.treeView2.TabIndex = 0;
            // 
            // TabPageTreeTeams2
            // 
            this.TabPageTreeTeams2.Controls.Add(this.treeView3);
            this.TabPageTreeTeams2.Location = new System.Drawing.Point(4, 24);
            this.TabPageTreeTeams2.Name = "TabPageTreeTeams2";
            this.TabPageTreeTeams2.Size = new System.Drawing.Size(826, 433);
            this.TabPageTreeTeams2.TabIndex = 4;
            this.TabPageTreeTeams2.Text = "TreeTeams2";
            this.TabPageTreeTeams2.UseVisualStyleBackColor = true;
            // 
            // treeView3
            // 
            this.treeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView3.Location = new System.Drawing.Point(0, 0);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(826, 433);
            this.treeView3.TabIndex = 1;
            // 
            // TabPageHashTable
            // 
            this.TabPageHashTable.Controls.Add(this.dataGridView1);
            this.TabPageHashTable.Controls.Add(this.dataGridView2);
            this.TabPageHashTable.Location = new System.Drawing.Point(4, 24);
            this.TabPageHashTable.Name = "TabPageHashTable";
            this.TabPageHashTable.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageHashTable.Size = new System.Drawing.Size(826, 433);
            this.TabPageHashTable.TabIndex = 1;
            this.TabPageHashTable.Text = "HashTable";
            this.TabPageHashTable.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(400, 427);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(423, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(400, 427);
            this.dataGridView2.TabIndex = 0;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.DebugTabManager);
            this.MaximumSize = new System.Drawing.Size(850, 500);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DebugForm_FormClosed);
            this.DebugTabManager.ResumeLayout(false);
            this.TabPageMain.ResumeLayout(false);
            this.TabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView3)).EndInit();
            this.TabPageTreePlayers.ResumeLayout(false);
            this.TabPageTreeTeams.ResumeLayout(false);
            this.TabPageTreeTeams2.ResumeLayout(false);
            this.TabPageHashTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button ClearLogButton;

        private System.Windows.Forms.DataGridView dataGridView3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button GenerateButton;

        public System.Windows.Forms.DataGridView dataGridView2;

        public System.Windows.Forms.DataGridView dataGridView1;

        public System.Windows.Forms.TreeView treeView1;

        public System.Windows.Forms.TreeView treeView2;

        private System.Windows.Forms.TabPage TabPageTreePlayers;
        private System.Windows.Forms.TabPage TabPageTreeTeams2;

        public System.Windows.Forms.TreeView treeView3;

        private System.Windows.Forms.TabPage TabPageMain;

        private System.Windows.Forms.TabControl DebugTabManager;
        private System.Windows.Forms.TabPage TabPageTreeTeams;
        private System.Windows.Forms.TabPage TabPageHashTable;

        #endregion
    }
}