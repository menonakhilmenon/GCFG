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
        tower.TowerProgressionUpdate += UpdateTowerHealth;
    }
    private void Start()
    {

        if (photonView.IsMine)
        {
            PlayerManager.instance.LocalTower = tower;
            photonView.RPC(nameof(RegisterTower), RpcTarget.AllBuffered);
        }
    }

    private void UpdateTowerHealth(float value)
    {
        if (photonView.Owner.IsMasterClient) 
        {
            photonView.RPC(nameof(UpdateTowerHealthRPC), RpcTarget.AllBuffered, value);
        }
    }

    [PunRPC]
    private void UpdateTowerHealthRPC(float value) 
    {
        if(PlayerManager.instance.LocalTower == tower) 
        {
            return;
        }
        tower.Progression = value;
    }

    [PunRPC]
    private void RegisterTower() 
    {
        PlayerManager.instance.RegisterPlayerTower(photonView.Owner, tower);
    }
}
