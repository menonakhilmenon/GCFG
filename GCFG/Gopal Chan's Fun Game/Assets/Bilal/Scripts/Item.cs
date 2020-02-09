using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCFG;
namespace bilalAdarsh
{ 
    public class Item : ScriptableObject
    {
        [Tooltip("The sprite used for UI")]
        [ShowAssetPreview]
        [SerializeField]
        private Texture _uiSprite = null;
        public Texture uiSprite => _uiSprite;

        [Tooltip("The model of the gameobject when the item is dropped")]
        [SerializeField]
        private DroppedItem _dropModel = null;
        public DroppedItem dropModel =>_dropModel;

        [Tooltip("The weight of the item when carrying around in inventory")]
        [SerializeField]
        private float _weight = 1f;
        public float weight=>_weight;

        [SerializeField]
        private string nameText = "";

        public string NameText => nameText;
        
        public virtual string Type => "Item";
        public virtual bool IsUsable => false;

        public virtual string UIDescription 
        {
            get 
            {
                return $"Type : {Type}\nWeight : {weight} kg";
            }
        }

        public virtual void UseItem() 
        {
            if (!IsUsable)
                return;
        }
    }
}