using NaughtyAttributes;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [RequireComponent(typeof(PhotonView))]
    public class DeleteIfNotMine : MonoBehaviourPun
    {
        [ReorderableList]
        [SerializeField]
        private List<Object> deleteIfNotMine = new List<Object>();


        private void Start()
        {
            DeleteComponents();
            Destroy(this);
        }
        private void DeleteComponents()
        {
            if (!photonView.IsMine) 
            {
                foreach (var item in deleteIfNotMine)
                {
                    Destroy(item);
                }
                deleteIfNotMine.Clear();
            }
        }
    }
}