using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventureCommon;
namespace TextAdventureGame
{
    static public class FormHelpersFuntions
    {
        static public void addStringArrayToCbAutoComplete(String[] stringList, ComboBox comboBox)
        {   
                           
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                source.AddRange(stringList);

            foreach (String txt in stringList)
            {
                comboBox.AutoCompleteCustomSource = source;
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
            }
        }
        static public void addLocationsExceptOneToCb(List<Location> _locations, Location _locToIgnore, ComboBox _comboBox)
        {
            _comboBox.Items.Clear();

            foreach (Location loc in _locations)
            {
                if(loc.Title != _locToIgnore.Title)
                _comboBox.Items.Add(loc.Title);
            }
        }
        
}
}


