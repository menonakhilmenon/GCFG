using bilalAdarsh;
using GCFG;
using NaughtyAttributes;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class PickupSpawner : MonoBehaviourPun
{
    [SerializeField]
    private PhotonObjects photonObjects = null;

    [Button("Spawn Shit")]
    public void SpawnAtOrigin() 
    {
        SpawnPickup(photonObjects.GetObject(0) as Item, 4, transform.position + Vector3.up * 1f, transform.rotation);
    }

    public void SpawnPickup(Item  itemType, int count,Vector3 position,Quaternion rotation) 
    {
        photonView.RPC(nameof(SpawnPickupRPC), RpcTarget.All, photonObjects.GetIndex(itemType), count, position, rotation);
    }

    [PunRPC]
    private void SpawnPickupRPC(int itemIndex,int count,Vector3 position,Quaternion rotation) 
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        var item = photonObjects.GetObject(itemIndex) as Item;
        if (item != null) 
        {
            var obj = PhotonNetwork.Instantiate(item.dropModel.name, position, rotation);
            obj.GetComponent<DroppedItem>().Count = count;
        }
    }
}
