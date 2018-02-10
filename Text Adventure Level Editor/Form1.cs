using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TextAdventureGame
{ 
    public partial class Form1 : Form
    {
        World world = new World();
        Location locationToEdit;
        Location tempLocation;
        List<AccessPoint> tempAccessPoints = new List<AccessPoint>();
        Zone currentZone;

        string btnMain1AddMode = "Add this location";
        string btnMain1EdditMode = "Cancel";

        string btnMain2AddMode = "Cancel";
        string btnMain2EditMode = "Edit this location";

        string lbAccessPointsEditAccessPoints ="Edit Access Points";

        enum editMode { editing, adding };
        editMode editingMode = new editMode();



        public Form1()
        {
            
            
            InitializeComponent();
            
            world.Create();
            SimulateXML();
            
            reInitializeForm();
            refreshCbZone();
            btnNewZone.Select();
        }

        private void SimulateXML()
        {
            currentZone = world.Populate();
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
            btnMain1.Enabled = state;
            btnMain2.Enabled = state;
            btnUpdateDb.Enabled = state;
        }
        private void reInitializeForm()
        {
            activateAddMode();
            tempLocation = new Location("", "");
            locationToEdit = null;
            tempAccessPoints = null;
            clearAllFields();
            addEditAccessPointToLbAccessPoints();
            
            if (world.zones.Count < 1)
            {
                lbAccessPoints.ClearSelected();
                cbZone.Select();
            }
            else
            {
                //if(currentZone == null)
                //{
                //    currentZone = world.GetZoneFromString("Maison de Fred");//will soon throw an error.....
                //}
                lbAccessPoints.SelectedItem = lbAccessPointsEditAccessPoints;
                cbLocation.Select();
                AddLocationsInCbLocation();
            }
            
        }
        private void addEditAccessPointToLbAccessPoints()
        {
            lbAccessPoints.Items.Clear();
            lbAccessPoints.Items.Add(lbAccessPointsEditAccessPoints);
        }
        private void clearAllFields()
        {
            cbZone.Text = "";
            cbLocation.Text = "";
            tbLocDesc.Text = "";
        }
        private void createNewLocation()
        {
            tempLocation = new Location(cbLocation.Text, tbLocDesc.Text);
            if(tempAccessPoints != null)
            {
                tempLocation.AccessPoints = tempAccessPoints;
            }
            currentZone.AddLocation(tempLocation);
            
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
            cbZone.Enabled = false;
        }
        private void activateAddMode()
        {
            editingMode = editMode.adding;
            cbZone.Enabled = true;
            btnMain1.Text = btnMain1AddMode;
            btnMain2.Text = btnMain2AddMode;
            btnDelete.Enabled = false;
        }
        private void AddLocationsInCbLocation()
        {
            world.GetZoneFromString(cbZone.Text);
            String[] locations = currentZone.GetLocationsTitles();
            if(locations != null)
            {
                cbLocation.Items.Clear();
                cbLocation.Items.AddRange(locations);
            }
        }
        private void updateFormFromSelectedLocation(Location locationToEdit)//TO DO : REFRESH ACCESS POINTS WHEN LOCATION IS SELECTED
        {
            tbLocDesc.Text = locationToEdit.Description;
        }
        #endregion

        #region LISTENERS
        private void editForm_Closed(object sender, FormClosedEventArgs e)
        {
            EditZonesForm editZonesForm = (EditZonesForm)sender;
            clearAllFields();
            lbAccessPoints.ClearSelected();
            string lastZoneEdited = editZonesForm.lastZoneEdited;
            setLastZoneEditedAsActiveZone(lastZoneEdited);
        }
        private void OnCbTitleSelectedChanged(object sender, EventArgs e)
        {
            activateEditMode();
            locationToEdit = currentZone.GetLocationByName(cbLocation.Text);
            updateFormFromSelectedLocation(locationToEdit);
        }
        private void OnCbZoneSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            currentZone = world.GetZoneFromString(cb.Text);
            reInitializeForm();
        }
        private void OnLbAccessPointDoubleClicked(object sender, EventArgs e)
        {
            if(lbAccessPoints.SelectedItem.ToString() == lbAccessPointsEditAccessPoints)
            {
                if(tempAccessPoints == null)
                {

                }
                else
                {

                }
                Location currentRoom;
                if(editingMode == editMode.editing)
                {
                    currentRoom = locationToEdit;
                }
                else
                {
                    currentRoom = tempLocation;
                }
                AccessPointForm apForm = new AccessPointForm( currentRoom,currentZone,world,tempAccessPoints);
                apForm.Show();
            }
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
                    reInitializeForm();
                }
            }
            else
            {
                
                reInitializeForm();
            }    
        }
        private void btnMain2_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.editing)
            {
                if (isFormValid())
                {
                    createNewLocation();
                    currentZone.DeleteLocation(locationToEdit);
                    reInitializeForm();
                }
            }
            else
            {
                reInitializeForm();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.editing)
            {
                currentZone.DeleteLocation(locationToEdit);
                reInitializeForm();
            }
        }

        #endregion

        
    }


}
