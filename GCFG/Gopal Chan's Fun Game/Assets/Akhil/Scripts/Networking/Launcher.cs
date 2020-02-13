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


        private bool connectToRandomRoom = true;
        private bool exposeRoom = true;


        public string roomID { get; set; }


        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }


        #region Public Methods



        public void ConnectToRoom() 
        {
            exposeRoom = false;
            Connect();
        }
        public void JoinRoom(string roomID) 
        {
            connectToRandomRoom = false;
            Connect();
        }


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
                if (connectToRandomRoom) 
                {
                    PhotonNetwork.JoinRandomRoom();
                }
                else 
                {
                    PhotonNetwork.JoinRoom(roomID);
                }
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.ConnectUsingSettings();
            }
        }



        public override void OnConnectedToMaster()
        {
            NetworkLogger.Log("Connected to Master");
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            if (connectToRandomRoom) 
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else 
            {
                PhotonNetwork.JoinRoom(roomID);
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            NetworkLogger.Log("Random Join Failed Creating Room");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            if (exposeRoom) 
            {
                PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
            }
            else 
            {
                PhotonNetwork.CreateRoom("Test", new RoomOptions { IsVisible = false, MaxPlayers = maxPlayersPerRoom });
            }
        }

        public override void OnJoinedRoom()
        {

            if(PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersPerRoom)
            {
                OnRoomFullCallback?.Invoke();
                Debug.Log("Room full!");
            }
            else
            {
                NetworkLogger.Log($"Room ID : {PhotonNetwork.CurrentRoom.Name}");
                Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
            }

            OnRoomJoinedCallback?.Invoke();
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("Player entered room " + newPlayer.NickName);
            if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersPerRoom)
            {
                OnRoomFullCallback?.Invoke();
                Debug.Log("Room full!");
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            NetworkLogger.Log("Disconnected due to cause " + cause);
            Debug.LogWarning($"PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {cause}");
        }



        #endregion
        
    }
}
