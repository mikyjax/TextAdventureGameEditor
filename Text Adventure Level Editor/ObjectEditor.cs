using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;
using System.Windows.Forms;

namespace TextAdventureGame
{
    class ObjectEditor
    {
        World world;
        Location tempLocation;
        Zone currentZone;
        TreeView treeView;
        public bool HasGravity { get; set; }
        public TreeNodeDictionary TreeNodeDict { get; set; }


        public ObjectEditor(World world,Location tempLocation,Zone currentZone,TreeView treeView)
        {
            this.world = world;
            this.tempLocation = tempLocation;
            this.currentZone = currentZone;
            this.treeView = treeView;
            TreeNodeDict = new TreeNodeDictionary(tempLocation);
           

            fillTreeNode(this.tempLocation);

        }

        private void fillTreeNode(Location tempLocation)
        {
            

            treeView.Nodes.Clear();
            treeView.Nodes.Add(node);

            

            bool loadingComplete = false;
            while (!loadingComplete)
            {
                TreeNode parentNode = node;

            }
        }
        
    }
}
