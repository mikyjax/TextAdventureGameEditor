using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventureCommon;

namespace TextAdventureGame
{
    public partial class WordForm : Form
    {
        const string sayYouMustInputSingular = "You must input the singular.";

        private string formError = null;

        private WordDictionary dictionary = null;
        private GNoun nounToEdit = null;
        public WordForm(WordDictionary _dictionary, ref GNoun _nounToEdit)
        {
            nounToEdit = _nounToEdit;
            dictionary = _dictionary;
            InitializeComponent();

            if (dictionary.IsExisting(nounToEdit))
            {
                int existingNounId =  dictionary.GetNounIdByName(nounToEdit.Singular);
                nounToEdit = dictionary.GetNounById(existingNounId);
                updateFormFromNoun();
            }
            else
            {
                tBSingularNoun.Text = nounToEdit.Singular;
                tBPluralNoun.Text = Grammar.GuessPlural(nounToEdit.Singular);
            }

        }

        private void btnSaveNoun_Click(object sender, EventArgs e)
        {
            formError = GetFormError();
            if (formError == null)
            {
                updateNounFromForm();
                if (nounToEdit.ID == 0)
                {
                    dictionary.Add(nounToEdit);
                }
                else
                {
                    dictionary.EditNoun(nounToEdit);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(formError);
            }

            
        }

        private void updateNounFromForm()
        {
            nounToEdit.Singular = tBSingularNoun.Text.Trim().ToLower();
            nounToEdit.Plural = tBPluralNoun.Text.Trim().ToLower();
            nounToEdit.Elision = chBxHasElisionNoun.Checked;
            if (chBxIsMascNoun.Checked)
            {
                nounToEdit.Genre = Genre.masuclin;
            }
            else
            {
                nounToEdit.Genre = Genre.feminin;
            }
        }
        private void updateFormFromNoun()
        {
            tBSingularNoun.Text = nounToEdit.Singular;
            tBPluralNoun.Text = nounToEdit.Plural;
            chBxHasElisionNoun.Checked = nounToEdit.Elision  ? true : false;
            chBxIsMascNoun.Checked = nounToEdit.Genre == Genre.masuclin ? true : false;
        }

        private string GetFormError()
        {
            if(string.IsNullOrWhiteSpace(tBSingularNoun.Text))
            {
                return sayYouMustInputSingular;
            }
            return null;
        }

        private void btnCancelNoun_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
