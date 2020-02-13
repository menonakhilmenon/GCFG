using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [System.Serializable]
    public class PlayerEventCallback : UnityEvent<Player> 
    {
    }

    public class PlayerEventListener : MonoBehaviour,IListener
    {
        [SerializeField]
        private PlayerEvent playerEvent = null;

        [SerializeField]
        private PlayerEventCallback onEventRaised = null;

        private void OnEnable()
        {
            playerEvent?.RegisterListener(this);
        }
        public void OnEventRaised(params object[] parameters)
        {
            if(parameters.Length != 0) 
            {
                onEventRaised?.Invoke(parameters[0] as Player);
            }
            else 
            {
                onEventRaised?.Invoke(null);
            }
        }
        private void OnDisable()
        {
            playerEvent?.UnRegisterListener(this);
        }
    }
}