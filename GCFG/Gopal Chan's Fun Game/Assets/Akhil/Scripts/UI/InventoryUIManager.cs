using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using bilalAdarsh;

namespace GCFG
{
    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text weightText = null;
        [SerializeField]
        private Slider weightSlider = null;
        [SerializeField]
        private GameObject inventoryDisplayRoot = null;

        [SerializeField]
        private InventoryUIItem inventoryUIItemPrefab = null;

        private Inventory localInventory => PlayerManager.instance.LocalPlayerInventory;

        private Dictionary<Item, InventoryUIItem> inventoryUIItems = new Dictionary<Item, InventoryUIItem>();
        
        
        private void OnEnable()
        {
            weightSlider.minValue = 0f;
            weightSlider.maxValue = localInventory.maxWeight;
            SetInventoryData();
        }


        public void SetInventoryData() 
        {
            weightText.text = $"Weight : {localInventory.currentWeight} / {localInventory.maxWeight} kg";
            weightSlider.value = localInventory.currentWeight;
            foreach (var item in localInventory.GetInventory())
            {
                GetInventoryItem(item.Key).SetItemData(item.Key, item.Value);
            }
        }


        private InventoryUIItem GetInventoryItem(Item item) 
        {
            InventoryUIItem result = null;
            if (!inventoryUIItems.ContainsKey(item))
            {
                result = Instantiate(inventoryUIItemPrefab, inventoryDisplayRoot.transform);
                inventoryUIItems.Add(item, result);
                return result;
            }
            return inventoryUIItems[item];
        }
    }
}