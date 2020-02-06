using Gopal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [System.Serializable]
    public class RepairEventHandler : UnityEvent<Repairable> 
    {
    }

    public class RepairEventListener : MonoBehaviour, IListener
    {
        [SerializeField]
        private RepairEvent repairEvent = null;
        [SerializeField]
        private RepairEventHandler onRepairEvent = null;

        private void OnEnable()
        {
            repairEvent?.RegisterListener(this);
        }

        public void OnEventRaised(params object[] parameters)
        {
            if(parameters.Length == 0) 
            {
                onRepairEvent?.Invoke(null);
            }
            else 
            {
                onRepairEvent?.Invoke(parameters[0] as Repairable);
            }
        }
        private void OnDisable()
        {
            repairEvent?.UnRegisterListener(this);
        }
    }
}