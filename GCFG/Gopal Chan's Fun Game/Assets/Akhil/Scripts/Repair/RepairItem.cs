using bilalAdarsh;
using Gopal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GCFG
{
    public class RepairItem : MonoBehaviour
    {
        [SerializeField]
        private RawImage resourceImage = null;
        [SerializeField]
        private Slider amountSlider = null;
        [SerializeField]
        private TMPro.TMP_Text weightText = null;

        public Item repairItem { get; set; } = null;
        public int repairAmount => amountSlider!=null?Mathf.RoundToInt(amountSlider.value):0;
        

        private float _weight = 0f;

        public float weight 
        {
            get => _weight; 
            set 
            {
                _weight = value;
                UpdateWeightText();
            } 
        }
        private Inventory localInventory => PlayerManager.instance.LocalPlayerInventory;

        public void UpdateWeightText() 
        {
            weightText.text = repairAmount.ToString();
        }
        public void SetItem(Item item) 
        {
            if(item!= null)
                repairItem = item;
            resourceImage.texture = repairItem.uiSprite;
            ResetItem();
        }

        public void ResetItem() 
        {
            if (repairItem == null || weight == 0f) 
            {
                gameObject.SetActive(false);
                return;
            }
            else 
            {
                gameObject.SetActive(true);
            }

            amountSlider.minValue = 0;
            amountSlider.value = 0;
            amountSlider.maxValue = localInventory.GetItemCount(repairItem);
        }
    }
}