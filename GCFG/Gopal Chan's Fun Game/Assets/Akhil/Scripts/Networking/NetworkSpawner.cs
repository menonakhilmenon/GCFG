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
        private GameObject towerGameObject = null;


        [SerializeField]
        private Transform[] playerSpawnPoints = null;
        [SerializeField]
        private Transform[] towerSpawnPoints = null;


        public void SpawnPlayer()
        {
            if (!PhotonNetwork.IsMasterClient)
                return;
            GetComponent<PhotonView>().RPC(nameof(SpawnRPC), RpcTarget.AllBuffered);
        }

        [PunRPC]
        private void SpawnRPC()
        {
            var player = PhotonNetwork.LocalPlayer;
            var index = player.ActorNumber % playerSpawnPoints.Length;
            var playerPos = playerSpawnPoints[index];
            var towerPos = towerSpawnPoints[index];


            PhotonNetwork.Instantiate(playerGameObject.name, playerPos.position, playerPos.rotation);
            PhotonNetwork.Instantiate(towerGameObject.name, towerPos.position, towerPos.rotation);
        }
    }
}