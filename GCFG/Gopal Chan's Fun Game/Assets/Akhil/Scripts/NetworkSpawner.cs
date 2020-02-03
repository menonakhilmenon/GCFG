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
            var pos = spawnPoints[player.ActorNumber % spawnPoints.Length];
            PhotonNetwork.Instantiate(playerGameObject.name, pos.position, pos.rotation);
        }
    }
}