using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GCFG 
{
    public class CraftManager : MonoBehaviour
    {
        [SerializeField]
        private Transform craftRecipeRoot = null;
        [SerializeField]
        private CraftRecipeUI craftRecipePrefab = null;
        [SerializeField]
        private Button craftButton = null;
        [SerializeField]
        private CraftEvent craftSelectEvent = null;


        private Dictionary<CraftRecipe, CraftRecipeUI> craftRecipes = new Dictionary<CraftRecipe, CraftRecipeUI>();

        private CraftRecipe currentCraftRecipe = null;
        private CraftTable currentCraftTable = null;

        public void StartCrafting(CraftTable craftTable) 
        {
            currentCraftTable = craftTable;

            if (currentCraftRecipe != null)
            {
                craftSelectEvent?.InvokeWithCraftRecipe(null);
                SelectCraftRecipe(null);
            }
            craftButton.interactable = false;
            currentCraftRecipe = null;
            RefreshCrafting();

        }

        public void SelectCraftRecipe(CraftRecipe recipe) 
        {
            currentCraftRecipe = recipe;
            if(recipe == null) 
            {
                return;
            }
            UpdateSelection();
        }


        private void UpdateSelection() 
        {
            if (currentCraftRecipe!=null && currentCraftTable.TryCraft(currentCraftRecipe))
            {
                craftButton.interactable = true;
            }
            else
            {
                craftButton.interactable = false;
            }
        }

        public void Craft() 
        {
            currentCraftTable.Craft(currentCraftRecipe);
        }


        private CraftRecipeUI GetCraftRecipe(CraftRecipe recipe) 
        {
            if (!craftRecipes.ContainsKey(recipe)) 
            {
                var result = Instantiate(craftRecipePrefab, craftRecipeRoot);
                craftRecipes.Add(recipe, result);
                result.SetRecipe(recipe);
                return result;
            }
            return craftRecipes[recipe];
        }

        public void RefreshCrafting() 
        {
            UpdateSelection();
            foreach (var item in craftRecipes)
            {
                item.Value.gameObject.SetActive(false);
            }


            if (currentCraftTable != null)
            {
                foreach (var item in currentCraftTable.CraftRecipes)
                {
                    GetCraftRecipe(item).gameObject.SetActive(true);
                }
            }
        }
    }
}