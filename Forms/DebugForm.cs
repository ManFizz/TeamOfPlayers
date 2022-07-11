using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TeamOfPlayers.Structures;
using TeamOfPlayers.Utilities;

namespace TeamOfPlayers.Forms
{
    public partial class DebugForm : Form
    {
        private readonly DataTable _eventTable = new();
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
            dataGridView3.Columns[1].Width = 656;
            dataGridView3.Columns[2].Width = 50;
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

        /*private static void SetNodeChildPlayer(TreeNode parent, RbTree<Player, DateTime>.Node node)
        {
            if (node?.Data == null)
                return;
            
            var displayNode = parent.Nodes.Add(node.Data.Birthday.ToString("dd.MM.yyyy") + " \\ " + node.Data.Name);
            if(node.Color is RbTree<Player, DateTime>.Color.Red)
                displayNode.ForeColor = Color.Brown;
            
            SetNodeChildPlayer(displayNode, node.Left);
            SetNodeChildPlayer(displayNode, node.Right);
            
        }
        public void ReBuildTreePlayers(RbTree<Player, DateTime> treePlayers)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            if (treePlayers.Root != null)
            {
                var s = treeView1.Nodes.Add(treePlayers.Root.Data.Birthday.ToString("dd.MM.yyyy") + " \\ " + treePlayers.Root.Data.Name);
                SetNodeChildPlayer(s, treePlayers.Root.Left);
                SetNodeChildPlayer(s, treePlayers.Root.Right);
            }

            treeView1.EndUpdate();
        }
        
        
        private static void SetNodeChildTeam(TreeNode parent, RbTree<TeamPlayer, string>.Node node)
        {
            if (node?.Data == null)
                return;
            
            var displayNode = parent.Nodes.Add(node.Data.Role + " \\ " + node.Data.PlayerName  +  " \\ " + node.Data.TeamName);
            if(node.Color is RbTree<TeamPlayer, string>.Color.Red)
                displayNode.ForeColor = Color.Brown;
            
            SetNodeChildTeam(displayNode, node.Left);
            SetNodeChildTeam(displayNode, node.Right);
        }
        
        public void ReBuildTreeTeams(RbTree<TeamPlayer, string> treeTeams)
        {
            treeView2.BeginUpdate();
            treeView2.Nodes.Clear();
            if (treeTeams.Root != null)
            {
                var s = treeView2.Nodes.Add(treeTeams.Root.Data.Role + @" \ " + treeTeams.Root.Data.PlayerName + @" \ " + treeTeams.Root.Data.TeamName);
                SetNodeChildTeam(s, treeTeams.Root.Left);
                SetNodeChildTeam(s, treeTeams.Root.Right);
            }

            treeView2.EndUpdate();
        }
        
        
        private static void SetNodeChildTeamByName(TreeNode parent, RbTree<TeamPlayer, string>.Node node)
        {
            if (node?.Data == null)
                return;

            var displayNode = parent.Nodes.Add(node.Data.PlayerName + " \\ " + node.Data.TeamName);
            if(node.Color is RbTree<TeamPlayer, string>.Color.Red)
                displayNode.ForeColor = Color.Brown;
            
            SetNodeChildTeamByName(displayNode, node.Left);
            SetNodeChildTeamByName(displayNode, node.Right);
        }
        
        public void ReBuildTreeTeamsByName(RbTree<TeamPlayer, string> treeTeams)
        {
            treeView3.BeginUpdate();
            treeView3.Nodes.Clear();
            if (treeTeams.Root != null)
            {
                var s = treeView3.Nodes.Add(treeTeams.Root);
                SetNodeChildTeamByName(s, treeTeams.Root.Left);
                SetNodeChildTeamByName(s, treeTeams.Root.Right);
            }

            treeView3.EndUpdate();
        }*/

        public string ConvertByName(RbTree<TeamPlayer, string>.Node node)
        {
            if (node.Empty())
                return null;

            var sOut = "";
            foreach (var teamPlayer in node.GetList())
                sOut += teamPlayer.PlayerName + @" \ " + teamPlayer.TeamName + @"; ";
            return sOut;
        }
        
        public string ConvertByRole(RbTree<TeamPlayer, string>.Node node)
        {
            if (node.Empty())
                return null;

            var sOut = "";
            foreach (var teamPlayer in node.GetList())
                sOut += teamPlayer.Role + @" \ " + teamPlayer.PlayerName + @" \ " + teamPlayer.TeamName + @"; ";
            return sOut;
        }
        
        public string ConvertByDate(RbTree<Player, DateTime>.Node node)
        {
            if (node.Empty())
                return null;
            
            var sOut = "";
            foreach (var player in node.GetList())
                sOut += player.Birthday.ToString("dd.MM.yyyy") + " \\ " + player.Name + @"; ";
            return sOut;
        }

        private static void RecursivelyAddNodeToTheTree<TData, TKey>(TreeNode parent,RbTree<TData, TKey>.Node node, Func<RbTree<TData, TKey>.Node, string> convertToString)
        {
            var str = convertToString(node);
            if (str is null)
                return;
            
            var s = parent.Nodes.Add(str);
            if(node.Color is RbTree<TData, TKey>.Color.Red)
                s.ForeColor = Color.Red;
            RecursivelyAddNodeToTheTree(s, node.Left, convertToString);
            RecursivelyAddNodeToTheTree(s, node.Right, convertToString);
        }
        
        public void ReBuildTree<TData, TKey>(RbTree<TData, TKey> tree, TreeView treeView, Func<RbTree<TData, TKey>.Node, string> convertToString)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            if (tree.Root != null)
            {
                var s = treeView.Nodes.Add(convertToString(tree.Root));
                RecursivelyAddNodeToTheTree(s, tree.Root.Left, convertToString);
                RecursivelyAddNodeToTheTree(s, tree.Root.Right, convertToString);
            }

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