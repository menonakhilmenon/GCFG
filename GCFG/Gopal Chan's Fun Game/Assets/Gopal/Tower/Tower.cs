using System;
using UnityEngine;
using UnityEngine.Events;
using GCFG;
namespace Gopal
{

    [Serializable]
    public class FloatEvent : UnityEvent<float> 
    {
    
    }
    [RequireComponent(typeof(Health))]
    public class Tower : MonoBehaviour
    {
        private float ProgressionToWin => health.MaxHealth;

        public UnityEvent TowerProgressionComplete;
        public float Progression => health.currentHealth;
        private Health health = null;


        private void Awake()
        {
            health = GetComponent<Health>();
        }
        public void CheckTowerProgression() 
        {
            if (Progression >= ProgressionToWin) 
            {
                TowerProgressionComplete?.Invoke();
            }
        }
    }
}
