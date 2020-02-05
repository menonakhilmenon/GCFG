﻿using bilalAdarsh;
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
        [SerializeField]
        private ScriptableGameEvent itemSelectEvent = null;
        [SerializeField]
        private ItemEvent itemEventCallback = null;


        public void OnEnable()
        {
            itemSelectEvent?.RegisterListener(this);
        }

        public void OnEventRaised(params object[] parameters)
        {
            var item = parameters[0] as Item;
            itemEventCallback?.Invoke(item);
        }
        private void OnDisable()
        {
            itemSelectEvent?.UnRegisterListener(this);
        }
    }
}