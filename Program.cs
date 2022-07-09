using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public static RbTree<Player, DateTime> TreePlayers = new ();
        public static RbTree<TeamPlayer, string> TreeTeams = new ();
        
        //Хеш-таблицы для проверки уникальности
        public static HashTable<Player> HsTbPlayers = new () {
            OnResize = DebugForm.OnResizeHashTablePlayers
        };
        public static HashTable<TeamPlayer> HsTbTeams = new() {
            OnResize = DebugForm.OnResizeHashTableTeams
        };
        
        //Дерево для поиска игрока команды, при удалении самого игрока
        public static RbTree<TeamPlayer, string> TreeTeamsByName = new ();

        public static DebugForm DebugForm;
        public static readonly DataTable DisplayHashTable1 = new ();
        public static readonly DataTable DisplayHashTable2 = new ();

        public static MainForm MainForm;

        private static string PathPlayers { get; } = "Players.txt";
        private static string PathTeams { get; } = "TeamPlayers.txt";

        [STAThread]
        private static void Main()
        {
            //FileManager.GenerateFile(1000);return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var t = DisplayHashTable1.Columns.Add("pos");
            t.DataType = typeof(int);
            t.Unique = true;
            DisplayHashTable1.PrimaryKey = new [] {t};
            DisplayHashTable1.Columns.Add("ФИО");
            t = DisplayHashTable1.Columns.Add("Дата рождения");
            t.DataType = typeof(DateTime);
            t.DateTimeMode = DataSetDateTime.Utc;
            DisplayHashTable1.Columns.Add("Виды спорта");
            
            t = DisplayHashTable2.Columns.Add("pos");
            t.DataType = typeof(int);
            t.Unique = true;
            DisplayHashTable2.PrimaryKey = new [] {t};
            DisplayHashTable2.Columns.Add("ФИО");
            DisplayHashTable2.Columns.Add("Команда");
            DisplayHashTable2.Columns.Add("Роль");
            DisplayHashTable2.Columns.Add("Вид спорта");
            
            DebugForm = new DebugForm();
            if(File.Exists(PathPlayers))
                FileManager.ReadPlayers(PathPlayers);
            else if(MessageBox.Show("Не обнаружен файл \"" + PathPlayers + "\". Сгенерировать случайные данные игроков?", "Заполнение данными", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GenerateData.GeneratePlayerDataBase(1000);
                
            if(File.Exists(PathTeams))
                FileManager.ReadTeams(PathTeams);
            else if(MessageBox.Show("Не обнаружен файл \"" + PathTeams + "\". Сгенерировать случайные данные игроков команд?", "Заполнение данными", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GenerateData.GenerateTeamDataBase();

            
            DebugForm.dataGridView1.DataSource = DisplayHashTable1;
            DebugForm.dataGridView2.DataSource = DisplayHashTable2;
            
            Application.Run(MainForm = new MainForm());
        }

        public static bool RemoveData(Player data)
        {
            var list = TreeTeamsByName.FindList(data.Name);
            if (list.Count > 0)
            {
                var dialogResult = MessageBox.Show("В справочнике \"Игроки команд\" есть связанные записи. Они тоже будут удалены. Вы действительно хотите продолжить?", "Обнаружена связность", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return false;
            }
            foreach (var t in list)
                RemoveData(t.Data);
            
            if(ListPlayers.Remove(data) == false)
                throw new Exception("Запись не найдена");
            
            TreePlayers.Remove(data, data.Birthday);
            var htPos = HsTbPlayers.Remove(data, data.Name);


            //Debug
            DisplayHashTable1.Rows.Remove(DisplayHashTable1.Rows.Find(htPos));
            DebugForm.ReBuildTreePlayers(TreePlayers);
            return true;
        }

        public static void RemoveData(TeamPlayer data)
        {
            if (!ListTeams.Remove(data))
                throw new Exception("Запись не найдена");
            
            TreeTeams.Remove(data, data.Role);
            var htPos  =  HsTbTeams.Remove(data, data.PlayerName + data.TeamName);
            TreeTeamsByName.Remove(data, data.PlayerName);
            
            //Debug
            DisplayHashTable2.Rows.Remove(DisplayHashTable2.Rows.Find(htPos));
            DebugForm.ReBuildTreeTeams(TreeTeams);
            DebugForm.ReBuildTreeTeamsByName(TreeTeamsByName);
        }

        public static void AddData(Player data)
        {
            ListPlayers.Add(data);
            TreePlayers.Add(data, data.Birthday);
            var htPos = HsTbPlayers.Add(data, data.Name);
            DebugForm.DebugAddRow(data, htPos);
            DebugForm.ReBuildTreePlayers(TreePlayers);
        }

        public static void AddData(TeamPlayer data)
        {
            ListTeams.Add(data);
            TreeTeams.Add(data, data.Role);
            var htPos = HsTbTeams.Add(data, data.PlayerName + data.TeamName);
            TreeTeamsByName.Add(data, data.PlayerName);

            DebugForm.DebugAddRow(data, htPos);
            DebugForm.ReBuildTreeTeams(TreeTeams);
            DebugForm.ReBuildTreeTeamsByName(TreeTeamsByName);
        }
        
        public static void ClearData(bool playersClear, bool teamsClear)
        {
            if (playersClear)
            {
                ListPlayers = new List<Player>();
                HsTbPlayers = new HashTable<Player> {
                    OnResize = DebugForm.OnResizeHashTablePlayers //Debug
                };
                TreePlayers = new RbTree<Player, DateTime>();
                //Debug
                DisplayHashTable1.Rows.Clear();
                DebugForm.ReBuildTreePlayers(TreePlayers);
            }

            if (teamsClear)
            {
                TreeTeams = new RbTree<TeamPlayer, string>();
                ListTeams = new List<TeamPlayer>();
                HsTbTeams = new HashTable<TeamPlayer>() {
                    OnResize = DebugForm.OnResizeHashTableTeams//Debug
                };
                TreeTeamsByName = new RbTree<TeamPlayer, string>();
                //Debug
                DisplayHashTable2.Rows.Clear();
                DebugForm.ReBuildTreeTeams(TreeTeams);
                DebugForm.ReBuildTreeTeamsByName(TreeTeamsByName);
            }
        }

        public static int CompareKeys<TKey>(TKey key1, TKey key2)
        {
            if ((key1 is DateTime && DateTime.Parse(key1.ToString()) < DateTime.Parse(key2.ToString()) ||
                 key1 is not DateTime && string.CompareOrdinal(key1.ToString(), key2.ToString()) < 0))
                return -1;

            if ((key1 is DateTime && DateTime.Parse(key1.ToString()) > DateTime.Parse(key2.ToString()) ||
                 key1 is not DateTime && string.CompareOrdinal(key1.ToString(), key2.ToString()) > 0))
                return 1;

            return 0;
        }
    }
}
