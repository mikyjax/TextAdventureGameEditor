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
        public List<Location> locations { get; set; }
        List<Location> tempLocation = new List<Location>();
        List<AccessPointPnl> accessPointsPnls = new List<AccessPointPnl>();
        Location currentLocation;
        public AccessPointForm(Location _currentLocation, List<Location> _locations)
        {

            currentLocation = _currentLocation;
            locations = _locations;
            tempLocation.Clear();
            tempLocation.AddRange(locations);

            InitializeComponent();
            createAccessPointsPnls();
            reInitializeAccessPointsPnls();
        }

        private void AccessPointForm_Load(object sender, EventArgs e)
        {
            
        }
        private void createAccessPointsPnls()
        {
            AccessPointPnl apPnlN = new AccessPointPnl(lblDirN, cbLocN, btnMoreN);
            AccessPointPnl apPnlNE = new AccessPointPnl(lblDirNE, cbLocNE, btnMoreNE);
            AccessPointPnl apPnlE = new AccessPointPnl(lblDirE, cbLocE, btnMoreE);
            AccessPointPnl apPnlSE = new AccessPointPnl(lblDirSE, cbLocSE, btnMoreSE);
            AccessPointPnl apPnlS = new AccessPointPnl(lblDirS, cbLocS, btnMoreS);
            AccessPointPnl apPnlSW = new AccessPointPnl(lblDirSW, cbLocSW, btnMoreSW);
            AccessPointPnl apPnlW = new AccessPointPnl(lblDirW, cbLocW, btnMoreW);
            AccessPointPnl apPnlNW = new AccessPointPnl(lblDirNW, cbLocNW, btnMoreNW);


            accessPointsPnls.Add(apPnlN);
            accessPointsPnls.Add(apPnlNE);
            accessPointsPnls.Add(apPnlE);
            accessPointsPnls.Add(apPnlSE);
            accessPointsPnls.Add(apPnlS);
            accessPointsPnls.Add(apPnlSW);
            accessPointsPnls.Add(apPnlW);
            accessPointsPnls.Add(apPnlNW);
        }
        private void reInitializeAccessPointsPnls()
        {
            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {
                apPanel.cbDest.Text = "";
                apPanel.btnMore.Visible = false;
                FormHelpersFuntions.addLocationsExceptOneToCb(tempLocation, currentLocation, apPanel.cbDest);
            }
            

        }

        private void btnMoreN_Click(object sender, EventArgs e)
        {

        }
    }
}
