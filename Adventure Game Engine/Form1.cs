using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adventure_Game_Engine
{
    public partial class Form1 : Form
    {
        List<Location> Locations = new List<Location>();
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
            foreach (Location loc in Locations)
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
            foreach (Location loc in Locations)
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
            createAccessPointsPnls();
            AccessPointPnl.ResetAccessPointsPnls(accessPointsPnls, accessPoints);
            clearAllFields();

            tbLocName.Select();
        }
        private void createAccessPointsPnls()
        {
            AccessPointPnl apPnl0 = new AccessPointPnl(0, pnlAp0, cbApDir0, cbApDest0, btnApGo0);
            AccessPointPnl apPnl1 = new AccessPointPnl(1, pnlAp1, cbApDir1, cbApDest1, btnApGo1);
            AccessPointPnl apPnl2 = new AccessPointPnl(2, pnlAp2, cbApDir2, cbApDest2, btnApGo2);
            AccessPointPnl apPnl3 = new AccessPointPnl(3, pnlAp3, cbApDir3, cbApDest3, btnApGo3);
            AccessPointPnl apPnl4 = new AccessPointPnl(4, pnlAp4, cbApDir4, cbApDest4, btnApGo4);
            AccessPointPnl apPnl5 = new AccessPointPnl(5, pnlAp5, cbApDir5, cbApDest5, btnApGo5);
            AccessPointPnl apPnl6 = new AccessPointPnl(6, pnlAp6, cbApDir6, cbApDest6, btnApGo6);
            AccessPointPnl apPnl7 = new AccessPointPnl(7, pnlAp7, cbApDir7, cbApDest7, btnApGo7);

            accessPointsPnls.Add(apPnl0);
            accessPointsPnls.Add(apPnl1);
            accessPointsPnls.Add(apPnl2);
            accessPointsPnls.Add(apPnl3);
            accessPointsPnls.Add(apPnl4);
            accessPointsPnls.Add(apPnl5);
            accessPointsPnls.Add(apPnl6);
            accessPointsPnls.Add(apPnl7);
            initializeAccessPointsPnls();
        }

        private void initializeAccessPointsPnls()
        {
            //Add auto complete selection to CB Dir
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(AccessPoint.DIRECTIONS);

            foreach (AccessPointPnl apPanel in accessPointsPnls)
            {

                apPanel.cbDir.AutoCompleteCustomSource = source;
                apPanel.cbDir.AutoCompleteMode = AutoCompleteMode.Append;
                //Add fuction to cb on textChanged
                apPanel.cbDir.TextChanged += accessPointCBTextChanged;
                apPanel.cbDest.TextChanged += accessPointCBTextChanged;
            }
        }



        //debug function
        private void showLocationsInConsole()
        {
            Console.WriteLine("*****************");
            foreach (Location loc in Locations)
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
            foreach (Location loc in Locations)
            {
                if (loc.Title == roomToEdit)
                {
                    currentLocation = loc;
                    showCurrentRoomInForm(currentLocation);
                }
            }

        }
        private void accessPointCBTextChanged(object sender, EventArgs e)
        {
            foreach (var apPnl in accessPointsPnls)
            {
                if (sender.Equals(apPnl.cbDest) || sender.Equals(apPnl.cbDir))
                {
                    if (apPnl.cbDir.Text != "" && apPnl.cbDest.Text != "")
                    {
                        
                        apPnl.btnGoDest.Enabled = true;
                        foreach(AccessPointPnl _apPnl in accessPointsPnls)
                        {
                            if(_apPnl.id == apPnl.id + 1)
                            {
                                _apPnl.panel.Visible = true;
                                _apPnl.panel.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        apPnl.btnGoDest.Enabled = false;
                    }

                }
            }
        }
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (currentLocation != null)
                Locations.Remove(currentLocation);

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
                Locations.Add(new Location(tbLocName.Text, tbLocDesc.Text));
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
            Locations.Add(loc);
            foreach (Location _loc in Locations)
            {
                Console.WriteLine(_loc.Title);
                Console.WriteLine(_loc.Description);
                Console.WriteLine();
            }
        }

        private void onCbApDirLeave(object sender, EventArgs e)
        {
            if(!AccessPointPnl.isValidDirectionInCbApDir((ComboBox)sender)){
                MessageBox.Show("Please, select a valid direction");
                
            }
        }
    }

        
    }
