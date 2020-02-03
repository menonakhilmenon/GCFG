using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class Bullet : MonoBehaviour
    {
        public int damage = 5;
        public float speed = 5f;

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Damageable>()?.OnTakeDamage?.Invoke(damage);
            Destroy(gameObject);
        }
        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

}