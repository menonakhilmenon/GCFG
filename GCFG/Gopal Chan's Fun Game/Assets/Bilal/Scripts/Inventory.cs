using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace bilalAdarsh
{
    [RequireComponent(typeof(PhotonView))]
    public class Inventory : MonoBehaviourPun
    {
        public Dictionary<Item, int> items = new Dictionary<Item, int>();
        public float currentWeight;
        public float maxWeight;

        private void Start()
        {
            if (photonView.IsMine) 
            {
                PlayerManager.instance.LocalPlayerInventory = this;
            }
        }


        public bool AddItem(Item a)
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
        
        public int GetResourceCount(Item.Type itemType)
        {
            foreach(var kvp in items)
            {
                if(kvp.Key.resourceType == itemType)
                {
                    return kvp.Value;
                }
            }
            return 0;
        }

        public Dictionary<Item,int> GetInventory()
        {
            return items;
        }

        public void PrintItems()
        {
            foreach(KeyValuePair<Item,int> kvp in items)
            {
                Debug.Log(kvp.Key + " " + kvp.Value);
            }
        }

        public bool RemoveItem(Item i,int count)
        {
            if(items.ContainsKey(i) && items[i] >= count)
            {
                items[i] -= count;
                return true;
            }
            return false;
        }

        public int ReturnItemCount(Item i)
        {
            if(items.ContainsKey(i))
            {
                return items[i];
            }
            return -1;
        }

        public void Clear()
        {
            items.Clear();
        }


    }
}

