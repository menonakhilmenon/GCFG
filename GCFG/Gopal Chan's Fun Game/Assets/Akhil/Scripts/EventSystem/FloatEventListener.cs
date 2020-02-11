using Gopal;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [Serializable]
    public class FloatEventHandler : UnityEvent<float>
    {
    }
    public class FloatEventListener : MonoBehaviour,IListener
    {
        [SerializeField]
        private FloatEventHandler onEventCallback = null;
        [SerializeField]
        private FloatEvent floatEvent = null;

        private void OnEnable()
        {
            floatEvent?.RegisterListener(this);
        }
        public void OnEventRaised(params object[] parameters)
        {
            onEventCallback?.Invoke((float)parameters[0]);
        }
        private void OnDisable()
        {
            floatEvent?.UnRegisterListener(this);
        }
    }
}