using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bilalAdarsh;
using static bilalAdarsh.Item;

namespace Gopal
{
    public class InventoryManager : MonoBehaviour
    {
        public Inventory inventory;
        // Start is called before the first frame update
        void Start()
        {
            gameObject.GetComponent<Collector>().CollectItem += onCollectItem;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void onCollectItem(PickUp i)
        {
            Debug.Log("XXX");
            if (inventory.addItem(i.itemType)) {
                Destroy(i.gameObject);
            };
            inventory.printItems();
        }

        public Dictionary<Item,int> dumpInventory()
        {
            var res = inventory.getInventory();
            inventory.clear();
            return res;
        }

        public Dictionary<Type,int> DumpResources()
        {
            Dictionary<Type, int> returnValues = new Dictionary<Type, int>();
            int goldCount = inventory.getResourceCount(Type.Gold);
            int stoneCount = inventory.getResourceCount(Type.Stone);
            int woodCount = inventory.getResourceCount(Type.Wood);

            returnValues.Add(Type.Gold, goldCount);
            returnValues.Add(Type.Stone, stoneCount);
            returnValues.Add(Type.Wood, woodCount);

            RemoveResourceSpecific(Type.Gold, goldCount);
            RemoveResourceSpecific(Type.Stone, stoneCount);
            RemoveResourceSpecific(Type.Wood, woodCount);

            return returnValues;
        }

        public bool RemoveResourceSpecific(Type resourceType,int resourceCount)
        {
            int availableResourceCount = inventory.getResourceCount(resourceType);
            if(availableResourceCount >= resourceCount)
            {
                foreach (var item in inventory.items.Keys)
                {
                    if(item.resourceType == resourceType)
                    {
                        inventory.items[item] -= resourceCount;
                        inventory.currentWeight -= item.weight * resourceCount;
                        return true;
                    }
                }
            }
            return false;
        }
    }

}