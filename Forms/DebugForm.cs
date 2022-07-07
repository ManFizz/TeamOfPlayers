using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TeamOfPlayers.Structures;
using TeamOfPlayers.Utilities;

namespace TeamOfPlayers.Forms
{
    public partial class DebugForm : Form
    {
        private DataTable _eventTable = new();
        public DebugForm()
        {
            InitializeComponent();
            
            var t = _eventTable.Columns.Add("№");
            t.DataType = typeof(int);
            t.AutoIncrement = true;
            t.AutoIncrementSeed = 1;
            _eventTable.Columns.Add("Событие");
            t  = _eventTable.Columns.Add("Счет");
            t.DataType = typeof(int);
            dataGridView3.DataSource = _eventTable;
        }
        
        public static void DebugAddRow(Player data, int htPos)
        {
            if (Program.DisplayHashTable1.Rows.Find(htPos) != null)
                return; //Произошел ReHash, вставка не требуется
            
            var newRow = Program.DisplayHashTable1.NewRow();
            newRow["pos"] = htPos;
            newRow["ФИО"] = data.Name;
            newRow["Дата рождения"] = data.Birthday;
            newRow["Виды спорта"] = data.SportTypes.Aggregate("", (current, c) => current + (", " + c)).Remove(0, 2);
            Program.DisplayHashTable1.Rows.Add(newRow);
        }
        
        public static void DebugAddRow(TeamPlayer data, int htPos)
        {
            if (Program.DisplayHashTable2.Rows.Find(htPos) != null)
                return; //Произошел ReHash, вставка не требуется
            
            var newRow = Program.DisplayHashTable2.NewRow();
            newRow["pos"] = htPos;
            newRow["ФИО"] = data.PlayerName;
            newRow["Команда"] = data.TeamName;
            newRow["Роль"] = data.Role;
            newRow["Вид спорта"] = data.SportType;
            Program.DisplayHashTable2.Rows.Add(newRow);
        }
        
        public static void OnResizeHashTablePlayers()
        {
            Program.DisplayHashTable1.Rows.Clear();
            for(var i = 0; i < Program.HsTbPlayers.ArrStatus.Length; i++)
                if(Program.HsTbPlayers.ArrStatus[i] == HashTable<Player>.CellStatus.Filled)
                    DebugAddRow(Program.HsTbPlayers.Arr[i].Data, i);
        }
        
        public static void OnResizeHashTableTeams()
        {
            Program.DisplayHashTable2.Rows.Clear();
            for(var i = 0; i < Program.HsTbTeams.ArrStatus.Length; i++)
                if(Program.HsTbTeams.ArrStatus[i] == HashTable<TeamPlayer>.CellStatus.Filled)
                    DebugAddRow(Program.HsTbTeams.Arr[i].Data, i);
        }

        private static void SetNodeChildPlayer(TreeNode parent, RbTree<Player, DateTime>.Node left,
            RbTree<Player, DateTime>.Node right)
        {
            if(left?.Data != null)
                SetNodeChildPlayer(parent.Nodes.Add(left.Data.Birthday.ToString("dd.MM.yyyy") + " \\ " + left.Data.Name), left.Left, left.Right);
            
            if(right?.Data != null)
                SetNodeChildPlayer(parent.Nodes.Add(right.Data.Birthday.ToString("dd.MM.yyyy") + " \\ " + right.Data.Name), right.Left, right.Right);
        }
        public void ReBuildTreePlayers(RbTree<Player, DateTime> treePlayers)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            SetNodeChildPlayer(treeView1.Nodes.Add(treePlayers.Root.Data.Birthday.ToString("dd.MM.yyyy") + " \\ " + treePlayers.Root.Data.Name), treePlayers.Root.Left,
                treePlayers.Root.Right);
            treeView1.EndUpdate();
        }
        
        
        private static void SetNodeChildTeam(TreeNode parent, RbTree<TeamPlayer, string>.Node left,
            RbTree<TeamPlayer, string>.Node right)
        {
            if(left?.Data != null)
                SetNodeChildTeam(parent.Nodes.Add(left.Data.Role + " \\ " + left.Data.PlayerName  +  " \\ " + left.Data.TeamName), left.Left, left.Right);
            
            if(right?.Data != null)
                SetNodeChildTeam(parent.Nodes.Add(right.Data.Role + " \\ " + right.Data.PlayerName  +  " \\ " + right.Data.TeamName), right.Left, right.Right);
        }
        
        public void ReBuildTreeTeams(RbTree<TeamPlayer, string> treeTeams)
        {
            treeView2.BeginUpdate();
            treeView2.Nodes.Clear();
            SetNodeChildTeam(treeView2.Nodes.Add(treeTeams.Root.Data.Role + " \\ " + treeTeams.Root.Data.PlayerName  +  " \\ " + treeTeams.Root.Data.TeamName), treeTeams.Root.Left,
                treeTeams.Root.Right);
            treeView2.EndUpdate();
        }
        
        
        private static void SetNodeChildTeamByName(TreeNode parent, RbTree<TeamPlayer, string>.Node left,
            RbTree<TeamPlayer, string>.Node right)
        {
            if(left?.Data != null)
                SetNodeChildTeamByName(parent.Nodes.Add(left.Data.PlayerName  +  " \\ " + left.Data.TeamName), left.Left, left.Right);
            
            if(right?.Data != null)
                SetNodeChildTeamByName(parent.Nodes.Add(right.Data.PlayerName  +  " \\ " + right.Data.TeamName), right.Left, right.Right);
        }
        
        public void ReBuildTreeTeamsByName(RbTree<TeamPlayer, string> treeTeams)
        {
            treeView3.BeginUpdate();
            treeView3.Nodes.Clear();
            SetNodeChildTeamByName(treeView3.Nodes.Add(treeTeams.Root.Data.PlayerName  +  " \\ " + treeTeams.Root.Data.TeamName), treeTeams.Root.Left,
                treeTeams.Root.Right);
            treeView3.EndUpdate();
        }

        private void DebugForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainForm.Close();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var count))
            {
                MessageBox.Show("Не удается получить число", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            if (count <= 0)
            {
                MessageBox.Show("Ожидалось натуральное число", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            
            GenerateData.GenerateDataBase(count);
            MessageBox.Show("Новые данные успешно добавлены","Успех",  MessageBoxButtons.OK);
        }

        public void WriteLine(string str, int count = -1)
        {
            var  newRow = _eventTable.NewRow();
            newRow["Событие"] = str;
            newRow["Счет"] = count;
            _eventTable.Rows.Add(newRow);
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            _eventTable.Rows.Clear();
        }
    }
}