using bilalAdarsh;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [System.Serializable]
    public class CraftRequirement
    {
        [SerializeReference]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2235:Mark all non-serializable fields", Justification = "Serialized as Reference")]
        public Item item = null;
        public int amount = 1;
    }



    [CreateAssetMenu]
    public class CraftRecipe : ScriptableObject
    {
        public Item result = null;
        public int resultAmount = 1;
        [ReorderableList]
        [SerializeField]
        private List<CraftRequirement> craftRequirements = new List<CraftRequirement>();
        public List<CraftRequirement> CraftRequirements => craftRequirements;


        public Dictionary<Item, int> GetRequirementsAsDictionary
        { 
            get 
            {
                var result = new Dictionary<Item, int>();
                foreach (var item in craftRequirements)
                {
                    result.Add(item.item, item.amount);
                }
                return result;
            }
        }
    }
}