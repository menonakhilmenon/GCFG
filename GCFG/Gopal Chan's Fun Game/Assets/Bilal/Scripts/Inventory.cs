using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilalAdarsh
{
    public class Inventory : MonoBehaviour
    {
        public Dictionary<Item, int> items = new Dictionary<Item, int>();
        public float currentWeight;
        public float maxWeight;

        public bool addItem(Item a)
        {
            if (currentWeight + a.weight > maxWeight)
            {
                return false;
            }
            currentWeight += a.weight;
            if (items.ContainsKey(a))
                items[a]++;
            else
                items.Add(a, 1);

            Debug.Log(a.resourceType);
            return true;
        }
    
        Dictionary<Item,int> getInventory()
        {
            return items;
        }

        public void printItems()
        {
            foreach(KeyValuePair<Item,int> kvp in items)
            {
                Debug.Log(kvp.Key + " " + kvp.Value);
            }
        }


    }
}

