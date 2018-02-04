using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adventure_Game_Engine
{ 
    public partial class Form1 : Form
    {
        World world = new World();
        Location currentLocation;
        Location tempLocation;
        Zone currentZone;

        bool isRoomExisting = false;
        //bool isZoneExisting = false;


        public Form1()
        {
            InitializeComponent();
            world.Create();
            reInitializeForm();
            refreshCbZone();
            btnNewZone.Select();
        }


        #region HELPERS FUNCTIONS
        private void refreshCbZone()
        {
            string[] zoneName = world.GetAllZones();
            Array.Sort(zoneName);
            cbZone.Items.Clear();
            cbZone.Items.AddRange(zoneName);

            if (cbZone.Items.Count > 0)
            {
                cbZone.SelectedIndex = 0;
                setAllControlsToEnable(true);
            }
            else
            {
                setAllControlsToEnable(false);
                btnNewZone.Enabled = true;
            }

        }
        private void refreshCbZoneAndSelectDefinedZone(string zoneToSelect)
        {
            refreshCbZone();
            if (cbZone.Items.Count > 0)
            {
                cbZone.SelectedItem = zoneToSelect;
            }
        }
        private bool isFormValid()
        {
            if (string.IsNullOrWhiteSpace(cbLocation.Text))
            {
                string errorCb;
                if (string.IsNullOrWhiteSpace(cbZone.Text))
                {
                    errorCb = "zone name";
                    cbZone.Select();
                }
                MessageBox.Show("You must at least input or select a location name");
                return false;
            }
            else
            {
                return true;
            }
        }//Show error to user if no location name has been input.
        private void setAllControlsToEnable(bool state)
        {
            cbZone.Enabled = state;
            cbLocation.Enabled = state;
            tbLocDesc.Enabled = state;
            lbAccessPoints.Enabled = state;
            btnAddEdditAccessPoint.Enabled = state;
            btnAddRoom.Enabled = state;
            btnDeleteRoom.Enabled = state;
            btnUpdateDb.Enabled = state;
        }
        private void reInitializeForm()
        {
            tempLocation = new Location("", "");
            currentLocation = null;
            world.Populate();
            clearAllFields();
            if (world.zones.Count < 1)
            {
                cbZone.Select();
            }
            else
            {
                cbLocation.Select();
            }
        }
        private void clearAllFields()
        {
            cbZone.Text = "";
            cbLocation.Text = "";
            tbLocDesc.Text = "";
        }
        private void createNewLocation()
        {
            currentLocation = new Location(cbLocation.Text, tbLocDesc.Text);
            currentZone.AddLocation(currentLocation);
            reInitializeForm();
        }
        private void setLastZoneEditedAsActiveZone(string lastZoneEdited)
        {
            if (world.zones.Count > 0)
            {

                if (lastZoneEdited != null)
                {
                    refreshCbZoneAndSelectDefinedZone(lastZoneEdited);
                }
                else
                {
                    refreshCbZone();
                }
                cbLocation.Select();
            }
            else
            {
                refreshCbZone();
                btnNewZone.Select();
            }
        }
        #endregion

        #region LISTENERS
        private void editForm_Closed(object sender, FormClosedEventArgs e)
        {
            EditZonesForm editZonesForm = (EditZonesForm)sender;
            clearAllFields();
            string lastZoneEdited = editZonesForm.lastZoneEdited;
            setLastZoneEditedAsActiveZone(lastZoneEdited);
        }
        private void OnCbZoneValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            currentZone = world.GetZoneFromString(cb.SelectedItem.ToString());
        }
        #endregion

        #region BTN
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (isFormValid())//show a warning to user telling him what s wrong with his form.
            {

                if (isRoomExisting) //if the room is already existing we save changes to it.
                {

                }
                else //if the room is not existing we add it to the current zone.
                {
                    createNewLocation();
                }

            }
        }
        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            foreach (Zone zone in world.zones.Values)
            {

                Console.WriteLine($"{ zone.Name}");
                Console.WriteLine("***********************");
                foreach (Location loc in zone.Locations)
                {
                    Console.WriteLine($"{loc.Title}");
                    //Console.WriteLine($"Id: {loc.Id}");
                }
                Console.WriteLine("\n");
            }
        }
        private void btnAddEdditAccessPoint_Click(object sender, EventArgs e)
        {

        }
        private void btnNewZone_Click(object sender, EventArgs e)
        {
            EditZonesForm editZoneForm = new EditZonesForm(world);
            editZoneForm.Show();
            editZoneForm.FormClosed += new FormClosedEventHandler(editForm_Closed);


        }
        #endregion

        
    }


}
