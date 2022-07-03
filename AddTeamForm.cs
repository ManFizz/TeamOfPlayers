using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamOfPlayers
{
    public partial class AddTeamForm : Form
    {
        private RbTree<Player, DateTime> _dataBase1;
        private RbTree<TeamPlayer, string> _dataBase2;

        public AddTeamForm()
        {
            InitializeComponent();
        }

        private void AddTeamForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSport2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTeam_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFIO2_TextChanged(object sender, EventArgs e)
        {

        }


        private void AddPlayerButton2_Click(object sender, EventArgs e)
        {
            //UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO2.Text.Trim(' ');
            var team = textBoxTeam.Text.Trim(' ');
            var role = textBoxRole.Text.Trim(' ');
            var sport = textBoxSport2.Text.Trim(' ');
            TeamPlayer player = null;
            try
            {
                player = FileManager.ParseTeamPlayer(name + ";" + team + ";" + role + ";" + sport);
            }
            catch (Exception exception)
            {
                //ErrorLabel.Text = exception.Message;
                return;
            }

            //var fCheck = _dataBase1.GetList();
            //if (fCheck.All(p => p.Name != name))
            {
                //ErrorLabel.Text = "Такого игрока нету в таблице \"Игроки\"";
                return;
            }

            //var fPlayer = _dataBase2.GetList();
            //if (fPlayer.Any(p => name == p.PlayerName && team == p.TeamName))
            {
                //ErrorLabel.Text = "Такой игрок в этой команде уже есть";
                return;
            }

            _dataBase2.Add(player, player.Role);

            //_teamDataTable.Rows.Add(CreateTeamPlayerRow(_teamDataTable, player));
            //SuccesLabel.Text = ("Игрок " + player.PlayerName + " успешно добавлен");
            //Update не нужен
        }
    }
}
