using System;
using System.Windows.Forms;
using TeamOfPlayers.Structures;
using TeamOfPlayers.Utilities;

namespace TeamOfPlayers.Forms
{
    public partial class AddTeamForm : Form
    {
        public AddTeamForm()
        {
            InitializeComponent();
        }
        
        private void AddPlayerButton2_Click(object sender, EventArgs e)
        {
            var name = textBoxFIO.Text.Trim(' ');
            var team = textBoxTeam.Text.Trim(' ');
            var role = textBoxRole.Text.Trim(' ');
            var sport = textBoxSport.Text.Trim(' ');
            TeamPlayer teamPlayer;
            try
            {
                teamPlayer = FileManager.ParseTeamPlayer(name + ";" + team + ";" + role + ";" + sport);
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Игрок не добавлен",  MessageBoxButtons.OK);
                return;
            }
            
            if (Program.HsTbPlayers.GetPos(teamPlayer.PlayerName) == -1)
            {
                MessageBox.Show("Такого игрока нету в таблице \"Игроки\"","Игрок не добавлен",  MessageBoxButtons.OK);
                return;
            }
            
            if (Program.HsTbTeams.GetPos(teamPlayer.PlayerName + teamPlayer.TeamName) != -1)
            {
                MessageBox.Show("Такой игрок в этой команде уже есть","Игрок не добавлен",  MessageBoxButtons.OK);
                return;
            }

            Program.AddData(teamPlayer);
            Program.MainForm.UpdateVisual(MainForm.UpdateState.TeamTable);
            MessageBox.Show("Игрок " + teamPlayer.PlayerName + " успешно добавлен в команду " + teamPlayer.TeamName,"Игрок добавлен",  MessageBoxButtons.OK);
            this.Close();
        }
    }
}
