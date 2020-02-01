using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace bilalAdarsh
{
    public class PickUp : MonoBehaviour
    {
        public Item itemType;
        public Action eventPickup;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameObject player = other.gameObject;
                Inventory i = player.GetComponent<Inventory>();
                i.addItem(itemType);
                Destroy(gameObject);
                eventPickup?.Invoke();
            }
        }
      
    }
}