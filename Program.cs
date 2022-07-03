using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TeamOfPlayers
{
    internal static class Program
    {
        public static List<Player> ListPlayers = new List<Player>();
        public static List<TeamPlayer> ListTeams = new List<TeamPlayer>();
        public static readonly RbTree<Player, DateTime> RbTreePlayers = new RbTree<Player, DateTime>();
        public static readonly RbTree<TeamPlayer, string> RbTreeTeams = new RbTree<TeamPlayer, string>();
        public static HashTable<Player> HashTablePlayers = new HashTable<Player>();

        //public static HashTable<TeamPlayer> _hashTableTeams = new HashTable<TeamPlayer>();

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FileManager.Path = @"C:\Users\Mak\OneDrive\Рабочий стол\Учеба\TeamOfPlayers\";
            var loadForm = new LoadForm();
            loadForm.Show();

            FileManager.ReadPlayers("inputPlayers.txt", ref ListPlayers);
            FileManager.ReadTeams("inputTeamPlayers.txt", ref ListTeams);



            foreach (var player in ListPlayers)
                RbTreePlayers.Add(player, player.Birthday);

            foreach (var player in ListPlayers)
                HashTablePlayers.Add(player, player.Name);

            foreach (var player in ListTeams)
                RbTreeTeams.Add(player, player.Role);

            //Add hash team table TODO

            var mainForm = new MainForm();
            mainForm.InitData();
            //loadForm.Close();
            Application.Run(mainForm);
        }

        public static void RemoveData(Player data)
        {
            ListPlayers.Remove(data);
            RbTreePlayers.Remove(data, data.Birthday);
            HashTablePlayers.Remove(data, data.Name);
        }

        public static void RemoveData(TeamPlayer data)
        {
            ListTeams.Remove(data);
            RbTreeTeams.Remove(data, data.Role);
            //_hashTableTeams.Remove(data, data.);
        }

        public static void AddData(Player data)
        {
            ListPlayers.Add(data);
            RbTreePlayers.Add(data, data.Birthday);
            HashTablePlayers.Add(data, data.Name);
        }

        public static void AddData(TeamPlayer data)
        {
            ListTeams.Add(data);
            RbTreeTeams.Add(data, data.Role);
            //_hashTableTeams.Add(data, data.);
        }

        public static int CompareKeys<TKey>(TKey key1, TKey key2)
        {
            if ((key1 is DateTime && DateTime.Parse(key1.ToString()) < DateTime.Parse(key2.ToString()) ||
                 !(key1 is DateTime) && string.CompareOrdinal(key1.ToString(), key2.ToString()) < 0))
                return -1;

            if ((key1 is DateTime && DateTime.Parse(key1.ToString()) > DateTime.Parse(key2.ToString()) ||
                 !(key1 is DateTime) && string.CompareOrdinal(key1.ToString(), key2.ToString()) > 0))
                return 1;

            return 0;
        }
    }
}
