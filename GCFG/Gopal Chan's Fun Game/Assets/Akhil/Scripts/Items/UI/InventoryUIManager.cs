using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using bilalAdarsh;
using NaughtyAttributes;

namespace GCFG
{
    public class InventoryUIManager : MonoBehaviour
    {

        [SerializeField]
        private ScriptableGameEvent itemSelectEvent = null;

        [BoxGroup("Populating Inventory")]
        [SerializeField]
        private TMP_Text weightText = null;
        [BoxGroup("Populating Inventory")]
        [SerializeField]
        private Slider weightSlider = null;
        [BoxGroup("Populating Inventory")]
        [SerializeField]
        private GameObject inventoryDisplayRoot = null;
        [BoxGroup("Populating Inventory")]
        [SerializeField]
        private InventoryUIItem inventoryUIItemPrefab = null;


        [BoxGroup("Opening and Closing")]
        [SerializeField]
        private ScriptableGameEvent gamePauseEvent = null;
        [BoxGroup("Opening and Closing")]
        [SerializeField]
        private ScriptableGameEvent gameResumeEvent = null;
        [BoxGroup("Opening and Closing")]
        [SerializeField]
        private GameObject inventoryObject = null;
        private Inventory localInventory => PlayerManager.instance.LocalPlayerInventory;
        private Dictionary<Item, InventoryUIItem> inventoryUIItems = new Dictionary<Item, InventoryUIItem>();

        private bool isActive => inventoryObject.activeSelf;


        public void SetInventoryData() 
        {
            weightSlider.minValue = 0f;
            weightSlider.maxValue = localInventory.maxWeight;
            weightText.text = $"Weight : {localInventory.currentWeight} / {localInventory.maxWeight} kg";
            weightSlider.value = localInventory.currentWeight;
            foreach (var item in localInventory.GetInventory())
            {
                GetInventoryItem(item.Key);
            }
            foreach (var item in inventoryUIItems)
            {
                item.Value.SetItemData(item.Key, localInventory.GetItemCount(item.Key));
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
        public void ToggleInventory() 
        {
            if (!isActive) 
            {
                inventoryObject.SetActive(true);
                ResetSelection();
                gamePauseEvent?.Invoke();
            }
            else 
            {
                inventoryObject.SetActive(false);
                gameResumeEvent?.Invoke();
            }
        }
        public void TurnInventoryOff() 
        {
            inventoryObject.SetActive(false);
        }
        public void ResetSelection() 
        {
            itemSelectEvent?.Invoke();
        }
    }
}