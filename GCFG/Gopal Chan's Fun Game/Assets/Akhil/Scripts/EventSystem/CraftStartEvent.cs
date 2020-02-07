using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG 
{
    [CreateAssetMenu(menuName = "Events/CraftStartEvent")]
    public class CraftStartEvent : ScriptableGameEvent
    {
        public void InvokeWithCraftTable(CraftTable craftTable) 
        {
            Invoke(craftTable);
        }
    }
}