using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace GCFG
{
    public class InventoryUIItem : MonoBehaviour
    {
        [SerializeField]
        private RawImage image = null;
        [SerializeField]
        private TMPro.TMP_Text countText = null;
        [SerializeField]
        private ScriptableGameEvent selectItemEvent = null;

        [SerializeField]
        private UnityEvent onSelectedCallback = null;
        [SerializeField]
        private UnityEvent onDeSelectedCallback = null;


        private Item item = null;

        private bool selected = false;

        public void SelectItem() 
        {
            if (item != null) 
            {
                selectItemEvent?.Invoke(item);
            }
        }

        public void ChangeSelection(Item item) 
        {
            if(item == this.item) 
            {
                onSelectedCallback?.Invoke();
            }
            if (selected && item != this.item)
            {
                onDeSelectedCallback?.Invoke();
            }
        }


        public void SetItemData(Item item,int count)
        {
            this.item = item;
            if(count == 0) 
            {
                gameObject.SetActive(false);
                return;
            }

            else 
            {
                gameObject.SetActive(true);
                if(count == 1) 
                {
                    countText.text = "";
                }
                else 
                {
                    countText.text = $"x{count}";
                }
            }
            image.texture = item.uiSprite;
        }
    }
}
