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
    public partial class EditZonesForm : Form
    {
        bool isUserEditingAZone = false;
        World world;
        List<String> zoneNames = new List<String>();
        string newRoomText = ".Create New Room";
        public EditZonesForm(World _world)
        {
            world = _world;

            
            InitializeComponent();

            lbZones.Items.AddRange(zoneNames.ToArray<String>());
            refreshLbZone();
            

        }

        private void btnAddOrEditZone_Click(object sender, EventArgs e)
        {
            String newZoneName = tbNameZone.Text.Trim();

            if (isUserEditingAZone)
            {
                string oldKey = lbZones.SelectedItem.ToString();
                string newKey = tbNameZone.Text;
                if(newKey != oldKey)
                {
                    Zone newZone = new Zone(newKey);
                    world.zones.Add(newZoneName, newZone);
                    world.zones.Remove(oldKey);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbNameZone.Text))//if not empty, user is trying to create a zone,
                {
                    if (!isExistingInZoneName(newZoneName))//if the name of the zone isn't already used, we create that zone.
                    {
                        Zone newZone = new Zone(newZoneName);
                        world.zones.Add(newZoneName, newZone);
                    }

                }
            }
            refreshLbZone();
        }

        private bool isExistingInZoneName(string zoneName)
        {
            foreach (String zoneNameKey in world.zones.Keys)
            {
                if(zoneName == zoneNameKey)
                {
                    return true;
                }
               
            }
            return false;
        }

        private void refreshLbZone()
        {
            lbZones.Items.Clear();
            zoneNames.Clear();
            zoneNames.Add(newRoomText);
            foreach (String zoneName in world.zones.Keys)
            {
                zoneNames.Add(zoneName);
            }
            zoneNames.Sort();
            lbZones.Items.AddRange(zoneNames.ToArray());
            lbZones.SelectedItem = newRoomText;
            tbNameZone.Select();
            tbNameZone.Text = "";

            
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbZones.SelectedItem.ToString() == newRoomText)
            {
                btnDeleteZone.Enabled = false;
                tbNameZone.Text = "";
                isUserEditingAZone = false;
                btnAddOrEditZone.Text = "Add new Zone";
            }
            else
            {
                btnDeleteZone.Enabled = true;
                tbNameZone.Text = lbZones.SelectedItem.ToString();
                isUserEditingAZone = true;
                btnAddOrEditZone.Text = "Change name of the selected zone";
            }
        }
    }
}
