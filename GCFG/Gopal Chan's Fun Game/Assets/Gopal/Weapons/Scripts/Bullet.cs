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
        private LayerMask hitLayers = 0;


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
            if (photonView.IsMine)
            {
                playerHitEvent.Invoke();
                if( hitLayers == (hitLayers | (1<<other.gameObject.layer))) 
                {
                    var target = other.GetComponent<Damageable>();
                    if (target != null)
                    {
                        target.TakeDamage(damage);
                    }
                }
                PhotonNetwork.Destroy(gameObject);
            }
        }
        private void Update()
        {
            if (photonView.IsMine) 
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