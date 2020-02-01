using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilalAdarsh
{ 
    public class Item : ScriptableObject
    {
        public enum Type { Wood, Stone, Gold, Weapon };
        public Type resourceType;
        public float weight;
    }
}