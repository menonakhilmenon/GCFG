using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class NetworkSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerGameObject = null;
        [SerializeField]
        private Transform[] spawnPoints = null;
        // Start is called before the first frame update
        void Start()
        {
            Launcher.OnRoomFullCallback += SpawnPlayer;
        }

        private void SpawnPlayer()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (var player in PhotonNetwork.PlayerList)
                {
                    var pos = spawnPoints[player.ActorNumber % spawnPoints.Length];
                    var obj = PhotonNetwork.Instantiate(playerGameObject.name, pos.position, pos.rotation);
                    obj.GetComponent<PhotonView>().TransferOwnership(player);
                }
            }
        }
    }
}