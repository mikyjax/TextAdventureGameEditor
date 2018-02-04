using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure_Game_Engine
{
    public partial class EditZonesForm : Form   //This Form gives the possibility to the user to add, rename or delete a Zone.
    {                                           //A Zone could be a house that would contain a list of specific locations like Bedrooms.
        bool isUserEditingAZone = false;        //by default the form is setup for creating a new zone
        World world;
        public string lastZoneEdited { get; set; } //when this form is closed the lastZoneEdited will be selected in the main form.
        List<String> zoneNames = new List<String>();
        string newRoomText = ".Create New Zone";//this string will be added to the list box.When this is selected, the user wants to create a room
                                                //It's always selected by default.
        public EditZonesForm(World _world)
        {
            world = _world;
            InitializeComponent();
            refreshLbZone();//reset the list box and add "Create new Room" on top. bring the user selection to the textbox for new input.
            lastZoneEdited = null;
        }

        #region BTN
        private void btnAddOrEditZone_Click(object sender, EventArgs e)//this is the main button, it could be "Add zone" or "Edit selected Zone"
        {
            String newZoneName = tbNameZone.Text.Trim();            //remove spaces before and after user input.
            if (isUserEditingAZone)                                 //if something else than ".Create New Zone" is selected... 
            {                                                           //...the user wants to change the name of a zone
                string oldKey = lbZones.SelectedItem.ToString();        //get old name from list box
                string newKey = tbNameZone.Text;                        //get new name from text box
                if (newKey != oldKey)                                    //if names are different
                {
                    world.RenameZone(oldKey, newZoneName);              //rename the zone
                    refreshLbZone();//reset the list box and add "Create new Zone" on top. bring the user selection to the textbox for new input.
                    lastZoneEdited = newKey;
                }
            }
            else                                                    //else, "Create new Zone" is selected
            {
                if (!string.IsNullOrWhiteSpace(tbNameZone.Text))    //if text box is not empty..
                {
                    if (!world.isZoneExisting(newZoneName))             //and if the name of the zone isn't already used...
                    {
                        world.CreateNewZone(newZoneName);                   //we create the new zone.
                        refreshLbZone();//reset the list box and add "Create new Zone" on top. bring the user selection to the textbox for new input.
                        lastZoneEdited = newZoneName;
                    }
                    else                                                //Else we tell the user it already exists
                    {
                        MessageBox.Show("A zone with that name already exists");
                        refreshLbZone();//reset the list box and add "Create new Zone" on top. bring the user selection to the textbox for new input.
                    }

                }
            }

        }
        private void btnDeleteZone_Click(object sender, EventArgs e)
        {
            if (lbZones.SelectedItem.ToString() == tbNameZone.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the zone and all its locations", "Delete Zone", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    //delete the zone
                    world.DeleteZone(tbNameZone.Text);
                    lastZoneEdited = null;
                    refreshLbZone();//reset the list box and add "Create new Zone" on top. bring the user selection to the textbox for new input.
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region LISTENERS
        private void OnSelectedIndexChanged(object sender, EventArgs e) //When a user select a zone in the list box
        {
            if (lbZones.SelectedItem.ToString() == newRoomText)         //if "Create new Zone" is selected
            {
                btnDeleteZone.Enabled = false;                              //no delete possible
                tbNameZone.Text = "";                                       //empty the text box
                btnAddOrEditZone.Text = "Add new Zone";                     //change name of button
                isUserEditingAZone = false;                                 //this flag will tell us that the user wants to create a new zone
            }
            else                                                        //if "Create new zone" is NOT selected, user wants to change name or delete a zone                    
            {
                btnDeleteZone.Enabled = true;                               //user is able to delete
                tbNameZone.Text = lbZones.SelectedItem.ToString();          //writes the name of the selected zone in text box for Editing/deleting
                btnAddOrEditZone.Text = "Change name of the selected zone"; //change name of button
                isUserEditingAZone = true;                                  //this flag will tell us that the user wants to edit an existing zone.
            }
        }
        private void OnTextChanged(object sender, EventArgs e) //when the user edit the text box
        {
            if (isUserEditingAZone && (tbNameZone.Text != lbZones.Text))// if he's in editing mode and the text isn't the same that the selected text
            {
                btnDeleteZone.Enabled = false; //we only allow him to change the name of the zone. 
            }
            else                        //else if both text are identical, user is allowed to delete the current zone.
            {
                btnDeleteZone.Enabled = true;
            }
        }
        #endregion
        #region HELPERS FUNCTIONS
        private void refreshLbZone()
        {
            lbZones.Items.Clear();
            zoneNames.Clear();
            zoneNames.Add(newRoomText);
            foreach (String zoneName in world.zones.Keys)
            {
                zoneNames.Add(zoneName);
            }
            zoneNames.Sort();
            lbZones.Items.AddRange(zoneNames.ToArray());
            lbZones.SelectedItem = newRoomText;
            tbNameZone.Select();
            tbNameZone.Text = "";
        }
        #endregion
    }
}
