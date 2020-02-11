using GCFG;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gopal
{
    
    [RequireComponent(typeof(PhotonView))]
    public class Damageable : MonoBehaviourPun
    {
        [SerializeField]
        private float _damageFactor = 1f;

        public float damageFactor { get => _damageFactor; set => _damageFactor = value; }

        public FloatEventHandler OnTakeDamage = null;

        public void TakeDamage(float damage) 
        {
            photonView.RPC(nameof(TakeDamageRequest), RpcTarget.MasterClient, damage);
        }
        [PunRPC]
        private void TakeDamageRequest(float damage) 
        {
            if (PhotonNetwork.IsMasterClient) 
            {
                photonView.RPC(nameof(TakeDamageRPC), RpcTarget.AllBuffered, damage);
            }
        }
        [PunRPC]
        private void TakeDamageRPC(float damage) 
        {
            if(damage > 0f) 
            {
                damage *= damageFactor;
            }

            OnTakeDamage?.Invoke(-damage);
        }

        public void RecoverHealth(float health) 
        {
            TakeDamage(-health);
        }
    }
}
