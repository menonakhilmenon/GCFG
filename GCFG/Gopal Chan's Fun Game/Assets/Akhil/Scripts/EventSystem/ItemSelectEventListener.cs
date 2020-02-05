using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [System.Serializable]
    public class ItemEvent : UnityEvent<Item> 
    {
    
    }
    public class ItemSelectEventListener : MonoBehaviour, IListener
    {

        public void OnEventRaised(params object[] parameters)
        {
            var item = parameters[0] as Item;
        }
    }
}