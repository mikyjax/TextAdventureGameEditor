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
            TreeNode treeNode = TreeNodeDict.GetRootNode(tempLocation);
            treeView.Nodes.Clear();
            treeView.Nodes.Add(treeNode);
            treeView.ExpandAll();
            treeView.SelectedNode = treeView.Nodes[0];

        }

        internal bool IsNodeObject(TreeNode node)
        {
            if (TreeNodeDict.GetObject(node) != null)
            {
                return true;
            }
            return false;
        }

        internal Oobject CreateNewObject(TreeNode selectedNode)
        {
            Inventory currentInventory = TreeNodeDict.GetInventory(selectedNode);
            Oobject newObject = new SolidObject(currentInventory);
            newObject.Name = "New Object";
            TreeNode childNode = selectedNode.Nodes.Add(newObject.Name);
            TreeNodeDict.Add(childNode, newObject);
            fillTreeNode(tempLocation);
            return newObject;
        }

        
    }
}
