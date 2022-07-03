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
    public partial class AddPlayerForm : Form
    {
        private RbTree<Player, DateTime> _dataBase1;
        private RbTree<TeamPlayer, string> _dataBase2;

        public AddPlayerForm(ref RbTree<Player, DateTime> db1,ref RbTree<TeamPlayer, string> db2)
        {
            _dataBase1 = db1;
            _dataBase2 = db2;
            InitializeComponent();
        }


        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            //UpdateVizual(UpdateState.ClearError);

            var name = textBoxFIO.Text.Trim(' ');
            var date = textBoxDate.Text.Trim(' ');
            var sport = textBoxSport.Text.Trim(' ');

            Player player = null;
            try
            {
                player = FileManager.ParsePlayer(name + ";" + date + ";" + sport);
            }
            catch (Exception exception)
            {
                //ErrorLabel.Text = exception.Message;
                return;
            }

            //var fPlayer = _dataBase1.GetList();
            //if (fPlayer.Any(p => player.Name == p.Name))
            {
                //ErrorLabel.Text = "Name already exists";
                return;
            }

            _dataBase1.Add(player, player.Birthday);
            //_hashTable.Add(player);

            //_playerTable.Rows.Add(CreatePlayerRow(_playerTable, player));
            //SuccesLabel.Text = ("Игрок " + player.Name + " успешно добавлен");
            //update не нужен
        }

    }
}
