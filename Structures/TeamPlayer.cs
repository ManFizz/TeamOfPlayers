namespace TeamOfPlayers.Structures
{
    public class TeamPlayer
    {
        //Unique
        public string PlayerName { set; get; }
        public string TeamName { set; get; }

        //Some info
        public string Role { set; get; }
        public string SportType { set; get; }

        public TeamPlayer(string playerName, string teamName, string role, string sportType)
        {
            PlayerName = playerName;
            TeamName = teamName;
            Role = role;
            SportType = sportType;
        }
    }
}