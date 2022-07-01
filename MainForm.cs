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

        private RbTree<Player, DateTime> _dataBase1 = new RbTree<Player, DateTime>();
        private readonly HashTable _hashTable = new HashTable();
        private DataTable _playerTable;

        private RbTree<TeamPlayer, string> _dataBase2 = new RbTree<TeamPlayer, string>();
        private DataTable _teamDataTable;

        private readonly DataTable _reportTable = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            FileReader.Path = "C:\\Users\\Mak\\OneDrive\\Рабочий стол\\Учеба\\TeamOfPlayers\\";

            _playerTable.Columns.Add("ФИО");
            _playerTable.Columns.Add("Дата рождения");
            _playerTable.Columns[1].DataType = typeof(DateTime);
            _playerTable.Columns[1].DateTimeMode = DataSetDateTime.Utc;
            _playerTable.Columns.Add("Виды спорта");
            dataGridView1.DataSource = _playerTable;

            _teamDataTable.Columns.Add("ФИО");
            _teamDataTable.Columns.Add("Команда");
            _teamDataTable.Columns.Add("Роль");
            _teamDataTable.Columns.Add("Вид спорта");
            dataGridView2.DataSource = _teamDataTable;

            _reportTable.Columns.Add("ФИО");
            _reportTable.Columns.Add("Дата рождения");
            _reportTable.Columns.Add("Виды спорта");
            _reportTable.Columns.Add("Вид спорта команды");
            _reportTable.Columns.Add("Команда");
            _reportTable.Columns.Add("Роль");
            dataGridView3.DataSource = _reportTable;

            //GenerateData.GeneratePlayerDataBase(ref _dataBase1);
            //GenerateData.GenerateTeamDataBase(_dataBase1, ref _dataBase2);
            //FileReader.Save("inputPlayers.txt", _dataBase1);
            //FileReader.Save("inputTeamPlayers.txt", _dataBase2);

            FileReader.Read("inputPlayers.txt", ref _dataBase1);
            FileReader.Read("inputTeamPlayers.txt", ref _dataBase2);
            var list = _dataBase1.GetList();
            foreach (var player in list)
                _hashTable.Add(player);

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
                _playerTable.Clear();
                var players = _dataBase1.GetList();
                foreach (var player in players)
                    _playerTable.Rows.Add(CreatePlayerRow(_playerTable, player));
            }

            if (state == UpdateState.TeamTable || state == UpdateState.All || state == UpdateState.AllTables)
            {
                _teamDataTable.Clear();
                var teamPlayers = _dataBase2.GetList();
                foreach (var teamPlayer in teamPlayers)
                    _teamDataTable.Rows.Add(CreateTeamPlayerRow(_teamDataTable, teamPlayer));
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

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text.Trim(' ');
            var date = textBoxDate.Text.Trim(' ');
            var sport = textBoxSport.Text.Trim(' ');

            Player player = null;
            try {
                player = FileReader.ParsePlayer(name + ";" + date + ";" + sport);
            } catch (Exception exception)
            {
                ErrorLabel.Text = exception.Message;
                return;
            }

            var fPlayer = _dataBase1.GetList();
            if (fPlayer.Any(p => player.Name == p.Name))
            {
                ErrorLabel.Text = "Name already exists";
                return;
            }

            _dataBase1.Insert(player, player.Birthday);
            _hashTable.Add(player);

            _playerTable.Rows.Add(CreatePlayerRow(_playerTable,player));
            SuccesLabel.Text = ("Игрок " + player.Name + " успешно добавлен");
            //update не нужен
        }

        private void DeletePlayerButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text;
            var date = textBoxDate.Text;
            var sport = textBoxSport.Text;

            if (name == string.Empty && date == string.Empty && sport == string.Empty)
            {
                ErrorLabel.Text = "Не заданы условия удаления";
                return;
            }

            var fPlayer = _dataBase1.GetList();
            if (name != string.Empty)
                fPlayer = fPlayer.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (date != string.Empty)
            {
                var b = DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime);
                fPlayer = fPlayer.Where(p => p.Birthday == dateTime).ToList();
            }

            if (sport != string.Empty)
            {
                var sportList = sport.Split(',');
                foreach (var str in sportList)
                    fPlayer = fPlayer.Where(p => p.SportTypes.Any(c => c.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
            }

            var list = _dataBase2.GetList();
            foreach (var p in fPlayer)
            {
                _dataBase1.Delete(p, p.Birthday);
                _hashTable.Remove(p);
                var s = list.Where(c => c.PlayerName == p.Name).ToList();
                foreach (var tp in s)
                    _dataBase2.Delete(tp, tp.Role);
            }

            if (fPlayer.Count > 0)
            {
                SuccesLabel.Text = ("Удалено " + fPlayer.Count + " записей");
                UpdateVizual(UpdateState.AllTables);
            }
            else
                SuccesLabel.Text = ("Ни одной записи небыло удалено");

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text;
            var date = textBoxDate.Text;
            var sport = textBoxSport.Text;

            if (name == string.Empty && date == string.Empty && sport == string.Empty)
            {
                ErrorLabel.Text = "Не заданы условия поиска";
                return;
            }

            var fPlayer = _dataBase1.GetList();
            if (name != string.Empty)
                fPlayer = fPlayer.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (date != string.Empty)
            {
                var b = DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime);
                fPlayer = fPlayer.Where(p => p.Birthday == dateTime).ToList();
            }

            if (sport != string.Empty)
            {
                var sportList = sport.Split(',');
                foreach(var str in sportList)
                    fPlayer = fPlayer.Where(p => p.SportTypes.Any(c=> c.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
            }

            if (fPlayer.Count > 0)
            {
                SuccesLabel.Text = ("Найдено " + fPlayer.Count + " записей");
                _playerTable.Clear();
                foreach (var player in fPlayer)
                    _playerTable.Rows.Add(CreatePlayerRow(_playerTable, player));
            }
            else
                SuccesLabel.Text = ("Ни одной записи небыло найдено");
            //Update не должен быть
        }

        private void ClearSearcButton1_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.PlayerTable);
            UpdateVizual(UpdateState.ClearError);
        }
        
        private void AddPlayerButton2_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO2.Text.Trim(' ');
            var team = textBoxTeam.Text.Trim(' ');
            var role = textBoxRole.Text.Trim(' ');
            var sport = textBoxSport2.Text.Trim(' ');
            TeamPlayer player = null;
            try {
                player = FileReader.ParseTeamPlayer(name + ";" + team + ";" + role + ";" + sport);
            } catch (Exception exception) 
            {
                ErrorLabel.Text = exception.Message;
                return;
            }

            var fCheck = _dataBase1.GetList();
            if (fCheck.All(p => p.Name != name))
            {
                ErrorLabel.Text = "Такого игрока нету в таблице \"Игроки\"";
                return;
            }

            var fPlayer = _dataBase2.GetList();
            if (fPlayer.Any(p => name == p.PlayerName && team == p.TeamName))
            {
                ErrorLabel.Text = "Такой игрок в этой команде уже есть";
                return;
            }

            _dataBase2.Insert(player, player.Role);

            _teamDataTable.Rows.Add(CreateTeamPlayerRow(_teamDataTable, player));
            SuccesLabel.Text = ("Игрок " + player.PlayerName + " успешно добавлен");
            //Update не нужен
        }

        private void DeletePlayerButton2_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO2.Text;
            var team = textBoxTeam.Text;
            var role = textBoxRole.Text;
            var sport = textBoxSport2.Text;

            if (name == string.Empty && team == string.Empty && role == string.Empty && sport == string.Empty)
            {
                ErrorLabel.Text = "Не заданы условия удаления";
                return;
            }

            var fPlayer = _dataBase2.GetList();
            if (name != string.Empty)
                fPlayer = fPlayer.Where(p => p.PlayerName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (team != string.Empty)
                fPlayer = fPlayer.Where(p => p.TeamName.IndexOf(team, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (role != string.Empty)
                fPlayer = fPlayer.Where(p => p.Role.IndexOf(role, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (sport != string.Empty)
                fPlayer = fPlayer.Where(p => p.SportType.IndexOf(sport, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            
            foreach (var p in fPlayer)
            {
                _dataBase2.Delete(p, p.Role);
            }

            if (fPlayer.Count > 0)
                SuccesLabel.Text = ("Удалено " + fPlayer.Count + " записей");
            else
                SuccesLabel.Text = ("Ни одной записи небыло удалено");

            UpdateVizual(UpdateState.TeamTable);
        }

        private void SearchButton2_Click(object sender, EventArgs e)
        {
            UpdateVizual(UpdateState.ClearError);


            var name = textBoxFIO2.Text;
            var team = textBoxTeam.Text;
            var role = textBoxRole.Text;
            var sport = textBoxSport2.Text;

            if (name == string.Empty && team == string.Empty && role == string.Empty && sport == string.Empty)
            {
                ErrorLabel.Text = "Не заданы условия поиска";
                return;
            }

            var fPlayer = _dataBase2.GetList();
            if (name != string.Empty)
                fPlayer = fPlayer.Where(p => p.PlayerName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (team != string.Empty)
                fPlayer = fPlayer.Where(p => p.TeamName.IndexOf(team, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (role != string.Empty)
                fPlayer = fPlayer.Where(p => p.Role.IndexOf(role, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (sport != string.Empty)
                fPlayer = fPlayer.Where(p => p.SportType.IndexOf(sport, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            if (fPlayer.Count > 0)
            {
                SuccesLabel.Text = ("Найдено " + fPlayer.Count + " записей");
                _teamDataTable.Clear();
                foreach (var player in fPlayer)
                    _teamDataTable.Rows.Add(CreateTeamPlayerRow(_teamDataTable, player));
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

            _reportTable.Clear();
            
            int age;
            if(!int.TryParse(textBoxAge.Text, out age))
            {
                ErrorLabel.Text = "Некорректный ввод возраста\nОжидалось число";
                return;
            }

            var Role = textBoxRole2.Text;
            if(Role == string.Empty)
            {
                ErrorLabel.Text = "Empty Role";
                return;
            }


            var table1 = _dataBase1.FindAge(age, CalculateAge);
            var nodeList = _dataBase2.FindList(Role);

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
                
                var newRow = _reportTable.NewRow();
                newRow["ФИО"] = player.Name;
                newRow["Дата рождения"] = player.Birthday;
                var sportsString = "";
                foreach (var c in player.SportTypes)
                    sportsString += ", " + c;
                newRow["Виды спорта"] = sportsString.Remove(0, 2);
                newRow["Вид спорта команды"] = teamPlayer.SportType;
                newRow["Команда"] = teamPlayer.TeamName;
                newRow["Роль"] = teamPlayer.Role;
                _reportTable.Rows.Add(newRow);
                
            }

            SuccesLabel.Text = "Количество записей удовлетворяющий условиям поиска: " + _reportTable.Rows.Count;
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
            _playerTable.Clear();
            for (var i = 0; i < _hashTable._capacity; i++)
            {
                if (_hashTable._arrStatus[i] != HashTable.HtStatus.Filled)
                    continue;
                
                _playerTable.Rows.Add(CreatePlayerRow(_playerTable, _hashTable._arr[i]));

            }
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

            var pos = _hashTable.GetPos(name);
            if (pos == -1)
            {
                ErrorLabel.Text = "По заданому ФИО ничего не найдено";
                return;
            }

            _playerTable.Clear();
            _playerTable.Rows.Add(CreatePlayerRow(_playerTable, _hashTable._arr[pos]));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileReader.Save("inputPlayers.txt", _dataBase1);
            FileReader.Save("inputTeamPlayers.txt", _dataBase2);
        }
    }

    //TODO Проверка вносимых данных на ебаные буквы
    // +-
    //TODO Проверка ФИО на три слова
    //
}
