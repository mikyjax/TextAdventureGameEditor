using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAdventureGame
{
    class AccessPointPnl
    { 
        public Label lblDir { get; set; }
        public ComboBox cbDest { get; set; }
        public Button btnMore { get; set; }
        public ComboBox cbZone;
        public string direction;
        public int id { get; set ; }
        public AccessPointPnl(string _dir,Label _lblDir,ComboBox _zone,ComboBox _cbDest,Button _btnMore)
        {
            direction = _dir;
            lblDir = _lblDir;
            cbZone = _zone;
            cbDest = _cbDest;
            btnMore = _btnMore;
            
        }
    }
}
