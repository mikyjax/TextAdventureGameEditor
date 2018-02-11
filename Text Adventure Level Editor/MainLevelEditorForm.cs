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

    public partial class MainLevelEditorForm : Form
    {
        World world = new World();
        string worldName = "";
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

        public MainLevelEditorForm(string worldName)
        {
            InitializeComponent();
            world.Create();
            SimulateXML();
            ReInitializeForm();
            RefreshCbZone();
        }

        #region HELPERS FUNCTIONS
        private void ReInitializeForm()
        {
            ActivateAddMode();
            tempLocation = new Location("", "");
            locationToEdit = null;
            tempAccessPoints = new List<AccessPoint>();
            tempLocsToCreate = new List<zoneLocationPair>();
            ClearAllFields();
            AddEditAccessPointToLbAccessPoints();
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

        private void RefreshCbZone()
        {
            string[] zoneName = world.GetAllZonesNames();
            Array.Sort(zoneName);
            cbZone.Items.Clear();
            cbZone.Items.AddRange(zoneName);

            if (cbZone.Items.Count > 0)
            {
                cbZone.SelectedIndex = 0;
                SetAllControlsToEnable(true);
                currentZone = world.GetZoneFromString(cbZone.SelectedItem.ToString()) ;
            }
            else
            {
                SetAllControlsToEnable(false);
                btnNewZone.Enabled = true;
            }

        }
        private void RefreshCbZoneAndSelectDefinedZone(string zoneToSelect)
        {
            RefreshCbZone();
            if (cbZone.Items.Count > 0)
            {
                cbZone.SelectedItem = zoneToSelect;
            }
        }
        private void SetLastZoneEditedAsActiveZone(string lastZoneEdited)
        {
            if (world.zones.Count > 0)
            {

                if (lastZoneEdited != null)
                {
                    RefreshCbZoneAndSelectDefinedZone(lastZoneEdited);
                }
                else
                {
                    RefreshCbZone();
                }
                cbLocation.Select();
            }
            else
            {
                RefreshCbZone();
                btnNewZone.Select();
            }
        }

        private void AddLocationsInCbLocation()
        {
            world.GetZoneFromString(cbZone.Text);
            String[] locations = currentZone.GetLocationsTitles();
            if (locations != null)
            {
                cbLocation.Items.Clear();
                Array.Sort(locations);
                cbLocation.Items.AddRange(locations);
            }
        }

        private void AddEditAccessPointToLbAccessPoints()
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
        private void CreateNewLocationsFromAccessPointsForm(List<zoneLocationPair> tempLocsToCreate)
        {
            foreach (var item in tempLocsToCreate)
            {
                CreateEmptyButNamedLocationInAZone(world.GetZoneFromString(item.ZoneName), item.LocationName);
            }
        }

        private bool IsFormValid()
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
        private void SetAllControlsToEnable(bool state)
        {
            cbZone.Enabled = state;
            cbLocation.Enabled = state;
            tbLocDesc.Enabled = state;
            lbAccessPoints.Enabled = state;
            btnMain1.Enabled = state;
            btnMain2.Enabled = state;
            btnUpdateDb.Enabled = state;
        }
        private void ActivateEditMode(string zoneName)
        {
            cbZone.SelectedItem = zoneName;
            editingMode = editMode.editing;
            btnMain1.Text = btnMain1EdditMode;
            btnMain2.Text = btnMain2EditMode;
            btnDelete.Enabled = true;
            cbZone.Enabled = false;
            btnNewZone.Enabled = false;
        }
        private void ActivateAddMode()
        {
            editingMode = editMode.adding;
            cbZone.Enabled = true;
            btnNewZone.Enabled = true;
            btnMain1.Text = btnMain1AddMode;
            btnMain2.Text = btnMain2AddMode;
            btnDelete.Enabled = false;
        }

        private void ClearAllFields()
        {
            cbZone.Text = "";
            cbLocation.Text = "";
            tbLocDesc.Text = "";
            AddEditAccessPointToLbAccessPoints();
        }
        
        private void CreateEmptyButNamedLocationInAZone(Zone targetZone, string locName)
        {
            Location locToAdd = new Location(locName,"");
            targetZone.AddLocation(locToAdd);
        }
        private void CreateNewLocation()
        {
            tempLocation = new Location(cbLocation.Text, tbLocDesc.Text);
            AddAccessPointsToLocation(tempLocation);
            currentZone.AddLocation(tempLocation);

        }
        private void AddAccessPointsToLocation(Location loc)
        {
            if (tempAccessPoints != null)
            {
                loc.AccessPoints = tempAccessPoints;
            }
            else
            {
                tempAccessPoints = new List<AccessPoint>();
            }
        }
        private void SaveModificationToLocation()
        {
            AddAccessPointsToLocation(locationToEdit);
            locationToEdit.Title = cbLocation.Text;
            locationToEdit.Description = tbLocDesc.Text;
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
                if (targetLocation.AccessPoints == null)
                {
                    targetLocation.AccessPoints = new List<AccessPoint>();
                }
                if (targetLocation.AccessPoints.Count > 0)
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
        private void EditThisLocation(string zoneName, string locName)
        {
            ActivateEditMode(zoneName);
            Zone zoneToLookIn = world.GetZoneFromString(zoneName);
            locationToEdit = zoneToLookIn.GetLocationByName(locName);
            UpdateFormFromSelectedLocation(locationToEdit);
        }

        private void UpdateFormFromSelectedLocation(Location locationToEdit)
        {
            cbLocation.SelectedItem = locationToEdit.Title;
            tbLocDesc.Text = locationToEdit.Description;
            if(locationToEdit.AccessPoints == null)
            {
                locationToEdit.AccessPoints = new List<AccessPoint>();
            }
            tempAccessPoints = locationToEdit.AccessPoints;
            AddEditAccessPointToLbAccessPoints();
        }
        private void AddNewLocationFromForm()
        {
            CreateNewLocationsFromAccessPointsForm(tempLocsToCreate);
            CreateNewLocation();
            UpdateOppositeAccessPoints();
            ReInitializeForm();
        }
        
        private void SaveChangesFromForm()
        {
            CreateNewLocationsFromAccessPointsForm(tempLocsToCreate);
            CreateNewLocation();
            UpdateOppositeAccessPoints();
            currentZone.DeleteLocation(locationToEdit);
            ReInitializeForm();
        }
        
        #endregion

        #region LISTENERS
        private void editForm_Closed(object sender, FormClosedEventArgs e)
        {
            EditZonesForm editZonesForm = (EditZonesForm)sender;
            ClearAllFields();
            lbAccessPoints.ClearSelected();
            string lastZoneEdited = editZonesForm.lastZoneEdited;
            SetLastZoneEditedAsActiveZone(lastZoneEdited);
            this.Enabled = true;
        }
        private void accessPointForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            AddEditAccessPointToLbAccessPoints();

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
            AddLocationsInCbLocation();
            
        }
        private void OnLbAccessPointDoubleClicked(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                string selectedItemName = lbAccessPoints.SelectedItem.ToString();
                if (selectedItemName == lbAccessPointsEditAccessPoints)
                {
                    Location currentRoom;
                    if (editingMode == editMode.editing)
                    {
                        currentRoom = locationToEdit;
                    }
                    else
                    {
                        currentRoom = tempLocation;
                    }
                    AccessPointForm apForm = new AccessPointForm(currentRoom, currentZone, world, tempAccessPoints, tempLocsToCreate);
                    this.Enabled = false;
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
            this.Enabled = false;
            editZoneForm.Show();
            editZoneForm.FormClosed += new FormClosedEventHandler(editForm_Closed);


        }
        private void btnMain1_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.adding)
            {
                if (IsFormValid())
                {
                    AddNewLocationFromForm();
                }
            }
            else
            {
                ReInitializeForm();
            }    
        }
        private void btnMain2_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.editing)
            {
                if (IsFormValid())
                {
                    SaveChangesFromForm();
                }
            }
            else
            {
                ReInitializeForm();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.editing)
            {
                currentZone.DeleteLocationAccessPoints(locationToEdit,world);
                currentZone.DeleteLocation(locationToEdit);
                ReInitializeForm();
            }
        }
        #endregion

        
    }


}
