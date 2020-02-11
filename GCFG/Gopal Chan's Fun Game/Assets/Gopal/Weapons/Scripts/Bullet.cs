using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [RequireComponent(typeof(PhotonView))]
    public class Bullet : MonoBehaviourPun
    {
        [SerializeField]
        private float _speed = 5f;
        [SerializeField]
        private float _damage = 5f;

        [SerializeField]
        private ScriptableGameEvent playerHitEvent = null;

        public float damage { get => _damage; set => _damage = value; }
        public float speed { get=>_speed ; set => _speed = value; }
        private float range { get; set; } = float.MaxValue;

        private Vector3 startPoint;

        private void OnEnable()
        {
            startPoint = transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (PhotonNetwork.IsMasterClient || photonView.IsMine)
            {
                if (photonView.IsMine)
                {
                    playerHitEvent.Invoke();
                }
                if(!PhotonNetwork.IsMasterClient)
                {
                    return;
                }
                var target = other.GetComponent<Damageable>();
                if (target != null)
                {
                    target.OnTakeDamage?.Invoke(damage);
                }
                PhotonNetwork.Destroy(gameObject);
            }
        }
        private void Update()
        {
            if (PhotonNetwork.IsMasterClient) 
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                if((startPoint - transform.position).magnitude > range) 
                {
                    PhotonNetwork.Destroy(gameObject);
                }
            }
        }

        public void SetBulletData(float damage,float range) 
        {
            photonView.RPC(nameof(SetBulletDataRPC), RpcTarget.All, damage, range);
        }
        [PunRPC]
        private void SetBulletDataRPC(float damage,float range) 
        {
            this.damage = damage;
            this.range = range;
        }
    }

}