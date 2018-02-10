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
        Location currentLocation;
        World world = null;
        public AccessPointForm(Location _currentLocation,Zone _currentZone, World _world, List<AccessPoint> tempAccessPoints)
        {
            currentLocation = _currentLocation;
            currentZone = _currentZone;
            world = _world;
            accessPoints = tempAccessPoints;
            currentZone = world.GetZoneOfLocation(currentLocation);

            InitializeComponent();
            CreateAccessPointsPnls();
            ReInitializeAccessPointsPnls();
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

        }
        #endregion

        #region HELPERS
        private void CreateAccessPointsPnls()
        {
            AccessPointPnl apPnlN = new AccessPointPnl(lblDirN, cbZoneN, cbLocN, btnMoreN);
            AccessPointPnl apPnlNE = new AccessPointPnl(lblDirNE, cbZoneNE, cbLocNE, btnMoreNE);
            AccessPointPnl apPnlE = new AccessPointPnl(lblDirE, cbZoneE, cbLocE, btnMoreE);
            AccessPointPnl apPnlSE = new AccessPointPnl(lblDirSE, cbZoneSE, cbLocSE, btnMoreSE);
            AccessPointPnl apPnlS = new AccessPointPnl(lblDirS, cbZoneS, cbLocS, btnMoreS);
            AccessPointPnl apPnlSW = new AccessPointPnl(lblDirSW, cbZoneSW, cbLocSW, btnMoreSW);
            AccessPointPnl apPnlW = new AccessPointPnl(lblDirW, cbZoneW, cbLocW, btnMoreW);
            AccessPointPnl apPnlNW = new AccessPointPnl(lblDirNW, cbZoneNW, cbLocNW, btnMoreNW);


            accessPointsPnls.Add(apPnlN);
            accessPointsPnls.Add(apPnlNE);
            accessPointsPnls.Add(apPnlE);
            accessPointsPnls.Add(apPnlSE);
            accessPointsPnls.Add(apPnlS);
            accessPointsPnls.Add(apPnlSW);
            accessPointsPnls.Add(apPnlW);
            accessPointsPnls.Add(apPnlNW);

            fillCbZones();
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
            
        }
        private void fillCbZones()
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                List<string> zoneNames = new List<string>();
                zoneNames.Add("NONE");
                zoneNames.AddRange(world.GetAllZones());
                apPnl.cbZone.Items.AddRange(zoneNames.ToArray());
                apPnl.cbZone.SelectedIndex = 0;
            }
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
