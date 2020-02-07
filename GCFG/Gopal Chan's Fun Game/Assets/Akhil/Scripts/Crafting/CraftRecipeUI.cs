using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace GCFG
{
    public class CraftRecipeUI : MonoBehaviour
    {
        [SerializeField]
        private ItemEvent itemSelectEvent = null;
        [SerializeField]
        private CraftEvent craftSelectEvent = null;

        [SerializeField]
        private UnityEvent onSelectCallback = null;
        [SerializeField]
        private UnityEvent onDeSelectCallback = null;


        [SerializeField]
        private Transform craftRequirementRoot = null;
        [SerializeField]
        private InventoryUIItem craftRequirementItemPrefab = null;
        [SerializeField]
        private RawImage resultImage = null;
        [SerializeField]
        private TMPro.TMP_Text resultCount = null;

        private Dictionary<Item, InventoryUIItem> requirements = new Dictionary<Item, InventoryUIItem>();

        private CraftRecipe recipe = null;


        private bool selected = false;

        public void SetRecipe(CraftRecipe craftRecipe) 
        {
            recipe = craftRecipe;
            resultImage.texture = craftRecipe.result.uiSprite;
            var count = craftRecipe.resultAmount;
            if(count == 1) 
            {
                resultCount.gameObject.SetActive(false);
            }
            else 
            {
                resultCount.gameObject.SetActive(true);
                resultCount.text = $"x {count}";
            }


            foreach (var item in craftRecipe.CraftRequirements)
            {
                var res = GetUIItem(item.item);
                res.SetItemData(item.item, item.amount);
            }
        }

        public void SelectRecipe() 
        {
            craftSelectEvent?.InvokeWithCraftRecipe(recipe);
            onSelectCallback?.Invoke();
            selected = true;
            itemSelectEvent?.InvokeWithItem(recipe.result);
        }

        public void ReciveSelectionCallback(CraftRecipe recipe) 
        {
            if(recipe == this.recipe) 
            {
                return;
            }
            if (selected) 
            {
                selected = false;
                onDeSelectCallback?.Invoke();
            }
        }

        private InventoryUIItem GetUIItem(Item item)
        {
            if (!requirements.ContainsKey(item))
            {
                var result = Instantiate(craftRequirementItemPrefab, craftRequirementRoot);
                requirements.Add(item, result);
                return result;
            }
            return requirements[item];
        }
    }
}