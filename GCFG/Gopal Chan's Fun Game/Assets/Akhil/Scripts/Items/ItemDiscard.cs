using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GCFG
{
    public class ItemDiscard : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text discardAmountText = null;
        [SerializeField]
        private TMP_Text discardWeightText = null;
        [SerializeField]
        private TMP_Text freeWeightText = null;
        [SerializeField]
        private TMP_Text discardItemName = null;
        [SerializeField]
        private RawImage discardItemSprite = null;

        [SerializeField]
        private Button discardButton = null;

        [SerializeField]
        private Slider discardAmountSlider = null;


        private int discardAmount = 0;
        private Item discardItem { get; set; } = null;
        public Inventory localInventory => PlayerManager.instance.LocalPlayerInventory;


        public void SetDiscardSlider() 
        {
            discardAmountSlider.minValue = 0;
            discardAmountSlider.value = 0;
            discardAmountSlider.maxValue = localInventory.GetItemCount(discardItem);
        }

        public void SelectItem(Item item) 
        {
            if(item != null) 
            {
                discardItem = item;
                discardItemSprite.texture = item.uiSprite;
                discardItemName.text = discardItem.name;
                if (localInventory.GetItemCount(item) <= 0)
                {
                    discardButton.interactable = false;
                }
                else
                {
                    discardButton.interactable = true;
                }

                SetDiscardSlider();
            }
            else 
            {
                discardButton.interactable = false;
            }
        }


        public void DiscardItems() 
        {
            if (localInventory.RemoveItem(discardItem, discardAmount)) 
            {
                for (int i = 0; i < discardAmount;)
                {
                    int count;
                    if (i+5 < discardAmount) 
                    {
                        count = 5;
                    }
                    else 
                    {
                        count = discardAmount - i;
                    }
                    var spawnLocation = localInventory.transform.position + Random.onUnitSphere * 3f;
                    spawnLocation.y = 3f;
                    PickupSpawner.instance.SpawnPickup(discardItem, count, spawnLocation, localInventory.transform.rotation);
                    i += count;
                }
            }
        }

        public void SetDiscardValue(float value) 
        {
            SetDiscardValue(Mathf.RoundToInt(value));
        }
        public void SetDiscardValue(int value) 
        {
            discardAmount = value;
            discardAmountText.text = discardAmount.ToString();
            int discardWeight = discardAmount * (int)discardItem.weight;
            int newWeight =(int)(localInventory.currentWeight - discardWeight);
            freeWeightText.text = $"Weight after Discard : {newWeight}";
            discardWeightText.text = $"Freed Weight : {discardWeight}";
        }
    }
}