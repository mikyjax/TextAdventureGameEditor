using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAdventureGame
{
    public partial class AccessPointForm : Form
    {
        public List<Zone> Zones { get; set; }
        private Zone currentZone;
        List<AccessPointPnl> accessPointsPnls = new List<AccessPointPnl>();
        List<AccessPoint> accessPoints = new List<AccessPoint>();
        List<AccessPoint> accessPointsOnFormLoad = new List<AccessPoint>();
        Location currentLocation;
        World world = null;
        private List<zoneLocationPair> locationsToCreate = new List<zoneLocationPair>();

        public AccessPointForm( Location _currentLocation,
                                Zone _currentZone, 
                                World _world, 
                                List<AccessPoint> tempAccessPoints, 
                                List<zoneLocationPair> _locationsToCreate)
        {
            currentLocation = _currentLocation;
            currentZone = _currentZone;
            world = _world;
            accessPoints = tempAccessPoints;
            currentZone = _currentZone;
            locationsToCreate = _locationsToCreate;
            InitializeComponent();
            CreateAccessPointsPnls();
            ReInitializeAccessPointsPnls();
            FillAccessPointsOnFormLoad();
        }

        #region BTN
        private void btnMore_Click(object sender, EventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            ComboBox cbDestError;
            if (IsFormValid(out cbDestError))
            {
                bool conflictInAccessPoints = ClearConflictIfExistingInAllAccessPointPnls();
                if (!conflictInAccessPoints)
                {
                    ApplyAccessPointsChanges();
                }
            }
            else
            {
                MessageBox.Show("A location cannot access to itself!");
                cbDestError.Select();
            }
            
            
        }

        
        #endregion

        #region HELPERS
        private void FillAccessPointsOnFormLoad()
        {
            accessPointsOnFormLoad.Clear();
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (!String.IsNullOrWhiteSpace(apPnl.cbDest.Text))
                {
                    AccessPoint apToAdd = new AccessPoint(apPnl.direction, apPnl.cbZone.Text, apPnl.cbDest.Text.Trim());
                    accessPointsOnFormLoad.Add(apToAdd);
                }
            }
        }
        private bool IsFormValid(out ComboBox cbDest)
        {
            cbDest = null;
            foreach (var apPnls in accessPointsPnls)
            {
                if (currentZone.Name == apPnls.cbZone.Text && currentLocation.Title == apPnls.cbDest.Text)
                {
                    cbDest = apPnls.cbDest;
                    return false;
                }
            }
            return true;
        }
        private void CreateAccessPointsPnls()
        {
            AccessPointPnl apPnlN = new AccessPointPnl("N",lblDirN, cbZoneN, cbLocN, btnMoreN);
            AccessPointPnl apPnlNE = new AccessPointPnl("NE",lblDirNE, cbZoneNE, cbLocNE, btnMoreNE);
            AccessPointPnl apPnlE = new AccessPointPnl("E",lblDirE, cbZoneE, cbLocE, btnMoreE);
            AccessPointPnl apPnlSE = new AccessPointPnl("SE",lblDirSE, cbZoneSE, cbLocSE, btnMoreSE);
            AccessPointPnl apPnlS = new AccessPointPnl("S",lblDirS, cbZoneS, cbLocS, btnMoreS);
            AccessPointPnl apPnlSW = new AccessPointPnl("SW",lblDirSW, cbZoneSW, cbLocSW, btnMoreSW);
            AccessPointPnl apPnlW = new AccessPointPnl("W",lblDirW, cbZoneW, cbLocW, btnMoreW);
            AccessPointPnl apPnlNW = new AccessPointPnl("NW",lblDirNW, cbZoneNW, cbLocNW, btnMoreNW);


            accessPointsPnls.Add(apPnlN);
            accessPointsPnls.Add(apPnlNE);
            accessPointsPnls.Add(apPnlE);
            accessPointsPnls.Add(apPnlSE);
            accessPointsPnls.Add(apPnlS);
            accessPointsPnls.Add(apPnlSW);
            accessPointsPnls.Add(apPnlW);
            accessPointsPnls.Add(apPnlNW);

            FillCbZones();
            SubscribeZonesToSelectedIndexChanged();
            SubscribeDestinationToOnLeave();

        }
        private void SubscribeZonesToSelectedIndexChanged()
        {
            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {
                apPanel.cbZone.SelectedIndexChanged += EventCbZone_SelectedIndexChanged;
            }
        }
        private void SubscribeDestinationToOnLeave()
        {
            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {
                apPanel.cbDest.Leave += EventCbDest_OnLeave;
            }
        }
        private void ReInitializeAccessPointsPnls()
        {
            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {
                ResetAllFieldsInThisAccessPointPnl(apPanel);
            }
            accessPointsPnls[0].cbZone.Select();
            PopulateAccessPoinsPnls();

        }
        private void PopulateAccessPoinsPnls()
        {
            List<AccessPoint> allAccessPointsFromWorld = AccessPoint.GetAllAccessPointFromWorldExceptFromOneLocation(world, currentLocation);
            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {
                foreach (AccessPoint ap in accessPoints)
                {
                    if(ap.Direction == apPanel.direction)
                    {
                        apPanel.cbZone.SelectedItem = ap.DestZone.ToString();
                        apPanel.cbDest.SelectedItem = ap.DestLoc.ToString();
                    }
                }
                //foreach (AccessPoint ap in allAccessPointsFromWorld)
                //{
                //    if (AccessPoint.ReturnOppositeDirection(apPanel.lblDir.Text) == ap.Direction && 
                //                    ap.DestZone == currentZone.Name &&
                //                    ap.DestLoc ==currentLocation.Title)
                //    {
                //        apPanel.cbZone.SelectedItem = ap.DestZone.ToString();
                //        apPanel.cbDest.SelectedItem = ap.DestLoc.ToString();
                //    }
                //}
            }

        }
        private void ReinitializeAllFieldRelativeToThisZoneComboBox(ComboBox cb)
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (apPnl.cbZone == cb)
                {
                    ResetAllFieldsInThisAccessPointPnl(apPnl);

                }
            }
        }
        private void ReinitializeAllFieldRelativeToThisDestinationComboBox(ComboBox cb)
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (apPnl.cbDest == cb && string.IsNullOrWhiteSpace(apPnl.cbDest.Text))
                {
                    apPnl.cbZone.Text = "NONE";
                    ResetAllFieldsInThisAccessPointPnl(apPnl);

                }
            }

        }
        private void ResetAllFieldsInThisAccessPointPnl(AccessPointPnl apPnl)
        {
            apPnl.cbDest.Text = "";
            apPnl.cbDest.Enabled = false;
            apPnl.btnMore.Enabled = false;
            

            if (apPnl.cbZone.Text != "NONE")
            {
                apPnl.cbDest.Enabled = true;
                apPnl.btnMore.Enabled = true;
                FillCbDest(apPnl.cbZone.Text, apPnl.cbDest);
            }
        }
        private void FillCbDest(String zoneSelectedName,ComboBox cbDest)
        {
            cbDest.Items.Clear();

            List<string> locationNames = new List<string>();
            Zone zoneSelected = world.GetZoneFromString(zoneSelectedName);
            
            locationNames.AddRange(zoneSelected.GetLocationsTitles());
            locationNames.Remove(currentLocation.Title);
            cbDest.Items.AddRange(locationNames.ToArray());
            FormHelpersFuntions.addStringArrayToCbAutoComplete(locationNames.ToArray(), cbDest);
            
        }
        private void FillCbZones()
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                List<string> zoneNames = new List<string>();
                zoneNames.Add("NONE");
                zoneNames.AddRange(world.GetAllZonesNames());
                apPnl.cbZone.Items.AddRange(zoneNames.ToArray());
                apPnl.cbZone.SelectedIndex = 0;
            }
        }
        private void ApplyAccessPointsChanges()
        {
            accessPoints.Clear();
            locationsToCreate.Clear();
            

            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (!String.IsNullOrWhiteSpace(apPnl.cbDest.Text))
                {
                    AccessPoint apToAdd = new AccessPoint(apPnl.direction, apPnl.cbZone.Text, apPnl.cbDest.Text.Trim());
                    accessPoints.Add(apToAdd);

                    Zone zone = world.GetZoneFromString(apPnl.cbZone.Text);
                    zoneLocationPair locToCreate;
                    if (!zone.IsLocationExistingInZone(apPnl.cbDest.Text.Trim()))
                    {
                        locToCreate = new zoneLocationPair(zone.Name, apPnl.cbDest.Text.Trim());
                        locationsToCreate.Add(locToCreate);
                    }
                }
            }
            //if accessPointsOnFormLoad has an accessPoint not existing in accessPoints, It means it has been remove so we should remove the access point
            //from the opposite Location too.
            SyncOldAccessPointsAndNewOnes();
            this.Close();
            



        }

        private bool ClearAccessPointsConflicts()
        {
            bool noConflict = true;
            AccessPoint conflictingAccessPoint;
            Location conflictingLocation = null;
            ComboBox cbToSelect;
            List<Location> allLocs = Zone.GetLocationsFromAllZones(world.GetAllZones());

            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (IsConflictExistingWithAnotherAccessPoint(apPnl.cbDest))
                {

                    conflictingAccessPoint = GetConflictingAccessPoint(apPnl.cbDest);

                    foreach (Location loc in allLocs)
                    {
                        foreach (AccessPoint ap in loc.AccessPoints)
                        {
                            if (ap == conflictingAccessPoint)
                            {
                                conflictingLocation = loc;
                            }
                        }
                    }
                    noConflict = false;
                    MessageBox.Show("The location : " + conflictingLocation.Title + " is already using the " + conflictingAccessPoint.Direction + " access Point to access Location: " + apPnl.cbDest.Text);
                    apPnl.cbDest.Text = "";
                    apPnl.cbDest.Select();
                }
                if (!noConflict)
                {
                    break;
                }
            }

            return noConflict;
        }
        private bool ClearConflictIfExistingInAllAccessPointPnls()
        {
            bool conflictInAccessPoints = false;
            foreach (AccessPointPnl apPn in accessPointsPnls)
            {
                if (IsConflictExistingWithAnotherAccessPoint(apPn.cbDest))
                {
                    conflictInAccessPoints = true;
                    ClearAccessPointsConflicts();
                }
            }

            return conflictInAccessPoints;
        }
        private void SyncOldAccessPointsAndNewOnes()
        {
            foreach (AccessPoint oldAp in accessPointsOnFormLoad)
            {
                bool apFound;
                apFound = false;
                Zone zone = world.GetZoneFromString(oldAp.DestZone);
                Location loc = zone.GetLocationByName(oldAp.DestLoc);
                foreach (AccessPoint newAp in accessPoints)
                {
                    if (oldAp.IsEqualTo(newAp))
                    {
                        apFound = true;
                    }

                }
                if (!apFound)
                {
                    RemoveOppositeAccessPointFromLocation(oldAp, loc);
                }
            }
        }
        private void RemoveOppositeAccessPointFromLocation(AccessPoint ap, Location loc)
        {
            bool apRemoved = false;
            foreach (AccessPoint oppositeAp in loc.AccessPoints)
            {
                if (AccessPoint.ReturnOppositeDirection(ap.Direction) == oppositeAp.Direction &&
                    currentZone.Name == oppositeAp.DestZone &&
                    currentLocation.Title == oppositeAp.DestLoc)
                {
                    loc.AccessPoints.Remove(oppositeAp);
                    apRemoved = true;
                }
                if (apRemoved)
                    break;
            }
        }
        private void AutoSelectRelativeCbDest(ComboBox cbZone)
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (apPnl.cbZone == cbZone)
                {
                    if (cbZone.Text != "NONE")
                    {
                        apPnl.cbDest.Select();
                    }
                }
            }
        }
        private bool IsConflictExistingWithAnotherAccessPoint(ComboBox cb)
        {
            return (GetConflictingAccessPoint(cb) != null);
        }

        private AccessPoint GetConflictingAccessPoint(ComboBox cb)
        {
            if (!String.IsNullOrWhiteSpace(cb.Text))
            {
                AccessPointPnl currentApPnl = GetAccessPointPanelFromCb(cb);
                AccessPoint tempAp = GetAccessPointFromAnAccessPointPanel(currentApPnl);
                List<AccessPoint> allAccessPoints = AccessPoint.GetAllAccessPointFromWorldExceptFromOneLocation(world, currentLocation);

                foreach (AccessPoint ap in allAccessPoints)
                {
                    if (ap.IsEqualTo(tempAp))
                    {
                        return ap;
                    }
                }
                return null;
            }
            return null;
        }

        private AccessPointPnl GetAccessPointPanelFromCb(ComboBox cb)
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                if (apPnl.cbDest == cb)
                {
                    return apPnl;
                }
            }
            return null;
        }
        private AccessPoint GetAccessPointFromAnAccessPointPanel(AccessPointPnl currentApPnl)
        {
            if (currentApPnl.cbZone.Text != "NONE" &&
               (!String.IsNullOrWhiteSpace(currentApPnl.cbDest.Text)))
            {
                AccessPoint tempAp = new AccessPoint(currentApPnl.lblDir.Text,
                                                        currentApPnl.cbZone.Text,
                                                        currentApPnl.cbDest.Text);
                return tempAp;
            }
            return null;
        }
        #endregion

        #region EVENT HANDLERS
        private void EventCbZone_SelectedIndexChanged(Object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            ReinitializeAllFieldRelativeToThisZoneComboBox(cb);
        }
        private void EventCbDest_OnLeave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            

            ReinitializeAllFieldRelativeToThisDestinationComboBox(cb);
        }

        




        #endregion
    }
}
