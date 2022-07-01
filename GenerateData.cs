using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TeamOfPlayers
{
    internal class GenerateData
    {
        private static readonly Random Rand = new Random(DateTime.Now.Second);

        private class TeamCounter
        {
            public readonly string Name;
            public readonly string SportType;
            public int PlayersCount;

            public TeamCounter(string name, string sportType)
            {
                Name = name;
                SportType = sportType;
                PlayersCount = 0;
            }
        }
        private static readonly List<TeamCounter> Teams = new List<TeamCounter>();
        private static List<string> _roles = null;

        public static List<TeamPlayer> GenerateTeamPlayer(Player player, List<TeamPlayer> players)
        {
            if (_roles == null)
            {
                _roles = new List<string>(20);
                for (var i = 0; i < 100; i++)
                {
                    _roles.Add(GenerateName());
                }
            }
            
            var outList = new List<TeamPlayer>();
            var max = Rand.Next(1, 4);
            for(var i = 0; i < max; i++)
            {
                var iTeam = Rand.Next(10);
                TeamCounter team = null;
                foreach (var t in Teams)
                {
                    if (t.PlayersCount < iTeam && !players.Any(p => p.PlayerName == player.Name && p.TeamName == t.Name))
                    {
                        team = t;
                        break;
                    }
                }

                if (team == null)
                {
                    team = new TeamCounter(GenerateName(), player.SportTypes[Rand.Next(player.SportTypes.Count)]);
                    Teams.Add(team);
                }

                team.PlayersCount++;
                outList.Add(new TeamPlayer(player.Name, team.Name, _roles[Rand.Next(_roles.Count)], team.SportType));
            }
            return outList;
    }

        public static Player GeneratePlayer() { return new Player(GenerateFullName(), RandomDay(), GenerateListName()); }

        private static DateTime RandomDay() { return new DateTime(1965, 1, 1).AddDays(Rand.Next(18000)); }

        private static string GenerateFullName() { return GenerateName() + " " + GenerateName() + " " + GenerateName(); }

        private static List<string> GenerateListName()
        {
            var arr = new List<string>();
            var size = Rand.Next(5)+1;
            for(var i = 0; i < size; i++)
                arr.Add(GenerateName());
            return arr;
        }

        private static string GenerateName()
        {
            var len = Rand.Next(5) + 5;
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "z", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            var name = "";
            name += consonants[Rand.Next(consonants.Length)].ToUpper();
            name += vowels[Rand.Next(vowels.Length)];
            var b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                name += consonants[Rand.Next(consonants.Length)];
                b++;
                name += vowels[Rand.Next(vowels.Length)];
                b++;
            }

            return name;
        }

        public static void GenerateTeamDataBase(RbTree<Player, DateTime> PlayerBase, ref RbTree<TeamPlayer, string> rbTree)
        {
            var list = PlayerBase.GetList();
            var listTree = new List<TeamPlayer>();
            foreach (var player in list)
            {
                var teamPlayers = GenerateTeamPlayer(player, listTree);
                foreach (var teamPlayer in teamPlayers)
                {
                    listTree.Add(teamPlayer);
                    rbTree.Insert(teamPlayer, teamPlayer.Role);
                }
            }
        }
        
        public static void GeneratePlayerDataBase(ref RbTree<Player, DateTime> rbTree)
        {
            const int count = 1000;
            for (var i = 0; i < count; i++)
            {
                var player = GenerateData.GeneratePlayer();
                rbTree.Insert(player, player.Birthday);
            }
        }
    }
}
