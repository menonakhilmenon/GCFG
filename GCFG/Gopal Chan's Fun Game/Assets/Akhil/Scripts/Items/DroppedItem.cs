using bilalAdarsh;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [RequireComponent(typeof(PhotonView))]
    public class DroppedItem : MonoBehaviourPun,IPunObservable
    {
        [SerializeField]
        private Item itemType = null;
        [SerializeField]
        private int _count = 1;
        public int Count { get => _count; set => _count = value; }

        private int lastSentCount = 1;

        public void NetworkPickUp() 
        {
            if (PlayerManager.instance.LocalPlayerInventory.TryAdd(itemType, Count)) 
            {
                photonView.RPC(nameof(ItemPickUpRPC), RpcTarget.AllBufferedViaServer, PhotonNetwork.LocalPlayer.ActorNumber);
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsReading) 
            {
                var newCount = (int)stream.ReceiveNext();
                Count = newCount;
            }
            else 
            {
                if(lastSentCount!= Count) 
                {
                    lastSentCount = Count;
                    stream.SendNext(Count);
                }
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