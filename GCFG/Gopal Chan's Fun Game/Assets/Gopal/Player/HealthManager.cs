using GCFG;
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
        public FloatEventHandler HealthUpdate;
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


        public void TakeDamage(float damage)
        {
            Health -= damageFactor * damage;
        }
    }

}
