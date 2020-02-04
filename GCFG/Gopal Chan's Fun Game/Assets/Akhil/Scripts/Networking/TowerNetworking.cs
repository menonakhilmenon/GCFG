using Gopal;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView),typeof(Tower))]
public class TowerNetworking : MonoBehaviourPun
{
    private Tower tower;

    private void Awake()
    {
        tower = GetComponent<Tower>();
    }
    private void Start()
    {
        if (photonView.IsMine)
        {
            PlayerManager.instance.LocalTower = tower;
            photonView.RPC(nameof(RegisterTower), RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void RegisterTower() 
    {
        PlayerManager.instance.RegisterPlayerTower(photonView.Owner, tower);
    }
}
