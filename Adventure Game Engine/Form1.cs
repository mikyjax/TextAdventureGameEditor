using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adventure_Game_Engine
{ 
    public partial class Form1 : Form
    {
        List<Location> locations = new List<Location>();
        Location currentLocation = null;
        List<AccessPointPnl> accessPointsPnls = new List<AccessPointPnl>();
        List<AccessPoint> accessPoints = new List<AccessPoint>();
        public Form1()
        {
            InitializeComponent();
            reinitializeForm();
            //initiateAccessPoints();
            
        }
        //compare the title of a room to the list of the game locations.
        private Location isRoomExistingInLocations(List<Location> locations)
        {
            foreach (Location loc in this.locations)
            {
                if (loc.Title == tbLocName.Text)
                {
                    return loc;
                }
            }
            return null;
        }
        
        private void clearAllFields()
        {
            cbLocationChoice.Text = "";
            tbLocName.Text = "";
            tbLocDesc.Text = "";
        }
        private void refreshAddRoomBtn()
        {
            if (string.IsNullOrWhiteSpace(tbLocName.Text))
            {
                btnAddRoom.Enabled = false;
                btnDeleteRoom.Enabled = false;
            }
            else
            {
                btnAddRoom.Enabled = true;
                btnDeleteRoom.Enabled = true;
            }

        }
        private void getLocationsInCB(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (Location loc in locations)
            {
                cb.Items.Add(loc.Title);
            }
            
        }
        private void showCurrentRoomInForm(Location loc)
        {
            clearAllFields();
            tbLocName.Text = loc.Title;
            tbLocDesc.Text = loc.Description;


        }
        private void reinitializeForm()
        {
            currentLocation = null;
            getLocationsInCB(cbLocationChoice);
            refreshAddRoomBtn();
            
            clearAllFields();

            tbLocName.Select();
        }
        

        //private void initializeAccessPointsPnls()
        //{
        //    //Add auto complete selection to CB Dir
        //    AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        //    source.AddRange(AccessPoint.DIRECTIONS);

        //    foreach (AccessPointPnl apPanel in accessPointsPnls)
        //    {

        //        apPanel.cbDir.AutoCompleteCustomSource = source;
        //        apPanel.cbDir.AutoCompleteMode = AutoCompleteMode.Append;
        //        //Add fuction to cb on textChanged
        //        apPanel.cbDir.TextChanged += accessPointCBTextChanged;
        //        apPanel.cbDest.TextChanged += accessPointCBTextChanged;
        //    }
        //}



        //debug function
        private void showLocationsInConsole()
        {
            Console.WriteLine("*****************");
            foreach (Location loc in locations)
            {
                Console.WriteLine(loc.Title);
                Console.WriteLine(loc.Description);
                Console.WriteLine();
            }
        }

        private void SelectRoom(object sender, EventArgs e)
        {
            string roomToEdit;
            roomToEdit = cbLocationChoice.Text;
            foreach (Location loc in locations)
            {
                if (loc.Title == roomToEdit)
                {
                    currentLocation = loc;
                    showCurrentRoomInForm(currentLocation);
                }
            }

        }
        //private void accessPointCBTextChanged(object sender, EventArgs e)
        //{
        //    foreach (var apPnl in accessPointsPnls)
        //    {
        //        if (sender.Equals(apPnl.cbDest) || sender.Equals(apPnl.cbDir))
        //        {
        //            if (apPnl.cbDir.Text != "" && apPnl.cbDest.Text != "")
        //            {
                        
        //                apPnl.btnGoDest.Enabled = true;
        //                foreach(AccessPointPnl _apPnl in accessPointsPnls)
        //                {
        //                    if(_apPnl.id == apPnl.id + 1)
        //                    {
        //                        _apPnl.panel.Visible = true;
        //                        _apPnl.panel.Enabled = true;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                apPnl.btnGoDest.Enabled = false;
        //            }

        //        }
        //    }
        //}
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (currentLocation != null)
                locations.Remove(currentLocation);

            clearAllFields();
            getLocationsInCB(cbLocationChoice);
            tbLocName.Select();
            currentLocation = null;

        }
        private void RefreshTbName(object sender, EventArgs e)
        {
            refreshAddRoomBtn();
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (currentLocation == null)
            {
                //create new room
                locations.Add(new Location(tbLocName.Text, tbLocDesc.Text));
            }
            else
            {
                //edit room
                currentLocation.Title = tbLocName.Text;
                currentLocation.Description = tbLocDesc.Text;
            }

            reinitializeForm();
        }
        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            Location loc = new Location(tbLocName.Text, tbLocDesc.Text);
            locations.Add(loc);
            foreach (Location _loc in locations)
            {
                Console.WriteLine(_loc.Title);
                Console.WriteLine(_loc.Description);
                Console.WriteLine();
            }
        }

        private void btnAddEdditAccessPoint_Click(object sender, EventArgs e)
        {
            AccessPointForm accessPointForm = new AccessPointForm(currentLocation, locations);
            accessPointForm.ShowDialog();
        }
    }

        
    }
