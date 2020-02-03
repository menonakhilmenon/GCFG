using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class Bullet : MonoBehaviour
    {
        public int damage = 5;
        public float speed = 5f;

        private void OnEnable()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Damageable>()?.onTakeDamage?.Invoke(damage);
            gameObject.SetActive(false);
        }
    }

}