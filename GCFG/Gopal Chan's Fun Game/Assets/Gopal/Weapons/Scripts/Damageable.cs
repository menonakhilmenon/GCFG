using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gopal
{
    [Serializable]
    public class DamageEvent : UnityEvent<float> 
    {
        
    }

    [RequireComponent(typeof(PhotonView))]
    public class Damageable : MonoBehaviourPun
    {
        public DamageEvent OnTakeDamage = null;

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
            OnTakeDamage?.Invoke(damage);
        }
    }
}
