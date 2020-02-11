using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [CreateAssetMenu(menuName ="Events/FloatEvent")]
    public class FloatEvent : ScriptableGameEvent
    {
        public void InvokeWithFloat(float val) 
        {
            Invoke(val);
        }
    }
}