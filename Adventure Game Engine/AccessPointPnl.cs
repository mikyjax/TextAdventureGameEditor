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
        static public void ResetAccessPointsPnls(List<AccessPointPnl> apPnls,List<AccessPoint> accessPoints)
        {
            foreach (var apPnl in apPnls)
            {
                apPnl.btnGoDest.Enabled = false;
                if(apPnl.id > accessPoints.Count())
                {
                    apPnl.panel.Visible = false;
                }
            }
        }
    }
}
