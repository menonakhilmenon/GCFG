using Gopal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [CreateAssetMenu]
    public class RepairEvent : ScriptableGameEvent
    {
        public void InvokeWithRepairable(Repairable repairable)
        {
            Invoke(repairable);
        }
    }
}