using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gopal
{
    public class RepairTower : MonoBehaviour
    {
        public bool canRepair = false;
        private Dictionary<Item.Type, int> items = new Dictionary<Item.Type, int>();
        public Repairable zone = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Repairable>() != null)
            {
                canRepair = true;
                zone = other.GetComponent<Repairable>();
                items.Clear();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Repairable>() != null)
            {
                canRepair = false;
                zone = null;
                items.Clear();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<Repairable>() != null)
            {
                canRepair = true;
            }
        }


        void Update()
        {
            if (canRepair)
            {
                if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("XXX");
                    items = gameObject.GetComponent<InventoryManager>()?.DumpResources();
                    if (zone != null)
                    {
                        zone.OnRepair?.Invoke(items);
                    }
                }
            }
        }
    }

}
