using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bilalAdarsh;
using static bilalAdarsh.Item;

namespace Gopal
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private Resource gold = null;
        [SerializeField]
        private Resource stone = null;
        [SerializeField]
        private Resource wood = null;

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
            if (inventory.AddItem(i.itemType)) {
                Destroy(i.gameObject);
            };
            inventory.PrintItems();
        }

        public Dictionary<Item,int> DumpInventory()
        {
            var res = inventory.GetInventory();
            inventory.Clear();
            return res;
        }

        public Dictionary<Item,int> DumpResources()
        {
            Dictionary<Item, int> returnValues = new Dictionary<Item, int>();
            int goldCount = inventory.GetResourceCount(gold);
            int stoneCount = inventory.GetResourceCount(stone);
            int woodCount = inventory.GetResourceCount(wood);

            returnValues.Add(gold, goldCount);
            returnValues.Add(stone, stoneCount);
            returnValues.Add(wood, woodCount);

            RemoveResourceSpecific(gold, goldCount);
            RemoveResourceSpecific(stone, stoneCount);
            RemoveResourceSpecific(wood, woodCount);

            return returnValues;
        }

        public bool RemoveResourceSpecific(Item resourceType,int resourceCount)
        {
            int availableResourceCount = inventory.GetResourceCount(resourceType);
            if(availableResourceCount >= resourceCount)
            {
                foreach (var item in inventory.items.Keys)
                {
                    if(item == resourceType)
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