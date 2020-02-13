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
        private GameObject craftTablePrefab = null;

        [SerializeField]
        private Transform[] playerSpawnPoints = null;
        [SerializeField]
        private Transform[] towerSpawnPoints = null;
        [SerializeField]
        private Transform[] craftTableSpawnPoints = null;



        public void SpawnPlayer()
        {
            var player = PhotonNetwork.LocalPlayer;
            var index = player.ActorNumber % playerSpawnPoints.Length;
            var playerPos = playerSpawnPoints[index];
            var towerPos = towerSpawnPoints[index];
            var craftTablePos = craftTableSpawnPoints[index];

            PhotonNetwork.Instantiate(playerGameObject.name, playerPos.position, playerPos.rotation);
            PhotonNetwork.Instantiate(towerGameObject.name, towerPos.position, towerPos.rotation);
            PhotonNetwork.Instantiate(craftTablePrefab.name, craftTablePos.position, craftTablePos.rotation);
        }
    }
}