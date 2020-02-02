using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bilalAdarsh;

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
    }

}