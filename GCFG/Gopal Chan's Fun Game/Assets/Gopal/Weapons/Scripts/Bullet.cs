using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
        public float damage { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<Damageable>();
            if (target != null)
            {
                target.OnTakeDamage?.Invoke(damage);
            }
            Destroy(gameObject);
        }
        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

}