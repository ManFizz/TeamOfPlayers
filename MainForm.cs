using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TeamOfPlayers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<Player> listPlayers;
        private List<TeamPlayer> listTeams;

        private RbTree<Player, DateTime> _treePlayers;
        private RbTree<TeamPlayer, string> _treeTeams;

        private HashTable<Player> _hashTable1;
        private HashTable<TeamPlayer> _hashTable2;

        private DataTable _playerDisplay;//TODO
        private DataTable _teamDisplay; //TODO

        private List<Player> _searchArrayPlayers = null;
        private List<TeamPlayer> _searchArrayTeams = null;


        private DataTable _reportDisplay = new DataTable(); //TODO

        public void InitData()
        {
            listPlayers = Program.ListPlayers;
            listTeams = Program.ListTeams;

            _treePlayers = Program.RbTreePlayers;
            _treeTeams = Program.RbTreeTeams;

            _hashTable1 = Program.HashTablePlayers;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _playerDisplay.Columns.Add("ФИО");
            _playerDisplay.Columns.Add("Дата рождения");
            _playerDisplay.Columns[1].DataType = typeof(DateTime);
            _playerDisplay.Columns[1].DateTimeMode = DataSetDateTime.Utc;
            _playerDisplay.Columns.Add("Виды спорта");
            dataGridView1.DataSource = _playerDisplay;

            _teamDisplay.Columns.Add("ФИО");
            _teamDisplay.Columns.Add("Команда");
            _teamDisplay.Columns.Add("Роль");
            _teamDisplay.Columns.Add("Вид спорта");
            dataGridView2.DataSource = _teamDisplay;

            _reportDisplay.Columns.Add("ФИО");
            _reportDisplay.Columns.Add("Дата рождения");
            _reportDisplay.Columns.Add("Виды спорта");
            _reportDisplay.Columns.Add("Вид спорта команды");
            _reportDisplay.Columns.Add("Команда");
            _reportDisplay.Columns.Add("Роль");
            dataGridView3.DataSource = _reportDisplay;

            UpdateVizual(UpdateState.All);
        }

        private enum UpdateState
        {
            ClearError,
            PlayerTable,
            TeamTable,
            AllTables,
            All
        }

        private void UpdateVizual(UpdateState state)
        {
            if (state == UpdateState.PlayerTable || state == UpdateState.All || state == UpdateState.AllTables)
            {
                _playerDisplay.Clear();
                foreach (var player in listPlayers)
                    _playerDisplay.Rows.Add(CreatePlayerRow(_playerDisplay, player));
            }

            if (state == UpdateState.TeamTable || state == UpdateState.All || state == UpdateState.AllTables)
            {
                _teamDisplay.Clear();
                foreach (var teamPlayer in listTeams)
                    _teamDisplay.Rows.Add(CreateTeamPlayerRow(_teamDisplay, teamPlayer));
            }

            if (state == UpdateState.ClearError || state == UpdateState.All)
            {
                ErrorLabel.Text = string.Empty;
                SuccesLabel.Text = string.Empty;
            }
        }

        private static DataRow CreateTeamPlayerRow(DataTable table, TeamPlayer teamPlayer)
        {
            var newRow = table.NewRow();
            newRow["ФИО"] = teamPlayer.PlayerName;
            newRow["Команда"] = teamPlayer.TeamName;
            newRow["Роль"] = teamPlayer.Role;
            newRow["Вид спорта"] = teamPlayer.SportType;
            return newRow;
        }

        private static DataRow CreatePlayerRow(DataTable table, Player player)
        {
            var newRow = table.NewRow();
            newRow["ФИО"] = player.Name;
            newRow["Дата рождения"] = player.Birthday;
            var sportsString = "";
            foreach (var c in player.SportTypes)
                sportsString += ", " + c;

            newRow["Виды спорта"] = sportsString.Remove(0, 2);
            return newRow;
        }

        private void DeletePlayerButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text;

            if (_searchArrayPlayers.Count == 0)
            {
                ErrorLabel.Text = "Нечего удалять";
                return;
            }
            
            foreach (var p in _searchArrayPlayers)
            {
                Program.RemoveData(p);
                var list = listTeams.Where(c => c.PlayerName == p.Name).ToList();
                foreach (var t in list)
                    Program.RemoveData(t);
            }
            
            SuccesLabel.Text = ("Удалено " + _searchArrayPlayers.Count + " записей");
            _searchArrayPlayers = null;
            UpdateVizual(UpdateState.AllTables);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text;

            if (name == string.Empty)
            {
                ErrorLabel.Text = "Не заданы условия поиска";
                return;
            }
            
            _searchArrayPlayers = listPlayers.ToArray().ToList();
            if (name != string.Empty)
                _searchArrayPlayers = _searchArrayPlayers.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (_searchArrayPlayers.Count > 0)
            {
                SuccesLabel.Text = ("Найдено " + _searchArrayPlayers.Count + " записей");
                _playerDisplay.Clear();
                foreach (var player in _searchArrayPlayers)
                    _playerDisplay.Rows.Add(CreatePlayerRow(_playerDisplay, player));

                DeletePlayerButton.Enabled = true;
                ClearButton.Enabled = true;
            }
            else
                SuccesLabel.Text = ("Ни одной записи небыло найдено");
            //Update не должен быть
        }

        private void ClearSearcButton1_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.PlayerTable);
            UpdateVizual(UpdateState.ClearError);

            DeletePlayerButton.Enabled = false;
            ClearButton.Enabled = false;
        }

        private void DeletePlayerButton2_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO2.Text;
            var team = textBoxTeam.Text;

            if (_searchArrayTeams.Count == 0)
            {
                ErrorLabel.Text = "Нечего удалять";
                throw new Exception("Как тут оказался пользователь"); //TODO REMOVE
                return;
            }
            
            foreach (var p in _searchArrayTeams)
                _treeTeams.Remove(p, p.Role);
            
            SuccesLabel.Text = ("Удалено " + _searchArrayTeams.Count + " записей");
            _searchArrayTeams = null;

            DeletePlayerButton.Enabled = false;
            ClearButton.Enabled = false;
            UpdateVizual(UpdateState.TeamTable);
        }

        private void SearchButton2_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);


            var name = textBoxFIO2.Text;
            var team = textBoxTeam.Text;

            if (name == string.Empty && team == string.Empty)
            {
                ErrorLabel.Text = "Не заданы условия поиска";
                return;
            }
            
            _searchArrayTeams = listTeams.ToArray().ToList();
            if (name != string.Empty)
                _searchArrayTeams = _searchArrayTeams.Where(p => p.PlayerName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (team != string.Empty)
                _searchArrayTeams = _searchArrayTeams.Where(p => p.TeamName.IndexOf(team, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (_searchArrayTeams.Count > 0)
            {
                SuccesLabel.Text = ("Найдено " + _searchArrayTeams.Count + " записей");
                _teamDisplay.Clear();
                foreach (var player in _searchArrayTeams)
                    _teamDisplay.Rows.Add(CreateTeamPlayerRow(_teamDisplay, player));
            }
            else
                SuccesLabel.Text = ("Ни одной записи небыло найдено");
            //Update не должен быть
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.TeamTable);
            UpdateVizual(UpdateState.ClearError);
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            _reportDisplay.Clear();
            
            int age;
            if(!int.TryParse(textBoxAge.Text, out age))
            {
                ErrorLabel.Text = "Некорректный ввод возраста\nОжидалось число";
                return;
            }

            var Role = textBoxRole2.Text;
            if(string.IsNullOrEmpty(Role))
            {
                ErrorLabel.Text = "Empty Role";
                return;
            }


            var table1 = _treePlayers.FindAge(age, CalculateAge);
            var nodeList = _treeTeams.FindList(Role);

            foreach (var node in nodeList)
            {
                var teamPlayer = node.Data;
                Player player = null;//table1.Where(p => string.CompareOrdinal(teamPlayer.PlayerName, p.Name) == 0).GetEnumerator().Current;
                foreach (var p in table1)
                {
                    if (p.Name == teamPlayer.PlayerName)
                    {
                        player = p;
                        break;
                    }
                }
                if(player == null)
                    continue;
                
                var newRow = _reportDisplay.NewRow();
                newRow["ФИО"] = player.Name;
                newRow["Дата рождения"] = player.Birthday;
                var sportsString = "";
                foreach (var c in player.SportTypes)
                    sportsString += ", " + c;
                newRow["Виды спорта"] = sportsString.Remove(0, 2);
                newRow["Вид спорта команды"] = teamPlayer.SportType;
                newRow["Команда"] = teamPlayer.TeamName;
                newRow["Роль"] = teamPlayer.Role;
                _reportDisplay.Rows.Add(newRow);
                
            }

            SuccesLabel.Text = "Количество записей удовлетворяющий условиям поиска: " + _reportDisplay.Rows.Count;
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private void PrintHashTableButton_Click(object sender, EventArgs e)
        {
            _playerDisplay.Clear();
            var list = _hashTable1.GetList();
            foreach (var  p in list)
                _playerDisplay.Rows.Add(CreatePlayerRow(_playerDisplay, p));
        }

        private void SearchHashButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text;

            if (name == string.Empty)
            {
                ErrorLabel.Text = "Ожидается строка в поле ФИО";
                return;
            }

            var pos = _hashTable1.GetPos(name);
            if (pos == -1)
            {
                ErrorLabel.Text = "По заданому ФИО ничего не найдено";
                return;
            }

            _playerDisplay.Clear();
            _playerDisplay.Rows.Add(CreatePlayerRow(_playerDisplay, _hashTable1.Get(pos)));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FileManager.Save("inputPlayers.txt", _TreePlayers);
            //FileManager.Save("inputTeamPlayers.txt", _TreeTeams);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
