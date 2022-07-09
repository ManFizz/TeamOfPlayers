using System;
using System.Collections.Generic;
using System.Linq;
using TeamOfPlayers.Structures;

namespace TeamOfPlayers.Utilities
{
    internal static class GenerateData
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
        private static List<string> _roles;

        private static List<TeamPlayer> GenerateTeamsForPlayer(Player player, List<TeamPlayer> players)
        {
            if (_roles is null)
            {
                _roles = new List<string>(20);
                for (var i = 0; i < 30; i++)
                    _roles.Add(GenerateName());
            }
            
            var outList = new List<TeamPlayer>();
            var max = Rand.Next(1, 4);
            for(var i = 0; i < max; i++)
            {
                var iTeam = Rand.Next(10);
                TeamCounter team = null;
                foreach (var t in Teams)
                {
                    if (!player.SportTypes.Contains(t.SportType) || t.PlayersCount >= iTeam)
                        continue;

                    if (players.Any(p => p.PlayerName == player.Name && p.TeamName == t.Name))
                        continue;
                    
                    if (outList.Any(p => p.PlayerName == player.Name && p.TeamName == t.Name))
                        continue;

                    team = t;
                    break;
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

        private static Player GeneratePlayer() { return new Player(GenerateFullName(), GenerateDay(), GenerateListName()); }

        private static DateTime GenerateDay() { return new DateTime(1965, 1, 1).AddDays(Rand.Next(18000)); }
         
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
            var b = 2;
            while (b < len)
            {
                name += consonants[Rand.Next(consonants.Length)];
                b++;
                name += vowels[Rand.Next(vowels.Length)];
                b++;
            }

            return name;
        }

        public static void GenerateDataBase(int count)
        {
            GeneratePlayerDataBase(count);
            GenerateTeamDataBase();
        }

        public static void GenerateTeamDataBase()
        {
            foreach (var player in Program.ListPlayers)
            {
                var teamPlayers = GenerateTeamsForPlayer(player, Program.ListTeams);
                teamPlayers.ForEach(Program.AddData);
            }
        }

        public static void GeneratePlayerDataBase(int count)
        { 
            for (var i = 0; i < count; i++)
                Program.AddData(GeneratePlayer());
        }
    }
}
