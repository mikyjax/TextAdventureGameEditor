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

        public TreeNodeDictionary(Oobject rootObjectCopy)
        {
            pairTreeNodeObjects = new Dictionary<TreeNode, Oobject>();
            pairTreeNodeInventory = new Dictionary<TreeNode, Inventory>();

            fillDictionaries(rootObjectCopy);
        }

        private void fillDictionaries(Oobject rootOject)
        {

            TreeNode rootNode = new TreeNode("Void");
            Oobject currentObject = rootOject;
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
                

                if (pairTreeNodeInventory.TryGetValue(node, out currentInventory))
                {
                    
                    foreach (var childObject in currentInventory.objects)
                    {

                        TreeNode objectNode = new TreeNode(childObject.Name);
                        node.Nodes.Add(objectNode);
                        Add(objectNode, childObject);
                        recursiveFilling(childObject,objectNode);//chnage here
                    }
                    currentNode.Nodes.Add(node);
                }
            }
        }

        internal Oobject GetObject(TreeNode node)
        {
            Oobject obj = null;
            if(pairTreeNodeObjects.TryGetValue(node, out obj))
            {
                return obj;
            }
            return null;
        }
        internal Inventory GetInventory(TreeNode node)
        {
            Inventory inv = null;
            if (pairTreeNodeInventory.TryGetValue(node, out inv))
            {
                return inv;
            }
            return null;
        }

        public TreeNode GetRootNode(Oobject rootObject)
        {
            TreeNode node = new TreeNode();
            node = GetNode( rootObject);
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
        public  TreeNode GetNode(  Oobject obj)
        {
            TreeNode key = null;
            foreach (KeyValuePair<TreeNode, Oobject> pair in pairTreeNodeObjects)
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
