using Gopal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _currentHealth = 100f;
        [SerializeField]
        private float maxHealth = 100f;
        [SerializeField]
        private FloatEventHandler onHealthUpdate = null;

        public float MaxHealth => maxHealth;
        public float currentHealth 
        { 
            get => _currentHealth;
            set 
            {
                var target = Mathf.Clamp(value,0f,maxHealth);
                if(target!= _currentHealth) 
                {
                    _currentHealth = target;
                    onHealthUpdate?.Invoke(_currentHealth);
                }
            }
        }
        private void OnValidate()
        {
            _currentHealth = Mathf.Clamp(_currentHealth, 0f, maxHealth);
        }
        public void UpdateHealth(float delta) 
        {
            currentHealth += delta;
        }
    }
}