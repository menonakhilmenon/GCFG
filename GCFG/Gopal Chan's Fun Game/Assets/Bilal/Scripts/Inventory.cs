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

        public void addItem(Item a)
        {
            if (currentWeight + a.weight > maxWeight)
            {
                Debug.Log("Moonji !");
                return;
            }
            currentWeight += a.weight;
            if (items.ContainsKey(a))
                items[a]++;
            else
                items.Add(a, 1);

            Debug.Log(a.resourceType);
        }




    }
}

