using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TeamOfPlayers.Structures;
using TeamOfPlayers.Utilities;

namespace TeamOfPlayers.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private DataTable _playerDisplay;
        private DataTable _teamDisplay;

        private Player _searchPlayer;
        private TeamPlayer _searchTeam;
        
        private readonly DataTable _reportDisplay = new DataTable();


        private void Form1_Load(object sender, EventArgs e)
        {
            _playerDisplay.Columns.Add("ФИО");
            var t = _playerDisplay.Columns.Add("Дата рождения");
            t.DataType = typeof(DateTime);
            t.DateTimeMode = DataSetDateTime.Utc;
            _playerDisplay.Columns.Add("Виды спорта");
            dataGridView1.DataSource = _playerDisplay;

            _teamDisplay.Columns.Add("ФИО");
            _teamDisplay.Columns.Add("Команда");
            _teamDisplay.Columns.Add("Роль");
            _teamDisplay.Columns.Add("Вид спорта");
            dataGridView2.DataSource = _teamDisplay;

            _reportDisplay.Columns.Add("ФИО");
            t = _reportDisplay.Columns.Add("Дата рождения");
            t.DataType = typeof(DateTime);
            t.DateTimeMode = DataSetDateTime.Utc;
            _reportDisplay.Columns.Add("Виды спорта");
            _reportDisplay.Columns.Add("Вид спорта команды");
            _reportDisplay.Columns.Add("Команда");
            _reportDisplay.Columns.Add("Роль");
            dataGridView3.DataSource = _reportDisplay;

            UpdateVisual(UpdateState.All);
        }

        public enum UpdateState
        {
            PlayerTable,
            TeamTable,
            AllTables,
            All
        }

        public void UpdateVisual(UpdateState state)
        {
            if (state is UpdateState.PlayerTable or UpdateState.All or UpdateState.AllTables)
            {
                dataGridView1.Enabled = false;
                _playerDisplay.Clear();
                foreach (var player in Program.ListPlayers)
                    _playerDisplay.Rows.Add(CreatePlayerRow(_playerDisplay, player));
                dataGridView1.Enabled = true;
            }

            if (state is UpdateState.TeamTable or UpdateState.All or UpdateState.AllTables)
            {

                dataGridView2.Enabled = false;
                _teamDisplay.Clear();
                foreach (var teamPlayer in Program.ListTeams)
                    _teamDisplay.Rows.Add(CreateTeamPlayerRow(_teamDisplay, teamPlayer));
                dataGridView2.Enabled = true;

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
            newRow["Виды спорта"] = player.SportTypes.Aggregate("", (current, c) => current + (", " + c)).Remove(0, 2);
            return newRow;
        }

        private void DeletePlayerButton_Click(object sender, EventArgs e)
        {
            if (_searchPlayer is null)
            {
                MessageBox.Show("Поиск пуст","Удаление не выполнено",  MessageBoxButtons.OK);
                return;
            }
            
            Program.RemoveData(_searchPlayer);
            MessageBox.Show("Удалены записи об " + _searchPlayer.Name,"Удаление выполнено",  MessageBoxButtons.OK);
            _searchPlayer = null;
            
            UpdateVisual(UpdateState.AllTables);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            var name = textBoxSearchPlayer.Text;
            if (name == string.Empty)
            {
                MessageBox.Show("Не заданы условия поиска","Поиск не выполнен",  MessageBoxButtons.OK);
                return;
            }

            _searchPlayer = Program.HsTbPlayers.Get(name);
            if (_searchPlayer is not null)
            {
                MessageBox.Show("Найден игрок " + _searchPlayer.Name,"Игрок найден",  MessageBoxButtons.OK);
                _playerDisplay.Clear();
                _playerDisplay.Rows.Add(CreatePlayerRow(_playerDisplay, _searchPlayer));
            }
            else
                MessageBox.Show("Такого игрока нет в списке","Игрок не найден",  MessageBoxButtons.OK);
        }

        private void ClearSearchButton1_Click(object sender, EventArgs e)
        {
            UpdateVisual(UpdateState.PlayerTable);
        }

        private void DeletePlayerButton2_Click(object sender, EventArgs e)
        {
            if (_searchTeam is null)
            {
                MessageBox.Show("Поиск пуст","Удаление не выполнено",  MessageBoxButtons.OK);
                return;
            }
            
            Program.RemoveData(_searchTeam);
            MessageBox.Show("Удалена запись об "+  _searchTeam.PlayerName + " в команде " + _searchTeam.TeamName,"Удаление выполнено",  MessageBoxButtons.OK);
            _searchTeam = null;

            DeleteTeamButton.Enabled = false;
            ClearTeamButton.Enabled = false;
            UpdateVisual(UpdateState.TeamTable);
        }

        private void SearchButton2_Click(object sender, EventArgs e)
        {
            var name = textBoxSearchTeam1.Text;
            var team = textBoxSearchTeam2.Text;

            if (name == string.Empty || team == string.Empty)
            {
                MessageBox.Show("Не заданы условия поиска","Поиск не выполнен",  MessageBoxButtons.OK);
                return;
            }

            _searchTeam = Program.HsTbTeams.Get(name + team);
            if(_searchTeam is not null)
            {
                MessageBox.Show("Игрок команды " + _searchTeam.TeamName + " найден","Поиск выполнен",  MessageBoxButtons.OK);
                _teamDisplay.Clear();
                _teamDisplay.Rows.Add(CreateTeamPlayerRow(_teamDisplay, _searchTeam));
                DeleteTeamButton.Enabled = true;
                ClearTeamButton.Enabled = true;
            }
            else
                MessageBox.Show("Такого игрока с командой нет в списке","Игрок не найден",  MessageBoxButtons.OK);
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            UpdateVisual(UpdateState.TeamTable);
            DeleteTeamButton.Enabled = false;
            ClearTeamButton.Enabled = false;
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            _reportDisplay.Clear();

            if(!int.TryParse(textBoxAge.Text, out var age))
            {
                MessageBox.Show("Некорректный ввод возраста","Кандидаты не найдены",  MessageBoxButtons.OK);
                return;
            }

            var role = textBoxRole2.Text;
            if(string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Поле роли на заполнено","Кандидаты не найдены",  MessageBoxButtons.OK);
                return;
            }


            var table1 = Program.TreePlayers.FindAge(age, CalculateAge);
            var nodeList = Program.TreeTeams.FindList(role);

            foreach (var node in nodeList)
            {
                var teamPlayer = node.Data;
                var player = table1.FirstOrDefault(p => p.Name == teamPlayer.PlayerName);
                if(player == null)
                    continue;
                
                var newRow = _reportDisplay.NewRow();
                newRow["ФИО"] = player.Name;
                newRow["Дата рождения"] = player.Birthday;
                var sportsString = player.SportTypes.Aggregate("", (current, c) => current + (", " + c));
                newRow["Виды спорта"] = sportsString.Remove(0, 2);
                newRow["Вид спорта команды"] = teamPlayer.SportType;
                newRow["Команда"] = teamPlayer.TeamName;
                newRow["Роль"] = teamPlayer.Role;
                _reportDisplay.Rows.Add(newRow);
                
            }

            MessageBox.Show("Найдено " + _reportDisplay.Rows.Count + " кандидатов","Кандидаты не найдены",  MessageBoxButtons.OK);
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age -= 1;

            return age;
        }

        private void SavePlayersButton_Click(object sender, EventArgs e)
        {
            var path = FileManager.ChooseFile();
            if(path == string.Empty)
                return;
            
            FileManager.SavePlayers(path);
            MessageBox.Show("Список игроков успешно сохранен в " + path,"Файл сохранен",  MessageBoxButtons.OK);
        }

        private void SaveTeamsButton_Click(object sender, EventArgs e)
        {
            var path = FileManager.ChooseFile();
            if(path == string.Empty)
                return;
            
            FileManager.SaveTeams(path);
            MessageBox.Show("Список игроков команд успешно сохранен в " + path,"Файл сохранен",  MessageBoxButtons.OK);
        }

        private void SaveReportButton_Click(object sender, EventArgs e)
        {
            var path = FileManager.ChooseFile();
            if(path == string.Empty)
                return;

            FileManager.SaveReport(path, _reportDisplay);
            MessageBox.Show("Список кандидатов успешно сохранен в " + path,"Файл сохранен",  MessageBoxButtons.OK);
        }

        private void LoadFilePlayersButton_Click(object sender, EventArgs e)
        {
            var path = FileManager.ChooseFile();
            if(path == string.Empty)
                return;
            
            Program.ClearData(true,false);
            FileManager.ReadPlayers(path);
            MessageBox.Show("Данные успешно загружены из: " + path,"Файл загружен",  MessageBoxButtons.OK);
            UpdateVisual(UpdateState.AllTables);
        }

        private void LoadFileTeamsButton_Click(object sender, EventArgs e)
        {
            var path = FileManager.ChooseFile();
            if(path == string.Empty)
                return;
            
            Program.ClearData(false, true);
            FileManager.ReadTeams(path);
            MessageBox.Show("Данные успешно загружены из: " + path,"Файл загружен",  MessageBoxButtons.OK);
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            var from = new AddPlayerForm();
            from.Show();
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            var from = new AddTeamForm();
            from.Show();
        }

        private void DevButton_Click(object sender, EventArgs e)
        {
            Program.DebugForm.Show();
        }
    }
}
