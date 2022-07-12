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
        private static readonly DataTable DisplayHashTable1 = new ();
        private static readonly DataTable DisplayHashTable2 = new ();
        
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
            
            
            t = DisplayHashTable1.Columns.Add("hash");
            t.DataType = typeof(int);
            t.Unique = true;
            DisplayHashTable1.PrimaryKey = new [] {t};
            DisplayHashTable1.Columns.Add("first");
            DisplayHashTable1.Columns.Add("ФИО");
            t = DisplayHashTable1.Columns.Add("Дата рождения");
            t.DataType = typeof(DateTime);
            t.DateTimeMode = DataSetDateTime.Utc;
            DisplayHashTable1.Columns.Add("Виды спорта");
            
            t = DisplayHashTable2.Columns.Add("hash");
            t.DataType = typeof(int);
            t.Unique = true;
            DisplayHashTable2.PrimaryKey = new [] {t};
            DisplayHashTable2.Columns.Add("first");
            DisplayHashTable2.Columns.Add("ФИО");
            DisplayHashTable2.Columns.Add("Команда");
            DisplayHashTable2.Columns.Add("Роль");
            DisplayHashTable2.Columns.Add("Вид спорта");
            
            dataGridView1.DataSource = DisplayHashTable1;
            dataGridView2.DataSource = DisplayHashTable2;
        }
        
        private static void DebugAddRow(Player data, int htPos)
        {
            if (DisplayHashTable1.Rows.Find(htPos) != null)
                return; //Произошел ReHash, вставка не требуется
            
            var newRow = DisplayHashTable1.NewRow();
            newRow["hash"] = htPos;
            newRow["first"] = Program.HsTbPlayers.GetHash(data.Name);
            newRow["ФИО"] = data.Name;
            newRow["Дата рождения"] = data.Birthday;
            newRow["Виды спорта"] = data.SportTypes.Aggregate("", (current, c) => current + (", " + c)).Remove(0, 2);
            DisplayHashTable1.Rows.Add(newRow);
        }
        
        private static void DebugAddRow(TeamPlayer data, int htPos)
        {
            if (DisplayHashTable2.Rows.Find(htPos) != null)
                return; //Произошел ReHash, вставка не требуется
            
            var newRow = DisplayHashTable2.NewRow();
            newRow["hash"] = htPos;
            newRow["first"] = Program.HsTbTeams.GetHash(data.PlayerName+data.TeamName);
            newRow["ФИО"] = data.PlayerName;
            newRow["Команда"] = data.TeamName;
            newRow["Роль"] = data.Role;
            newRow["Вид спорта"] = data.SportType;
            DisplayHashTable2.Rows.Add(newRow);
        }
        
        public static void UpdateHashTablePlayers()
        {
            DisplayHashTable1.Rows.Clear();
            for(var i = 0; i < Program.HsTbPlayers.ArrStatus.Length; i++)
                if(Program.HsTbPlayers.ArrStatus[i] == HashTable<Player>.CellStatus.Filled)
                    DebugAddRow(Program.HsTbPlayers.Arr[i].Data, i);
        }
        
        public static void UpdateHashTableTeams()
        {
            DisplayHashTable2.Rows.Clear();
            for(var i = 0; i < Program.HsTbTeams.ArrStatus.Length; i++)
                if(Program.HsTbTeams.ArrStatus[i] == HashTable<TeamPlayer>.CellStatus.Filled)
                    DebugAddRow(Program.HsTbTeams.Arr[i].Data, i);
        }

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
            RecursivelyAddNodeToTheTree(s, node.Left, convertToString);
            RecursivelyAddNodeToTheTree(s, node.Right, convertToString);
            if(node.Color is RbTree<TData, TKey>.Color.Red)
                s.ForeColor = Color.Red;
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

            treeView.EndUpdate();
            treeView.ExpandAll();
            
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