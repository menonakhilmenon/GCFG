using NaughtyAttributes;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace bilalAdarsh
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private ScriptableGameEvent inventoryChangeEvent = null;

        private Dictionary<Item, int> items = new Dictionary<Item, int>();
        public float currentWeight => GetCurrentWeight();

        private float GetCurrentWeight()
        {
            float weight = 0f;
            foreach (var item in items)
            {
                weight += item.Key.weight * item.Value;
            }
            return weight;
        }

        public float maxWeight;

        private bool isLocal => PlayerManager.instance.LocalPlayerInventory == this;


        public bool AddItem(Item a)
        {
            return AddItem(a, 1);
        }
        public bool AddItem(Item a,int count)
        {
            if (!TryAdd(a,count))
                return false;

            if (items.ContainsKey(a))
                items[a]+=count;
            else
                items.Add(a, count);

            if (isLocal)
                inventoryChangeEvent?.Invoke();
            return true;
        }



        public bool TryAdd(Item a)
        {
            return TryAdd(a, 1);
        }
        public bool TryAdd(Item a,int count)
        {
            if (currentWeight + a.weight * count > maxWeight)
            {
                return false;
            }
            return true;
        }


        public int GetItemCount(Item itemType)
        {
            if (items.ContainsKey(itemType))
                return items[itemType];
            return 0;
        }

        public void DropItem(Item discardItem, int discardAmount)
        {
            for (int i = 0; i < discardAmount;)
            {
                int count;
                if (i + 5 < discardAmount)
                {
                    count = 5;
                }
                else
                {
                    count = discardAmount - i;
                }
                var spawnLocation = transform.position + UnityEngine.Random.onUnitSphere * 3f;
                spawnLocation.y = 3f;
                PickupSpawner.SpawnPickup(discardItem, count, spawnLocation, transform.rotation);
                i += count;
            }
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
            if(count <= 0) 
            {
                return true;
            }
            if(TryRemove(i,count))
            {
                items[i] -= count;
                if (items[i] <= 0)
                    items.Remove(i);
                if(isLocal)
                    inventoryChangeEvent?.Invoke();
                return true;
            }
            return false;
        }

        public bool TryRemove(Item i,int count) 
        {
            if (count == 0)
                return true;
            if (items.ContainsKey(i) && items[i] >= count)
            {
                return true;
            }
            return false;
        }


        public bool TryRemoveItems(Dictionary<Item,int> items) 
        {
            var result = true;
            foreach (var item in items)
            {
                result = result && TryRemove(item.Key, item.Value);
            }
            return result;
        }

        public bool RemoveItems(Dictionary<Item,int> items) 
        {
            var result = true;

            foreach (var item in items)
            {
                result = result && RemoveItem(item.Key, item.Value);
            }

            return result;
        }


        public void Clear()
        {
            items.Clear();
            if(isLocal)
                inventoryChangeEvent?.Invoke();
        }
        public void DropAll() 
        {
            foreach (var item in items)
            {
                DropItem(item.Key, item.Value);
            }
            Clear();
        }

    }
}

