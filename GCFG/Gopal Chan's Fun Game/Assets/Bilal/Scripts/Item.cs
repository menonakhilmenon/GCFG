using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilalAdarsh
{ 
    public class Item : ScriptableObject
    {
        [Tooltip("The model of the gameobject when the item is dropped")]
        public GameObject dropModel = null;
        [Tooltip("The weight of the item when carrying around in inventory")]
        public float weight;

        public virtual void UseItem() 
        {
        
        }
    }
}