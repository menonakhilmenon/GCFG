using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHUDText : MonoBehaviour
{
    [SerializeField]
    private ScriptableGameEvent hudTextEvent = null;
    public void SetHudText(string text) 
    {
        hudTextEvent?.Invoke(text);
    }
}
