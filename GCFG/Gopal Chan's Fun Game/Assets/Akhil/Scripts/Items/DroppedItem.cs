using bilalAdarsh;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [RequireComponent(typeof(PhotonView))]
    public class DroppedItem : MonoBehaviourPun
    {
        [SerializeField]
        private Item itemType = null;
        [SerializeField]
        private int _count = 1;
        public int Count { get => _count; set => _count = value; }

        public void NetworkPickUp() 
        {
            if (PlayerManager.instance.LocalPlayerInventory.TryAdd(itemType, Count)) 
            {
                photonView.RPC(nameof(ItemPickUpRPC), RpcTarget.AllBufferedViaServer, PhotonNetwork.LocalPlayer.ActorNumber);
            }
        }

        [PunRPC]
        private void ItemPickUpRPC(int playerID) 
        {
            if(playerID == PhotonNetwork.LocalPlayer.ActorNumber) 
            {
                for (int i = 0; i < Count; i++)
                {
                    PlayerManager.instance.LocalPlayerInventory.AddItem(itemType);
                }
            }
            if (PhotonNetwork.IsMasterClient) 
            {
                PhotonNetwork.Destroy(photonView);
            }
        }

    }
}