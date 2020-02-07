using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [System.Serializable]
    public class CraftStartCallback : UnityEvent<CraftTable> 
    {
    }
    public class CraftStartListener : MonoBehaviour,IListener
    {
        [SerializeField]
        private CraftStartEvent craftStartEvent = null;
        [SerializeField]
        private CraftStartCallback onCraftStart = null;

        private void OnEnable()
        {
            craftStartEvent?.RegisterListener(this);
        }

        public void OnEventRaised(params object[] parameters)
        {
            if(parameters.Length == 0) 
            {
                onCraftStart?.Invoke(null);
            }
            else 
            {
                onCraftStart?.Invoke(parameters[0] as CraftTable);
            }
        }
        private void OnDisable()
        {
            craftStartEvent?.UnRegisterListener(this);
        }
    }
}