using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Gopal;
namespace bilalAdarsh
{
    public class PickUp : MonoBehaviour
    {
        public Item itemType;
        public Action eventPickup;

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Collector>()?.CollectItem?.Invoke(this);
     
        }
      
    }
}