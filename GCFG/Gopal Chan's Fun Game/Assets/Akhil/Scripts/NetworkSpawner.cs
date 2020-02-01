using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG {
    public class NetworkSpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Launcher.OnRoomJoinedCallback += SpawnPlayer;
        }

        private void SpawnPlayer()
        {
            Debug.Log("Connected to room spawning local player..");
        }
    }
}