using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GCFG
{
    public class Launcher : MonoBehaviourPunCallbacks
    {

        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 2;

        public static Action OnRoomJoinedCallback;
        public static Action OnRoomFullCallback;

        string gameVersion = "1";



        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }


        #region Public Methods


        /// <summary>
        /// Start the connection process.
        /// - If already connected, we attempt joining a random room
        /// - if not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        public void Connect()
        {
            NetworkLogger.Log("Waiting for Connection");
            // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }


        public override void OnConnectedToMaster()
        {
            NetworkLogger.Log("Connected to Master");
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            NetworkLogger.Log("Random Join Failed Creating Room");
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {

            if(PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersPerRoom)
            {
                OnRoomFullCallback?.Invoke();
            }
            else
            {
                NetworkLogger.Log("Joined Room waiting for Room to fill");
                Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
            }
            OnRoomJoinedCallback?.Invoke();
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersPerRoom)
            {
                OnRoomFullCallback?.Invoke();
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            NetworkLogger.Log("Disconnected due to cause " + cause);
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }



        #endregion
        
    }
}
