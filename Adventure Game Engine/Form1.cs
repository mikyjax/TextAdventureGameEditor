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
        bool isEditMode = false;
        string btnMain1AddMode = "Add this location";
        string btnMain1EdditMode = "Cancel";

        string btnMain2AddMode = "Cancel";
        string btnMain2EditMode = "Edit this location";

        enum editMode { editing, adding };
        editMode editingMode = new editMode();
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
            btnMain1.Enabled = state;
            btnMain2.Enabled = state;
            btnUpdateDb.Enabled = state;
        }
        private void reInitializeForm()
        {
            activateAddMode();
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
                AddLocationsInCbLocation();
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
        private void activateEditMode()
        {
            editingMode = editMode.editing;
            btnMain1.Text = btnMain1EdditMode;
            btnMain2.Text = btnMain2EditMode;
            btnDelete.Enabled = true;
        }
        private void activateAddMode()
        {
            editingMode = editMode.adding;
            btnMain1.Text = btnMain1AddMode;
            btnMain2.Text = btnMain2AddMode;
            btnDelete.Enabled = false;
        }
        private void AddLocationsInCbLocation()
        {
            String[] locations = currentZone.GetLocationsTitles();
            if(locations != null)
            {
                cbLocation.Items.Clear();
                cbLocation.Items.AddRange(locations);
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
            
        }
        private void OnCbTitleSelectedChanged(object sender, EventArgs e)
        {
            
            activateEditMode();
        }
        private void OnCbZoneSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            currentZone = world.GetZoneFromString(cb.Text);
            reInitializeForm();
        }


        #endregion

        #region BTN
        
        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            foreach (Zone zone in world.zones.Values)
            {

                Console.WriteLine($"{ zone.Name}");
                Console.WriteLine("***********************");
                foreach (Location loc in zone.Locations)
                {
                    Console.WriteLine($"{loc.Title}");
                    Console.WriteLine($"{loc.Description}");
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
        private void btnMain1_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.adding)
            {
                if (isFormValid())
                {
                    createNewLocation();
                }
            }
            else
            {
                reInitializeForm();
            }    
        }



        #endregion

        private void btnMain2_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.editing)
            {
                if (isFormValid())
                {
                    //save changes to location
                }
            }
            else
            {
                reInitializeForm();
            }
        }
    }


}
