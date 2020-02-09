using bilalAdarsh;
using NaughtyAttributes;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [Serializable]
    public class RepairItem 
    {
        [SerializeReference]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2235:Mark all non-serializable fields", Justification = "Serialized as Reference")]
        public Item resource = null;
        [Tooltip("Amount of progression obtained for unit resource")]
        public float weight = 1f;
        public string name => resource.name;
    }

    public class Repairable : MonoBehaviour
    {
        [SerializeField]
        private FloatEvent onRepair = null;

        [ReorderableList]
        public List<RepairItem> repairItems = new List<RepairItem>();


        //[BoxGroup("Gold")]
        //[SerializeField]
        //private float goldWeight = 5f;
        //[BoxGroup("Gold")]
        //[SerializeField]
        //private Resource goldResource;

        //[BoxGroup("Stone")]
        //[SerializeField]
        //private float stoneWeight = 3f;
        //[SerializeField]
        //[BoxGroup("Stone")]
        //private Resource stoneResource = null;

        //[BoxGroup("Wood")]
        //[SerializeField]
        //private float woodWeight = 1f;
        //[SerializeField]
        //[BoxGroup("Wood")]
        //private Resource woodResource;



        public float TryRepair(Dictionary<Item, int> materials)
        {
            var progression = 0f;
            foreach (var item in materials)
            {
                //if (item.Key == goldResource)
                //{
                //    progression += goldWeight * item.Value;
                //}
                //else if (item.Key == stoneResource)
                //{
                //    progression += stoneWeight * item.Value;
                //}
                //else if (item.Key == woodResource)
                //{
                //    progression += woodWeight * item.Value;
                //}
                progression += TryRepair(item.Key, item.Value);
            }
            //onRepair?.Invoke(progression);
            return progression;
        }
        public float Repair(Dictionary<Item,int> materials) 
        {
            var progression = TryRepair(materials);
            onRepair?.Invoke(progression);
            return progression;
        }



        public float TryRepair(Item item, int amount) 
        {
            var progression = 0f;
            foreach (var requirementItem in repairItems)
            {
                if(requirementItem.resource == item) 
                {
                    progression += requirementItem.weight * amount;
                }
            }
            return progression;
        }

    }

}
