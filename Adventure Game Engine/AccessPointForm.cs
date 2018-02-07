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
    public partial class AccessPointForm : Form
    {
        public List<Zone> Zones { get; set; }
        private Zone currentZone;
        List<AccessPointPnl> accessPointsPnls = new List<AccessPointPnl>();
        List<AccessPoint> accessPoints = new List<AccessPoint>();
        Location currentLocation;
        World world = null;
        public AccessPointForm(Location _currentLocation,Zone _currentZone, World _world)
        {
            currentLocation = _currentLocation;
            currentZone = _currentZone;
            world = _world;
            accessPoints = currentLocation.AccessPoints;
            currentZone = world.GetZoneOfLocation(currentLocation);

            InitializeComponent();
            createAccessPointsPnls();
            reInitializeAccessPointsPnls();
        }

        private void AccessPointForm_Load(object sender, EventArgs e)
        {
            
        }
        private void createAccessPointsPnls()
        {
            AccessPointPnl apPnlN = new AccessPointPnl(lblDirN,cbZoneN, cbLocN, btnMoreN);
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
        }
        private void reInitializeAccessPointsPnls()
        {
            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {
                apPanel.cbDest.Text = "";
                apPanel.btnMore.Visible = false;

                //FormHelpersFuntions.addLocationsExceptOneToCb(tempLocations, currentLocation, apPanel.cbDest);
            }
            

        }

        private void btnMoreN_Click(object sender, EventArgs e)
        {

        }
        private void fillCbZones()
        {
            foreach (AccessPointPnl apPnl in accessPointsPnls)
            {
                List<string> zoneName = new List<string>();
                zoneName.Add("NONE");
                zoneName.AddRange(world.GetAllZones());
                apPnl.cbZone.Items.AddRange(zoneName.ToArray());
                apPnl.cbZone.SelectedIndex = 0;
            }
        }
    }
}
