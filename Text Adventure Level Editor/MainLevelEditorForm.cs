using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using TextAdventureCommon;

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
        string sayObjectMustHaveName = "Any object must have a name";
        string sayIsAReservedName = "is a reserved name";
        string newObjectName = "New Object";


        World world = new World();
        GameFileAndTitle gameToEdit = new GameFileAndTitle("","");
        string worldName = "";
        Location locationToEdit;
        Location tempLocation;
        List<zoneLocationPair> tempLocsToCreate;
        List<AccessPoint> tempAccessPoints;
        List<AccessPoint> tempAccessPointsToDelete;

        ObjectEditor objectEditor;
        Oobject tempObject;

        Zone currentZone;
        DataManager dataManager = new DataManager();
        string btnMain1AddMode = "Add this location";
        string btnMain1EdditMode = "Cancel";

        string btnMain2AddMode = "Cancel";
        string btnMain2EditMode = "Save Changes to Location";

        string lbAccessPointsEditAccessPoints ="Edit Access Points";
        enum editMode { editing, adding };
        editMode editingMode = new editMode();
        System.Drawing.Color unselectedLbColor;

        public MainLevelEditorForm()
        {
            InitializeComponent();
            world.Create();
            this.Enabled = false;
            
            ReInitializeForm();
            unselectedLbColor = lbAccessPoints.BackColor;
            RefreshCbZone();

            

            WorldSelectionForm worldSelectionForm = new WorldSelectionForm(gameToEdit);
            worldSelectionForm.FormClosed += new FormClosedEventHandler(WorldSelectionForm_FormClosed);
           
            worldSelectionForm.ShowDialog();
        }

        

        #region HELPERS FUNCTIONS
        private void ReInitializeForm()
        {
            ActivateAddMode();
            tempLocation = new Location("", "");
            locationToEdit = null;
            tempAccessPoints = new List<AccessPoint>();
            tempLocsToCreate = new List<zoneLocationPair>();
            tempAccessPointsToDelete = new List<AccessPoint>();
            tempObject = null;
            objectEditor = new ObjectEditor(world, tempLocation, currentZone, tVObjects);
            


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
                world.GetZoneFromString(item.ZoneName).CreateEmptyButNamedLocationInAZone(item.LocationName);
            }
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(cbLocation.Text))
            {
                if (string.IsNullOrWhiteSpace(cbZone.Text))
                {
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

        private bool IsStartingLocationExisting()
        {
            List<Location> allLocs = world.GetAllLocations();
            foreach (Location loc in allLocs)
            {
                if (loc.StartingLocation)
                {
                    return true;
                }
            }
            return false;
        }

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
            ChBxTransitionLocation.Checked = false;
            rBstartingLocation.Checked = false;
            
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
            ChBxTransitionLocation.Checked = locationToEdit.TransitionLocation;
            rBstartingLocation.Checked = locationToEdit.StartingLocation;


            UpdateTvObjects();

        }

        private void UpdateTvObjects()
        {
            objectEditor = new ObjectEditor(world, locationToEdit, currentZone, tVObjects);
            
        }

        private void AddNewLocationToWorldFromForm()
        {
            CreateNewLocationsFromAccessPointsForm(tempLocsToCreate);
            CreateNewLocationFromForm();
            UpdateOppositeAccessPoints();
            ReInitializeForm();
        }
        private void CreateNewLocationFromForm()
        {
            tempLocation = new Location(cbLocation.Text, tbLocDesc.Text);
            tempLocation.TransitionLocation = ChBxTransitionLocation.Checked;
            tempLocation.StartingLocation = rBstartingLocation.Checked;
            Zone zone = world.GetZoneFromString(cbZone.Text);
            tempLocation.AddAccessPointsToLocation(tempAccessPoints);
            zone.AddLocation(tempLocation);
            if (rBstartingLocation.Checked == true)
            {
                SetLocationAsGameEntryPoint(tempLocation, world);
            }

            foreach (AccessPoint ap in tempLocation.AccessPoints)
            {
                if (!ap.IsOppositeAccessPointExisting(tempLocation, currentZone, world))
                {
                    Zone oppositeZone = world.GetZoneFromString(ap.DestZone);

                    Location locReceivingNewAccessPoint = oppositeZone.GetLocationByName(ap.DestLoc);
                    ap.CreateOppositeAccessPoint(tempLocation, currentZone,locReceivingNewAccessPoint);//TO DO Get the receiving Location
                    
                }
            }
            

        }

        private void SetLocationAsGameEntryPoint(Location startingLocation, World world)
        {
            foreach (Zone zone in world.GetAllZones())
            {
                foreach (Location loc in zone.Locations)
                {
                    loc.StartingLocation = false;
                }
            }
            startingLocation.StartingLocation = true;
        }

        private void EditThisLocation(string zoneName, string locName)
        {
            ActivateEditMode(zoneName);
            Zone zoneToLookIn = world.GetZoneFromString(zoneName);
            locationToEdit = zoneToLookIn.GetLocationByName(locName);
            UpdateFormFromSelectedLocation(locationToEdit);
        }

        private void SaveChangesFromForm()
        {
            CreateNewLocationsFromAccessPointsForm(tempLocsToCreate);
            CreateNewLocationFromForm();
            UpdateOppositeAccessPoints();
            currentZone.DeleteLocation(locationToEdit);
            ReInitializeForm();
        }
        private void SaveModificationToLocation()
        {
            locationToEdit.AddAccessPointsToLocation(tempAccessPoints);
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
        

        #endregion

        #region LISTENERS
        private void WorldSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            world.GameTitle = gameToEdit.Title;
            if (!File.Exists(@"Games\" + gameToEdit.FileName))
            {
                if(string.IsNullOrWhiteSpace(  gameToEdit.FileName))
                {
                    Application.Exit();
                    return;
                }
                dataManager.SaveFile(world, @"Games\",gameToEdit.FileName);
                Console.WriteLine("game saved");
            }
            else
            {
                Console.WriteLine("Game Loaded");
                world = dataManager.LoadFile(@"Games\"+gameToEdit.FileName);
                if (world.zones.Count > 0)
                {
                    currentZone = world.zones.Values.FirstOrDefault();
                    cbZone.SelectedItem = currentZone.Name;
                    cbZone.Text = currentZone.Name;
                    RefreshCbZone();
                }
                ReInitializeForm();
            }
            world.GameTitle = gameToEdit.Title;
            //Console.WriteLine(gameToEdit.FileName);
        }
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
            lbAccessPoints.Select();

        }

        private void OnCbTitleSelectedChanged(object sender, EventArgs e)
        {
            string zoneName = currentZone.Name;
            string locName = cbLocation.Text;
            EditThisLocation(zoneName,locName);
        }
        private void OnCbTitleLeave(object sender, EventArgs e)
        {
            
        }
        private void OnCbZoneSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            currentZone = world.GetZoneFromString(cb.Text);
            AddLocationsInCbLocation();
            
        }

        private void InteractWhithAccessPointPanel()
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
                        AddNewLocationToWorldFromForm();
                    }
                    EditThisLocation(zoneToGo, locToGo);
                }
            }
        }        
        private void OnEnterLbApChangColor(object sender, EventArgs e)
        {
            lbAccessPoints.BackColor = System.Drawing.Color.LightGray;
            lbAccessPoints.SelectedIndex = 0;
        }
        private void OnLeaveLbChangeColor(object sender, EventArgs e)
        {
            lbAccessPoints.BackColor = unselectedLbColor;
        }
        #endregion

        #region BTN       
        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.adding)
            {
                SaveAddedLocation();
            }else if(editingMode == editMode.editing)
            {
                SaveEditionChangesToLocation();
            }

            if (IsStartingLocationExisting())
            {
                DataManager dataManager = new DataManager();
                dataManager.SaveFile(world, @"Games\", gameToEdit.FileName);
            }
            else
            {
                MessageBox.Show("You must tick one location as the starting location of the game");
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
                SaveAddedLocation();
            }
            else
            {
                ReInitializeForm();
            }    
        }

        private void SaveAddedLocation()
        {
            if (IsFormValid())
            {
                AddNewLocationToWorldFromForm();
            }
        }

        private void btnMain2_Click(object sender, EventArgs e)
        {
            if (editingMode == editMode.editing)
            {
                SaveEditionChangesToLocation();
            }
            else
            {
                ReInitializeForm();
            }
        }

        private void SaveEditionChangesToLocation()
        {
            if (IsFormValid())
            {
                SaveChangesFromForm();
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

        private void OnLbAccessPointDoubleClicked(object sender, EventArgs e)
        {
            InteractWhithAccessPointPanel();

        }
        private void OnlbAccessPointEnterDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InteractWhithAccessPointPanel();
            }

        }



        #endregion

        private void btnSaveObject_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tVObjects.SelectedNode;
            string error = GetCreationObjectError(tempObject);
            if (error == null)
            {
                tempObject.Name = tbObjectName.Text;
                selectedNode.Text = tempObject.Name;

                //objectEditor.AddObject(selectedNode, tempObject); TO DO

                //objectEditor.AddObject(tVObjects.SelectedNode, tempObject);

            }
            else
            {
                MessageBox.Show(error);
            }
            
        }

        private string GetCreationObjectError(Oobject tempObject)
        {
            if (string.IsNullOrWhiteSpace(tbObjectName.Text))
            {
                return sayObjectMustHaveName;
            }
            if(tbObjectName.Text.ToLower() == tVObjects.Nodes[0].Text.ToLower() && tVObjects.SelectedNode != tVObjects.Nodes[0] )
            {
                return tVObjects.Nodes[0].Text + " "+sayIsAReservedName;
            }
            if (tbObjectName.Text.ToLower()== newObjectName.ToLower())
            {
                return newObjectName + " " + sayIsAReservedName;
            }
            return null;
        }

        private void OnAfterSelectTvObjects(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = tVObjects.SelectedNode;
            pnlContainer.Visible = false;
            pnlObj.Visible = false;
            if (objectEditor.IsNodeObject(selectedNode))
            {
                pnlObj.Visible = true;
                Oobject currentObject = objectEditor.TreeNodeDict.GetObject(selectedNode);
                UpdatePnlObj(currentObject);
            }
            else
            {
                pnlContainer.Visible = true;
            }
        }

        private void UpdatePnlObj(Oobject currentObject)
        {
            tbObjectName.Text = currentObject.Name;
            chBxAboveContainer.Checked = currentObject.HasAboveContainer;
            chBxInsideContainer.Checked = currentObject.HasInsideContainer;
            chBxUnderContainer.Checked = currentObject.HasUnderContainer;
            if (currentObject == tempLocation.Void)
            {
                tbObjectName.Enabled = false;
                chBxAboveContainer.Enabled = false;
                chBxInsideContainer.Enabled = false;
                chBxUnderContainer.Enabled = false;
                btnDeleteObject.Enabled = false;
            }
            else
            {
                tbObjectName.Enabled = true;
                chBxAboveContainer.Enabled = true;
                chBxInsideContainer.Enabled = true;
                chBxUnderContainer.Enabled = true;
                btnDeleteObject.Enabled = true;
            }
            
            
        }

        private void btnAddObject_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tVObjects.SelectedNode;
            tempObject = objectEditor.CreateNewObject(selectedNode);
            TreeNode newObjectNode = objectEditor.TreeNodeDict.KeyByValue( tempObject);
            tVObjects.SelectedNode = newObjectNode;

        }
    }
    

}
