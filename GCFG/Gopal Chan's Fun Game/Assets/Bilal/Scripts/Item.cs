using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilalAdarsh
{ 
    public class Item : ScriptableObject
    {
        [Tooltip("The sprite used for UI")]
        [ShowAssetPreview]
        public Texture uiSprite = null;
        [Tooltip("The model of the gameobject when the item is dropped")]
        public GameObject dropModel = null;
        [Tooltip("The weight of the item when carrying around in inventory")]
        public float weight;



        public virtual string Type => "Item";
        public virtual bool IsUsable => false;

        public virtual string UIDescription 
        {
            get 
            {
                return $"Type : {Type}\nWeight : {weight}";
            }
        }

        public virtual void UseItem() 
        {
            if (!IsUsable)
                return;
        }
    }
}