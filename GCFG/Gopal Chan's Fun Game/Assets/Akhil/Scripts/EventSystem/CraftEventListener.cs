using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [System.Serializable]
    public class CraftEventHandler :UnityEvent<CraftRecipe>
    {
    }
    public class CraftEventListener : MonoBehaviour, IListener
    {
        [SerializeField]
        private CraftEvent craftEvent = null;
        [SerializeField]
        private CraftEventHandler onCraftEvent = null;


        private void OnEnable()
        {
            craftEvent?.RegisterListener(this);
        }

        public void OnEventRaised(params object[] parameters)
        {
            if(parameters.Length == 0) 
            {
                onCraftEvent?.Invoke(null);
            }
            else 
            {
                onCraftEvent?.Invoke(parameters[0] as CraftRecipe);
            }
        }
        private void OnDisable()
        {
            craftEvent?.UnRegisterListener(this);
        }
    }
}