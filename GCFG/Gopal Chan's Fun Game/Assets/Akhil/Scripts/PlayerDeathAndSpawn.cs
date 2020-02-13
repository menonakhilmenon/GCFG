using bilalAdarsh;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    [RequireComponent(typeof(PhotonView))]
    [RequireComponent(typeof(Health))]
    public class PlayerDeathAndSpawn : MonoBehaviourPun
    {
        [SerializeField]
        private UnityEvent onDeathCallback = null;
        [SerializeField]
        private UnityEvent onRespawnCallback = null;

        private Health health = null;
        private Vector3 startPos;
        [SerializeField]
        private float _respawnDuration;

        public float respawnDuration { get => _respawnDuration; set => _respawnDuration = value; }

        private void Awake()
        {
            health = GetComponent<Health>();
        }
        private void OnEnable()
        {
            startPos = transform.position;
        }

        public void CheckHealth() 
        {
            if(health.currentHealth <= 0f) 
            {
                Die();
            }
        }

        private void Die()
        {
            if (!photonView.IsMine)
            {
                return;
            }
            PlayerManager.instance.LocalPlayerInventory.DropAll();
            transform.position = startPos;
            onDeathCallback?.Invoke();
            StartCoroutine(RespawnRoutine());
        }
        private IEnumerator RespawnRoutine() 
        {
            yield return new WaitForSeconds(respawnDuration);
            PlayerManager.instance.LocalPlayerDamagable.RecoverHealth(health.MaxHealth);
            onRespawnCallback?.Invoke();
        }
    }
}