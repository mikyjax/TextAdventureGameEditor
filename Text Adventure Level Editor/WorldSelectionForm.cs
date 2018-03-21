using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using TextAdventureCommon;

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

        List<GameInfos> games = new List<GameInfos>();
        private GameInfos gameToEdit;
        DataManager dataManager = new DataManager();

        public WorldSelectionForm(GameInfos _game)
        {
            InitializeComponent();
            gameToEdit = _game;
            lblGreetings.Text = greetings;
            GetListOfGames();
            cbTitle.Items.Clear();
            GetGamesTitlesInCbTitles();
            cbTitle.Select();
        }

        private void GetGamesTitlesInCbTitles()
        {
            List<string> gameTitles = new List<string>();
            foreach (GameInfos game in games)
            {
                gameTitles.Add(game.GameTitle);
            }
            gameTitles.Sort();

            cbTitle.Items.AddRange(gameTitles.ToArray());
        }
        private void GetListOfGames()
        {
            string[] fileNames = Directory.GetFileSystemEntries("Games");

            foreach (string fileNamePath in fileNames)
            {
                games.Add(dataManager.GetAvailableGame(fileNamePath));
            }

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            GetGameNameFromCbTitles();
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
                GoToNewGame();
            }
        }

        private void GetGameNameFromCbTitles()
        {
            gameTitle = cbTitle.Text;
            gameTitle = gameTitle.Trim();
            fileName = gameTitle;
            fileName = fileName.ToLower();
        }
        private void GoToNewGame()
        {
            fileName = fileName + ".xml";
            gameToEdit.GameTitle = gameTitle;
            gameToEdit.WorldFileName = fileName;

            if (!IsGameExisting())   //Edit Game existing
            {
                fileName = fileName + ".xml";
                cbTitle.Text = fileName;
            }
            

            this.Close();
        }

        private bool IsGameExisting()
        {
            foreach (GameInfos game in games)
            {
                if (game.GameTitle == gameToEdit.WorldFileName)
                {
                    return true;
                }
            }
            return true;
        }
    }
}
