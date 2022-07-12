using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeamOfPlayers.Forms;
using TeamOfPlayers.Structures;
using TeamOfPlayers.Utilities;

namespace TeamOfPlayers
{
    internal static class Program
    {
        //Вид записей по умолчанию
        public static List<Player> ListPlayers = new ();
        public static List<TeamPlayer> ListTeams = new ();
        
        //Деревья для общей задачи поиска
        public static RbTree<Player, DateTime> TreePlayers = new (CompareDateTime, EqualsData);
        public static RbTree<TeamPlayer, string> TreeTeams = new (CompareString, EqualsData);
        
        //Хеш-таблицы для проверки уникальности
        public static HashTable<Player> HsTbPlayers = new () {
            OnResize = DebugForm.UpdateHashTablePlayers
        };
        public static HashTable<TeamPlayer> HsTbTeams = new() {
            OnResize = DebugForm.UpdateHashTableTeams
        };
        
        //Дерево для поиска игрока команды, при удалении самого игрока
        private static RbTree<TeamPlayer, string> _treeTeamsByName = new (CompareString, EqualsData);

        public static DebugForm DebugForm;

        public static MainForm MainForm;

        private const string PathPlayers = "Players.txt";
        private const string PathTeams = "TeamPlayers.txt";

        [STAThread]
        private static void Main()
        {
            //FileManager.GenerateFile(1000);return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            DebugForm = new DebugForm();
            if(File.Exists(PathPlayers))
                FileManager.ReadPlayers(PathPlayers);
            else if(MessageBox.Show("Не обнаружен файл \"" + PathPlayers + "\". Сгенерировать случайные данные игроков?", "Заполнение данными", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GenerateData.GeneratePlayerDataBase(1000);
                
            if(File.Exists(PathTeams))
                FileManager.ReadTeams(PathTeams);
            else if(MessageBox.Show("Не обнаружен файл \"" + PathTeams + "\". Сгенерировать случайные данные игроков команд?", "Заполнение данными", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GenerateData.GenerateTeamDataBase();

            Application.Run(MainForm = new MainForm());
        }

        public static bool RemoveData(Player dataLink)
        {
            var data = new Player(dataLink);
            var list = _treeTeamsByName.Find(data.Name).GetList();
            if (list.Count > 0)
            {
                var dialogResult = MessageBox.Show("В справочнике \"Игроки команд\" есть связанные записи. Они тоже будут удалены. Вы действительно хотите продолжить?", "Обнаружена связность", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return false;
            }
            foreach (var t in list)
                RemoveData(t);
            
            if(ListPlayers.Remove(dataLink) == false)
                throw new Exception("Запись не найдена");
            
            if(TreePlayers.Remove(data, data.Birthday) == false)
                MessageBox.Show("Не удалось удалить из дерева игроков (общая задача поиска)", "Ошибка???", MessageBoxButtons.OK);
            if(HsTbPlayers.Remove(data, data.Name) == -1)
                MessageBox.Show("Не удалось удалить из хеш-таблицы игроков (проверка уникальности)", "Ошибка???", MessageBoxButtons.OK);
            
            //Debug
            DebugForm.UpdateHashTablePlayers();
            DebugForm.ReBuildTree(TreePlayers, DebugForm.treeView1, DebugForm.ConvertByDate);
            return true;
        }

        public static void RemoveData(TeamPlayer dataLink)
        {
            var data = new TeamPlayer(dataLink);
            if (!ListTeams.Remove(dataLink))
                throw new Exception("Запись не найдена");
            
            if(TreeTeams.Remove(data, data.Role) == false)
                MessageBox.Show("Не удалось удалить из дерева команд (общая задача поиска)", "Ошибка???", MessageBoxButtons.OK);
            if(HsTbTeams.Remove(data, data.PlayerName + data.TeamName) == -1)
                MessageBox.Show("Не удалось удалить из хеш-таблицы команд (проверка уникальности)", "Ошибка???", MessageBoxButtons.OK);
            if(_treeTeamsByName.Remove(data, data.PlayerName) == false)
                MessageBox.Show("Не удалось удалить из дерева команд (для связанного удаления)", "Ошибка???", MessageBoxButtons.OK);
            
            //Debug
            DebugForm.UpdateHashTableTeams();
            DebugForm.ReBuildTree(TreeTeams, DebugForm.treeView2, DebugForm.ConvertByRole);
            DebugForm.ReBuildTree(_treeTeamsByName, DebugForm.treeView3, DebugForm.ConvertByName);
        }

        public static void AddData(Player data)
        {
            ListPlayers.Add(data);
            TreePlayers.Add(data, data.Birthday);
            HsTbPlayers.Add(data, data.Name);
            DebugForm.UpdateHashTablePlayers();
            DebugForm.ReBuildTree(TreePlayers, DebugForm.treeView1, DebugForm.ConvertByDate);
        }

        public static void AddData(TeamPlayer data)
        {
            ListTeams.Add(data);
            TreeTeams.Add(data, data.Role);
            HsTbTeams.Add(data, data.PlayerName + data.TeamName);
            _treeTeamsByName.Add(data, data.PlayerName);

            DebugForm.UpdateHashTableTeams();
            DebugForm.ReBuildTree(TreeTeams, DebugForm.treeView2, DebugForm.ConvertByRole);
            DebugForm.ReBuildTree(_treeTeamsByName, DebugForm.treeView3, DebugForm.ConvertByName);
        }
        
        public static void ClearData(bool playersClear, bool teamsClear)
        {
            if (playersClear)
            {
                ListPlayers = new List<Player>();
                HsTbPlayers = new HashTable<Player> {
                    OnResize = DebugForm.UpdateHashTablePlayers //Debug
                };
                TreePlayers = new RbTree<Player, DateTime>(CompareDateTime, EqualsData);
                //Debug
                DebugForm.UpdateHashTablePlayers();
                DebugForm.ReBuildTree(TreePlayers, DebugForm.treeView1, DebugForm.ConvertByDate);
            }

            if (teamsClear)
            {
                TreeTeams = new RbTree<TeamPlayer, string>(CompareString, EqualsData);
                ListTeams = new List<TeamPlayer>();
                HsTbTeams = new HashTable<TeamPlayer>() {
                    OnResize = DebugForm.UpdateHashTableTeams//Debug
                };
                _treeTeamsByName = new RbTree<TeamPlayer, string>(CompareString, EqualsData);
                //Debug
                DebugForm.UpdateHashTableTeams();
                DebugForm.ReBuildTree(TreeTeams, DebugForm.treeView2, DebugForm.ConvertByRole);
                DebugForm.ReBuildTree(_treeTeamsByName, DebugForm.treeView3, DebugForm.ConvertByName);
            }
        }

        private static int CompareDateTime(DateTime data1, DateTime data2) => data1.CompareTo(data2); 

        private static int CompareString(string data1, string data2) => string.Compare(data1, data2, StringComparison.Ordinal);
        
        //public static bool CompareData<TData>(TData data1, TData data2) => data1.Equals(data2);
        private static bool EqualsData(Player data1, Player data2)
        {
            if (data1.Birthday == data2.Birthday && data1.Name == data2.Name)
                return !data1.SportTypes.Where((t, i) => t != data2.SportTypes[i]).Any();
            return false;
        }
        private static bool EqualsData(TeamPlayer data1, TeamPlayer data2)
        {
            return data1.PlayerName == data2.PlayerName && data1.TeamName == data2.TeamName && data1.Role == data2.Role && data1.SportType == data2.SportType;
        }
        
    }
}
