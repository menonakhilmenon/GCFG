using GCFG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class SetItemDropString : MonoBehaviour
{
    [SerializeField]
    private DroppedItem droppedItem = null;
    private void OnEnable()
    {
        GetComponent<TMPro.TMP_Text>().text = droppedItem.GetDisplayText();
    }
}
