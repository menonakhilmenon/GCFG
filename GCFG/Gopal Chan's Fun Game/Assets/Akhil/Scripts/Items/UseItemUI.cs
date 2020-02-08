using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GCFG
{
    public class UseItemUI : MonoBehaviour
    {
        [SerializeField]
        private Button useItemButton = null;

        private Item currentItem = null;
        public void UseItem()
        {
            currentItem.UseItem();
        }
        public void ItemSelectedCallback(Item item)
        {
            currentItem = item;
            if (item != null && item.IsUsable)
            {
                useItemButton.interactable = true;
            }
            else 
            {
                useItemButton.interactable = false;
            }
        }
    }
}