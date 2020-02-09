using bilalAdarsh;
using Gopal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GCFG
{
    public class RepairManager : MonoBehaviour
    {
        [SerializeField]
        private RepairItem repairItemPrefab = null;
        [SerializeField]
        private Transform repairItemRoot = null;

        [SerializeField]
        private Slider progressionSlider = null;

        [SerializeField]
        private TMPro.TMP_Text progressionText = null;


        private Dictionary<Item, RepairItem> repairItems = new Dictionary<Item, RepairItem>();

        private Repairable currentRepairable = null;
        private Inventory localInventory => PlayerManager.instance.LocalPlayerInventory;



        public void SetProgressionData() 
        {
            progressionSlider.minValue = 0;
            progressionSlider.maxValue = currentRepairable.MaxProgression;
            var targetProgression = Mathf.Clamp(
                currentRepairable.currentProgression + GetRepairValue(),
                currentRepairable.currentProgression,
                currentRepairable.MaxProgression);
            progressionSlider.value = targetProgression;

            progressionText.text = $"Progression : {targetProgression} / {currentRepairable.MaxProgression}";
        }

        private float GetRepairValue() 
        {
            float result = 0f;
            foreach (var item in repairItems.Values)
            {
                result += item.weight * item.repairAmount;
            }
            return result;
        }

        public void Repair() 
        {
            if (currentRepairable == null) 
            {
                return;
            }
            var inventoryDict = new Dictionary<Item, int>();
            foreach (var item in repairItems)
            {
                if(item.Value.weight > 0f && item.Value.repairAmount >0) 
                {
                    inventoryDict.Add(item.Key, item.Value.repairAmount);
                }
            }
            if (localInventory.TryRemoveItems(inventoryDict)) 
            {
                currentRepairable.Repair(inventoryDict);
                localInventory.RemoveItems(inventoryDict);
            }
        }

        
        public void SetRepairItems(Repairable repairable) 
        {
            currentRepairable = repairable;
            ResetItems();
            if (repairable == null)
            {
                return;
            }
            foreach (var item in repairable.repairItems)
            {
                var rep = GetRepairItem(item.resource);
                rep.weight = item.weight;
                rep.ResetItem();
            }
            SetProgressionData();
        }

        public void RepairableUpdate(Repairable repairable) 
        {
            if (repairable != currentRepairable) 
            {
                return;
            }
            SetProgressionData();
        }

        public void ResetRepairItems() 
        {
            if (currentRepairable != null) 
            {
                SetRepairItems(currentRepairable);
            }
        }

        public void ResetItems() 
        {
            foreach (var item in repairItems.Values)
            {
                item.weight = 0f;
                item.ResetItem();
            }
        }
        private RepairItem GetRepairItem(Item item) 
        {
            RepairItem result;
            if (!repairItems.ContainsKey(item)) 
            {
                result = Instantiate(repairItemPrefab, repairItemRoot);
                result.SetItem(item);
                repairItems.Add(item, result);
            }
            else 
            {
                result = repairItems[item];
            }

            return result;
        }
        
    }
}