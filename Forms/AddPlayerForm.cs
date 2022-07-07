using System;
using System.Windows.Forms;
using TeamOfPlayers.Structures;
using TeamOfPlayers.Utilities;

namespace TeamOfPlayers.Forms
{
    public partial class AddPlayerForm : Form
    {

        public AddPlayerForm()
        {
            InitializeComponent();
            ErrorLabel.Text = "";
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            var name = textBoxFIO.Text.Trim(' ');
            var date = textBoxDate.Text.Trim(' ');
            var sport = textBoxSport.Text.Trim(' ');

            Player player;
            try {
                player = FileManager.ParsePlayer(name + ";" + date + ";" + sport);
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Игрок не добавлен",  MessageBoxButtons.OK);
                return;
            }
            
            if (Program.HsTbPlayers.GetPos(player.Name) != -1)
            {
                MessageBox.Show("Игрок с таким именем уже есть","Игрок не добавлен",  MessageBoxButtons.OK);
                return;
            }

            Program.AddData(player);
            Program.MainForm.UpdateVisual(MainForm.UpdateState.PlayerTable);
            MessageBox.Show("Игрок " + player.Name + " успешно добавлен","Игрок добавлен",  MessageBoxButtons.OK);
            this.Close();
        }

    }
}
