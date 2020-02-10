using bilalAdarsh;
using NaughtyAttributes;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using GCFG;

namespace Gopal
{
    [Serializable]
    public class RepairItemReq 
    {
        [SerializeReference]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2235:Mark all non-serializable fields", Justification = "Serialized as Reference")]
        public Item resource = null;
        [Tooltip("Amount of progression obtained for unit resource")]
        public float weight = 1f;
    }
    [RequireComponent(typeof(PhotonView),typeof(Health))]
    public class Repairable : MonoBehaviourPun
    {
        [SerializeField]
        private FloatEventHandler onRepair = null;

        [ReorderableList]
        public List<RepairItemReq> repairItems = new List<RepairItemReq>();

        public float MaxProgression => health.MaxHealth;

        public float currentProgression 
        {
            get => health.currentHealth;
            set => health.currentHealth = value; 
        }

        private Health health = null;

        private void Awake()
        {
            health = GetComponent<Health>();
        }


        public float TryRepair(Dictionary<Item, int> materials)
        {
            var progression = 0f;
            foreach (var item in materials)
            {
                progression += TryRepair(item.Key, item.Value);
            }
            return progression;
        }


        public void Repair(Dictionary<Item,int> materials) 
        {
            var progression = TryRepair(materials);
            photonView.RPC(nameof(RepairRPC), RpcTarget.AllBufferedViaServer, progression);
        }


        [PunRPC]
        private void RepairRPC(float progression) 
        {
            onRepair?.Invoke(progression);
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
