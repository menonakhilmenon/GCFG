using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gopal
{
    [RequireComponent(typeof(Damageable))]
    public class HealthManager : MonoBehaviour
    {
        public float health = 100;
        public Action<float> HealthUpdate;
        public float Health
        {
            get
            {
                return health;
            }
            set
            {
                if (health != value)
                {
                    health = value;
                    HealthUpdate?.Invoke(health);
                }
            }
        }
        private float damageFactor = 1f;
        private void OnEnable()
        {
            GetComponent<Damageable>().OnTakeDamage += takeDamage;
        }


        void takeDamage(int damage)
        {
            Health -= damageFactor * damage;
        }
    }

}
