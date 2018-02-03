using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adventure_Game_Engine
{ 
    public partial class Form1 : Form
    {
        World world = new World();
        Location currentLocation;
        Location tempLocation;
        Zone currentZone;

        bool isRoomExisting = false;
        bool isZoneExisting = false;


        public Form1()
        {
            InitializeComponent();
            world.Create();
            reInitializeForm();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (isFormValid())//show a warning to user telling him what s wrong with his form.
            {
                
                if (isRoomExisting) //if the room is already existing we save changes to it.
                {
                    
                }
                else //if the room is not existing we add it to the world.
                {
                    if (isZoneExisting) //if the zone exist we add the room to it
                    {

                    }
                    else  //if the zone doesn't exist, we create it and then, add the room to it
                    {
                        currentZone = new Zone(cbZone.Text);
                        currentLocation = new Location(cbLocation.Text, tbLocDesc.Text);
                        currentZone.Locations.Add(currentLocation);
                        world.zones.Add(cbZone.Text, currentZone);
                        reInitializeForm();
                    }
                }
                
            }
        }

        private bool isFormValid()
        {
            if(string.IsNullOrWhiteSpace(cbLocation.Text) || string.IsNullOrWhiteSpace(cbZone.Text))
            {
                string errorCb;
                if (string.IsNullOrWhiteSpace(cbZone.Text))
                {
                    errorCb = "zone name";
                    cbZone.Select();
                }
                else
                {
                    errorCb = "location name";
                    cbLocation.Select();
                }
                MessageBox.Show("You must at least input or select a zone and a location name");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            foreach (Zone zone in world.zones.Values)
            {
                
                Console.WriteLine($"Zone: { zone.Name}");
                foreach (Location loc in zone.Locations)
                {
                    Console.WriteLine($"Location: {loc.Title}");
                    Console.WriteLine($"Id: {loc.Id}\n");
                }
            }
        }
        private void setAllControlsToEnable(bool state)
        {
            cbZone.Enabled = state;
            cbLocation.Enabled = state;
            tbLocDesc.Enabled = state;
            lbAccessPoints.Enabled = state;
            btnAddEdditAccessPoint.Enabled = state;
            btnAddRoom.Enabled = state;
            btnDeleteRoom.Enabled = state;
            btnUpdateDb.Enabled = state;
        }
        private void btnAddEdditAccessPoint_Click(object sender, EventArgs e)
        {
            
        }
        private void reInitializeForm()
        {
            tempLocation = new Location("", "");
            currentLocation = null;
            world.Populate();
            ClearAllFields();
            if (world.zones.Count < 1)
            {
                cbZone.Select();
            }
            else
            {
                cbLocation.Select();
            }
        }

        private void ClearAllFields()
        {
            cbZone.Text = "";
            cbLocation.Text = "";
            tbLocDesc.Text = "";
        }

        private void btnNewZone_Click(object sender, EventArgs e)
        {
            EditZonesForm editZoneForm = new EditZonesForm(world);
            editZoneForm.Show();
        }
    }

        
    }
