using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [CreateAssetMenu(menuName ="Events/StringEvent")]
    public class StringEvent : ScriptableGameEvent
    {
        public void InvokeWithString(string parameter) 
        {
            Invoke(parameter);
        }
    }
}