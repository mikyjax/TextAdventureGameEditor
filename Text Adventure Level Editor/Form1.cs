using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TextAdventureGame
{ 
    public struct zoneLocationPair
    {
        public string ZoneName;
        public string LocationName;
        public zoneLocationPair(string _zoneName, string _locationName)
        {
            ZoneName = _zoneName;
            LocationName = _locationName;
        }
    }

    public partial class Form1 : Form
    {
        World world = new World();
        Location locationToEdit;
        Location tempLocation;
        List<zoneLocationPair> tempLocsToCreate;
        List<AccessPoint> tempAccessPoints;
        Zone currentZone;

        string btnMain1AddMode = "Add this location";
        string btnMain1EdditMode = "Cancel";

        string btnMain2AddMode = "Cancel";
        string btnMain2EditMode = "Save Changes to Location";

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
        }

        #region HELPERS FUNCTIONS
        private void reInitializeForm()
        {
            activateAddMode();
            tempLocation = new Location("", "");
            locationToEdit = null;
            tempAccessPoints = new List<AccessPoint>();
            tempLocsToCreate = new List<zoneLocationPair>();
            clearAllFields();
            addEditAccessPointToLbAccessPoints();
            if (world.zones.Count < 1)
            {
                btnNewZone.Select();
            }
            else
            {
                cbLocation.Select();
                AddLocationsInCbLocation();
            }

        }
        private void SimulateXML()
        {
            currentZone = world.Populate();
        }
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
        private void addEditAccessPointToLbAccessPoints()
        {
            lbAccessPoints.Items.Clear();
            lbAccessPoints.Items.Add(lbAccessPointsEditAccessPoints);
            if (tempAccessPoints != null)
            {
                foreach (AccessPoint ap in tempAccessPoints)
                {
                    lbAccessPoints.Items.Add(ap.Direction + "\t" + ap.DestLoc);
                }
            }
            lbAccessPoints.Select();
            lbAccessPoints.SelectedIndex = 0;
            cbLocation.Select();

        }
        private void clearAllFields()
        {
            cbZone.Text = "";
            cbLocation.Text = "";
            tbLocDesc.Text = "";
            addEditAccessPointToLbAccessPoints();
        }
        private void createNewLocationsFromAccessPointsForm(List<zoneLocationPair> tempLocsToCreate)
        {
            foreach (var item in tempLocsToCreate)
            {
                CreateEmptyButNamedLocationInAZone(world.GetZoneFromString(item.ZoneName), item.LocationName);
            }
        }
        private void CreateEmptyButNamedLocationInAZone(Zone targetZone, string locName)
        {
            Location locToAdd = new Location(locName,"");
            targetZone.AddLocation(locToAdd);
        }
        private void createNewLocation()
        {
            tempLocation = new Location(cbLocation.Text, tbLocDesc.Text);
            if(tempAccessPoints != null)
            {
                tempLocation.AccessPoints = tempAccessPoints;
            }
            else
            {
                tempAccessPoints = new List<AccessPoint>();
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

        private void activateEditMode(string zoneName)
        {
            cbZone.SelectedItem = zoneName;
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
        private void updateFormFromSelectedLocation(Location locationToEdit)
        {
            cbLocation.SelectedItem = locationToEdit.Title;
            tbLocDesc.Text = locationToEdit.Description;
            if(locationToEdit.AccessPoints == null)
            {
                locationToEdit.AccessPoints = new List<AccessPoint>();
            }
            tempAccessPoints = locationToEdit.AccessPoints;
            addEditAccessPointToLbAccessPoints();
        }
        private void AddNewLocationFromForm()
        {
            createNewLocationsFromAccessPointsForm(tempLocsToCreate);
            createNewLocation();
            UpdateOppositeAccessPoints();
            reInitializeForm();
        }

        private void UpdateOppositeAccessPoints()
        {
            foreach (AccessPoint ap in tempLocation.AccessPoints)
            {
                string dir = ap.Direction;
                string oppositeDir = AccessPoint.ReturnOppositeDirection(dir);
                string locToChange = ap.DestLoc;
                string zoneToChange = ap.DestZone;

                Zone targetZone = world.GetZoneFromString(zoneToChange);
                Location targetLocation = targetZone.GetLocationByName(locToChange);
                if(targetLocation.AccessPoints == null)
                {
                    targetLocation.AccessPoints = new List<AccessPoint>();
                }
                if(targetLocation.AccessPoints.Count > 0)
                {
                    foreach (AccessPoint apTarget in targetLocation.AccessPoints)
                    {
                        if (apTarget.Direction == oppositeDir)
                        {
                            apTarget.DestZone = currentZone.Name;
                            apTarget.DestLoc = tempLocation.Title;
                            return;
                        }
                    }
                }
                else
                {
                    AccessPoint tempAp = new AccessPoint(oppositeDir, currentZone.Name, tempLocation.Title);
                    targetLocation.AccessPoints.Add(tempAp);
                }
                
                

            }
        }

        private void SaveChangesFromForm()
        {
            createNewLocationsFromAccessPointsForm(tempLocsToCreate);
            createNewLocation();
            UpdateOppositeAccessPoints();
            currentZone.DeleteLocation(locationToEdit);
            reInitializeForm();
        }
        private void EditThisLocation(string zoneName, string locName)
        {
            activateEditMode(zoneName);
            Zone zoneToLookIn = world.GetZoneFromString(zoneName);
            locationToEdit = zoneToLookIn.GetLocationByName(locName);
            updateFormFromSelectedLocation(locationToEdit);
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
        private void accessPointForm_Closed(object sender, FormClosedEventArgs e)
        {
            addEditAccessPointToLbAccessPoints();
        }
        private void OnCbTitleSelectedChanged(object sender, EventArgs e)
        {
            string zoneName = currentZone.Name;
            string locName = cbLocation.Text;
            EditThisLocation(zoneName,locName);
        }
        private void OnCbZoneSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            currentZone = world.GetZoneFromString(cb.Text);
            reInitializeForm();
        }
        private void OnLbAccessPointDoubleClicked(object sender, EventArgs e)
        {
            string selectedItemName = lbAccessPoints.SelectedItem.ToString();
            if(selectedItemName == lbAccessPointsEditAccessPoints)
            {
                Location currentRoom;
                if(editingMode == editMode.editing)
                {
                    currentRoom = locationToEdit;
                }
                else
                {
                    currentRoom = tempLocation;
                }
                AccessPointForm apForm = new AccessPointForm( currentRoom,currentZone,world,tempAccessPoints,tempLocsToCreate);
                apForm.Show();
                apForm.FormClosed += new FormClosedEventHandler(accessPointForm_Closed);
            }//Edit Access Points
            else
            {
                string[] zoneAndLocationSplited = selectedItemName.Split('\t');
                string directionToGo = zoneAndLocationSplited[0];
                string locToGo = zoneAndLocationSplited[1];
                string zoneToGo = "";
                foreach (AccessPoint ap in tempAccessPoints)
                {
                    if (directionToGo == ap.Direction)
                    {
                        zoneToGo = ap.DestZone;
                    }
                }
                if (editingMode == editMode.editing)
                {
                    SaveChangesFromForm();
                }
                else
                {
                    AddNewLocationFromForm();
                }
                EditThisLocation(zoneToGo, locToGo);
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
                    AddNewLocationFromForm();
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
                    SaveChangesFromForm();
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
