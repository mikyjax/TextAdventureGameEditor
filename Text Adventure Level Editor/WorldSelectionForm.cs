using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAdventureGame
{
    public partial class WorldSelectionForm : Form
    {
        string greetings =  "Welcome in the Text Adventure Level Editor!\n\n" +
                            "From here you can either type a new name in the " +
                            "texbox to create a new game or simply select one " +
                            "you are already working on.";

        string gameTitle = "";
        string fileName = "";
        List<Game> games = new List<Game>();
        private Game gameToEdit;

        public WorldSelectionForm(Game _game)
        {
            InitializeComponent();
            gameToEdit = _game;
            lblGreetings.Text = greetings;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            gameTitle = cbTitle.Text;
            gameTitle = gameTitle.Trim();
            fileName = gameTitle;
            fileName = fileName.ToLower();
            string[] invalidChar;
            if (fileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1 || string.IsNullOrWhiteSpace(fileName))
            {
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show("You must select or type a name in the text box");
                }
                else
                {
                    MessageBox.Show("The filename is invalid, please avoid special characters");
                }
                return;
            }
            else
            {
           
                fileName = fileName + ".xml";
                cbTitle.Text = fileName;
                gameToEdit.Title = gameTitle;
                gameToEdit.FileName = fileName;
                this.Close();
            }
        }

       
    }
}
