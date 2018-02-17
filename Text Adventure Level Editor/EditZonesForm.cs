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
    public partial class EditZonesForm : Form   //This Form gives the possibility to the user to add, rename or delete a Zone.
    {                                           //A Zone could be a house that would contain a list of specific locations like Bedrooms.
        bool isUserEditingAZone = false;        //by default the form is setup for creating a new zone
        World world;
        public string lastZoneEdited { get; set; } //when this form is closed the lastZoneEdited will be selected in the main form.
        List<String> zoneNames = new List<String>();
        string newRoomText = ".Create New Zone";

        public EditZonesForm(World _world)
        {
            world = _world;
            InitializeComponent();
            RefreshLbZone();
            lastZoneEdited = null;
        }

        #region BTN
        private void btnAddOrEditZone_Click(object sender, EventArgs e)
        {
            String newZoneName = tbNameZone.Text.Trim();            //remove spaces before and after user input.
            if (isUserEditingAZone)                                 
            {                                                          
                RenameZone(newZoneName);
            }
            else                                                    
            {
                CreateNewZone(newZoneName);
            }

        }
        private void btnDeleteZone_Click(object sender, EventArgs e)
        {
            if (lbZones.SelectedItem.ToString() == tbNameZone.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the zone and all its locations", "Delete Zone", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    world.DeleteZone(tbNameZone.Text);
                    lastZoneEdited = null;
                    RefreshLbZone();
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region LISTENERS
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbZones.SelectedItem.ToString() == newRoomText)         //if "Create new Zone" is selected
            {
                btnDeleteZone.Enabled = false;                              
                tbNameZone.Text = "";                                       
                btnAddOrEditZone.Text = "Add new Zone";                     
                isUserEditingAZone = false;                                 
            }
            else                                                                   
            {
                btnDeleteZone.Enabled = true;                               
                tbNameZone.Text = lbZones.SelectedItem.ToString();          
                btnAddOrEditZone.Text = "Change name of the selected zone"; //change name of button
                isUserEditingAZone = true;                                  
            }
        }
        private void OnTextChanged(object sender, EventArgs e) 
        {
            if (isUserEditingAZone && (tbNameZone.Text != lbZones.Text))//
            {
                btnDeleteZone.Enabled = false; 
            }
            else                        
            {
                btnDeleteZone.Enabled = true;
            }
        }
        #endregion
        #region HELPERS FUNCTIONS
        private void RefreshLbZone()
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
        private void RenameZone(string newZoneName)
        {
            string oldKey = lbZones.SelectedItem.ToString();        
            string newKey = tbNameZone.Text;                        
            if (newKey != oldKey)                                    
            {
                world.RenameZone(oldKey, newZoneName);              
                RefreshLbZone();
                lastZoneEdited = newKey;
            }
        }
        private void CreateNewZone(string newZoneName)
        {
            if (!string.IsNullOrWhiteSpace(tbNameZone.Text))    
            {
                if (!world.IsZoneExisting(newZoneName))             
                {
                    world.CreateNewZone(newZoneName);                  
                    RefreshLbZone();
                    lastZoneEdited = newZoneName;
                }
                else                                                
                {
                    MessageBox.Show("A zone with that name already exists");
                    RefreshLbZone();
                }

            }
        }
        #endregion
    }
}
