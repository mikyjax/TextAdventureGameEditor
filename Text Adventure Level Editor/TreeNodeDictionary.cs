using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventureCommon;
using System.Drawing;
namespace TextAdventureGame
{
    public class TreeNodeDictionary
    {
        Dictionary<TreeNode, Oobject> pairTreeNodeObjects;
        Dictionary<TreeNode, Inventory> pairTreeNodeInventory;

        public TreeNodeDictionary(Location location)
        {
            pairTreeNodeObjects = new Dictionary<TreeNode, Oobject>();
            pairTreeNodeInventory = new Dictionary<TreeNode, Inventory>();

            fillDictionaries(location);
        }

        private void fillDictionaries(Location location)
        {

            TreeNode rootNode = new TreeNode("Void");
            Oobject currentObject = location.Void;
            Add(rootNode, currentObject);

            recursiveFilling(currentObject, rootNode);
        }

        private void recursiveFilling(Oobject obj,TreeNode currentNode)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            treeNodes = addInventoryNodes(obj);
            //add every thing to currentNode
            foreach (TreeNode node in treeNodes)
            {
                Inventory currentInventory = null;
                List<Oobject> childObjects = new List<Oobject>();

                if (pairTreeNodeInventory.TryGetValue(node, out currentInventory))
                {
                    foreach (var childObject in childObjects)
                    {

                        TreeNode objectNode = new TreeNode(childObject.Name);
                        node.Nodes.Add(objectNode);
                        Add(objectNode, childObject);
                        recursiveFilling(childObject,node);
                    }
                    currentNode.Nodes.Add(node);
                }
            }
        }

        public TreeNode GetRootNode(Location tempLocation)
        {
            TreeNode node = new TreeNode();
            node = KeyByValue(pairTreeNodeObjects, tempLocation.Void);
            return node;
        }

        private List<TreeNode> addInventoryNodes(Oobject oobject)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            TreeNode tempNode = null;
            tempNode = addInventoryNode(oobject.HasAboveContainer,oobject.aboveInventory,"Above");
            if (tempNode != null)
            {
                tempNode.ForeColor = Color.Red;
                treeNodes.Add(tempNode);
                tempNode = null;
            }
            tempNode = addInventoryNode(oobject.HasInsideContainer, oobject.insideInventory, "Inside");
            if (tempNode != null)
            {
                tempNode.ForeColor = Color.Red;
                treeNodes.Add(tempNode);
                tempNode = null;
            }
            tempNode = addInventoryNode(oobject.HasUnderContainer, oobject.underInventory, "Under");
            if (tempNode != null)
            {
                tempNode.ForeColor = Color.Red;
                treeNodes.Add(tempNode);
                tempNode = null;
            }

            return treeNodes;
        }

        private TreeNode addInventoryNode(bool objectHasContainer,Inventory objectInventory ,string inventoryNodeName)
        {
            if (objectHasContainer)
            {
                TreeNode node = new TreeNode(inventoryNodeName);
                Add(node, objectInventory);
                return node;
            }
            return null;
        }
        public static TreeNode KeyByValue(Dictionary<TreeNode, Oobject> dict,  Oobject obj)
        {
            TreeNode key = null;
            foreach (KeyValuePair<TreeNode, Oobject> pair in dict)
            {
                if (pair.Value == obj)
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }
        public void Add(TreeNode node, Oobject oobject)
        {
            pairTreeNodeObjects.Add(node, oobject);
        }
        public void Add(TreeNode node,Inventory inventory)
        {
            pairTreeNodeInventory.Add(node, inventory);
        }
    }
}
