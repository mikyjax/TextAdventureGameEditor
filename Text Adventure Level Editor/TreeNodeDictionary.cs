using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventureCommon;
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
            Add(rootNode, location.Void);

            TreeNode currentNode = rootNode;
            do
            {

            }while()
            

            addInventoryNodes(location.Void);

        }

        private void addInventoryNodes(Oobject oobject)
        {
            addInventoryNode(oobject.HasAboveContainer,oobject.aboveInventory,"Above");
            addInventoryNode(oobject.HasInsideContainer, oobject.insideInventory, "Inside");
            addInventoryNode(oobject.HasUnderContainer, oobject.underInventory, "Under");
        }

        private void addInventoryNode(bool objectHasContainer,Inventory objectInventory ,string inventoryNodeName)
        {
            if (objectHasContainer)
            {
                TreeNode node = new TreeNode(inventoryNodeName);
                Add(node, objectInventory);
            }
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
