using System;
using System.Collections.Generic;

namespace TeamOfPlayers.Structures
{
    public class Player
    {
        //Unique
        public string Name { set; get; }

        //Some info
        public DateTime Birthday { set; get; }
        public List<string> SportTypes { set; get; }

        public Player(string name, DateTime birthday, List<string> sportTypes)
        {
            Name = name;
            Birthday = birthday;
            SportTypes = sportTypes;
        }

        public Player(Player data)
        {
            Name = data.Name;
            Birthday = data.Birthday;
            SportTypes = new List<string>(data.SportTypes);
        }
    }
}