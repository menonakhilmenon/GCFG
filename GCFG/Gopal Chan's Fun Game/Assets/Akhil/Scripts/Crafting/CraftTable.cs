using bilalAdarsh;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class CraftTable : MonoBehaviour
    {
        [SerializeField]
        [ReorderableList]
        private List<CraftRecipe> craftRecipes = null;
        public List<CraftRecipe> CraftRecipes => craftRecipes;

        private Inventory localInventory => PlayerManager.instance.LocalPlayerInventory;

        public bool TryCraft(CraftRecipe recipe) 
        {
            if (!craftRecipes.Contains(recipe)) 
            {
                return false;
            }
            if (localInventory.TryRemoveItems(recipe.GetRequirementsAsDictionary)) 
            {
                return true;
            }
            return false;
        }
        public void Craft(CraftRecipe recipe)
        {
            if (localInventory.RemoveItems(recipe.GetRequirementsAsDictionary)) 
            {
                if (!localInventory.AddItem(recipe.result,recipe.resultAmount)) 
                {
                    localInventory.DropItem(recipe.result, recipe.resultAmount);
                }
            }
        }
    }
}