using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gopal
{

    [Serializable]
    public class FloatEvent : UnityEvent<float> 
    {
    
    }
    public class Tower : MonoBehaviour
    {

        [SerializeField]
        private float damageFactor = 1f;
        [SerializeField]
        private float progressionToWin = 100f;

        private float _progression = 0;





        public FloatEvent TowerProgressionUpdate;
        public UnityEvent TowerProgressionComplete;

        public float Progression
        {
            get { return _progression; }
            set
            {
                if (_progression != value)
                {
                    _progression = value;
                    TowerProgressionUpdate?.Invoke(value);
                    if(_progression >= progressionToWin) 
                    {
                        TowerProgressionComplete?.Invoke();
                    }
                }
            }
        }




        public void TakeDamage(float damage)
        {
            Progression -= damageFactor * damage;
        }
    }
}
