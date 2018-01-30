using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure_Game_Engine
{
    class AccessPointPnl
    {
        public Panel panel { get; set; }
        public ComboBox cbDir { get; set; }
        public ComboBox cbDest { get; set; }
        public Button btnGoDest { get; set; }
        public int id { get; set ; }
        public AccessPointPnl(int _id, Panel _panel,ComboBox _cbDir,ComboBox _cbDest,Button _btnGoDest)
        {
            id = _id;
            panel = _panel;
            cbDir = _cbDir;
            cbDest = _cbDest;
            btnGoDest = _btnGoDest;
            
        }
        //only show as much access point panels as there is in the accessPoints list (+1panel to write the next)
        static public void ResetAccessPointsPnls(List<AccessPointPnl> apPnls,List<AccessPoint> accessPoints)
        {
            foreach (var apPnl in apPnls)
            {
                apPnl.cbDir.Items.AddRange(AccessPoint.DIRECTIONS);
                apPnl.btnGoDest.Enabled = false;
                if(apPnl.id > accessPoints.Count())
                {
                    apPnl.panel.Visible = false;
                }
            }
        }
        
        //static public void UpdateAccessPointsPnls(List<AccessPointPnl> apPnls,List<AccessPoint> accessPoints)
        //{
        //    accessPoints.Clear();
        //    foreach(AccessPointPnl apPnl in apPnls)
        //    {
        //        if(apPnl.cbDir.Text !="" && apPnl.cbDest.Text != "")
        //        {
        //            AccessPoint aP = new AccessPoint(apPnl.cbDir.Text, apPnl.cbDest.Text);
        //            accessPoints.Add(aP);
        //        }
        //    }
        //}

        public static bool isValidDirectionInCbApDir(ComboBox cbApDir)
        {
            foreach (string dir in AccessPoint.DIRECTIONS)
            {
                if(dir == cbApDir.Text)
                {
                    return  true;
                }
                
            }
            cbApDir.Text = "";
            cbApDir.Select();
            return false;

        }
    }
}
