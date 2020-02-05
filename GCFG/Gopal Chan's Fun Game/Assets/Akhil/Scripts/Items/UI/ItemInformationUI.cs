using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using bilalAdarsh;

namespace GCFG
{
    public class ItemInformationUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameText = null;
        [SerializeField]
        private TMP_Text descriptionText = null;
        [SerializeField]
        private RawImage imageSprite = null;

        public void SetUIData(Item dataItem)
        {
            if(dataItem == null) 
            {
                nameText.text = "";
                descriptionText.text = "No item Selected";
                imageSprite.enabled = false;
                return;
            }
            imageSprite.enabled = true;
            nameText.text = dataItem.name;
            descriptionText.text = dataItem.UIDescription;
            imageSprite.texture = dataItem.uiSprite;
        }
    }
}