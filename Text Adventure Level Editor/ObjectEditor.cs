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

        Inventory InventoryFromCurrentLocation;
        public Inventory tempInventoryFromCurrentLocation;
        public Oobject rootObjectCopy;


        public ObjectEditor(World world,Location tempLocation,Zone currentZone,TreeView treeView)
        {
            this.world = world;
            this.tempLocation = tempLocation;
            this.currentZone = currentZone;
            this.treeView = treeView;

            InventoryFromCurrentLocation = tempLocation.Inventory;
            tempInventoryFromCurrentLocation = Inventory.CopyCompleteInventory(tempLocation.Void);
            rootObjectCopy = tempInventoryFromCurrentLocation.Parent;
            RefreshTreeNodeDict();

        }

        public void RefreshTreeNodeDict()
        {
            TreeNodeDict = CreateTreeNodeDict(rootObjectCopy);
            fillTreeNode();
        }

        public TreeNodeDictionary CreateTreeNodeDict(Oobject rootObjectCopy)
        {
            TreeNodeDictionary tempTreeNodeDict = new TreeNodeDictionary(rootObjectCopy);


            
            return tempTreeNodeDict;
        }

        private void fillTreeNode()
        {
            TreeNode treeNode = TreeNodeDict.GetRootNode(rootObjectCopy);
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

        internal Oobject CreateNewObject(TreeNode selectedNode, String objectType)
        {
            Inventory currentInventory = TreeNodeDict.GetInventory(selectedNode);
            Oobject newObject;
            switch (objectType)
            {
                case Oobject.AccessPointObjectType:
                    newObject = new AccessPointObject(currentInventory);
                    break;
                default:
                    newObject = new SolidObject(currentInventory);
                    break;
            }

            
            newObject.Noun.Singular = "New Object";
            //currentInventory.Add(newObject);
            TreeNode childNode = selectedNode.Nodes.Add(newObject.Noun.Singular);
            TreeNodeDict.Add(childNode, newObject);
            fillTreeNode();
            return newObject;
        }

        internal Oobject GetCurrentObjectSelected(TreeNode selectedNode)
        {
            Oobject selectedObject = TreeNodeDict.GetObject(selectedNode);
            return selectedObject;
        }

        internal TreeNode SelectCorrespondingNode(Oobject tempObject)
        {
            return TreeNodeDict.GetNode(tempObject);
        }

        internal TreeNode SelectCorrespondingNode(Inventory parentInventory)
        {
            return TreeNodeDict.GetNode(parentInventory);
        }
    }
}
