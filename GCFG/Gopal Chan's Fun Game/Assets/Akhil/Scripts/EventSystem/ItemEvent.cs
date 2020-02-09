using bilalAdarsh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG 
{
    [CreateAssetMenu(menuName = "Events/ItemEvent")]
    public class ItemEvent : ScriptableGameEvent
    {
        public void InvokeWithItem(Item item) 
        {
            if(item == null) 
            {
                Invoke();
            }
            else 
            {
                Invoke(item);
            }
        }
    }
}