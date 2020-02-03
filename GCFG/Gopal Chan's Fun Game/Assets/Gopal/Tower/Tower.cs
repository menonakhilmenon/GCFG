using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bilalAdarsh;
using Photon.Pun;

namespace Gopal
{
    public class Tower : MonoBehaviour
    {
        [Header("Repair and Progression")]

        [SerializeField]
        private Repairable repairable = null;
        [SerializeField]
        private float damageFactor = 1f;
        [SerializeField]
        private float progressionToWin = 100f;

        private float _progression = 0;

        [Header("Craft Values")]
        [SerializeField]
        private float goldWeight = 5f;
        [SerializeField]
        private float stoneWeight = 3f;
        [SerializeField]
        private float woodWeight = 1f;

        public Action<float> TowerSpawn;
        public Action<float> TowerProgressionUpdate;
        public Action TowerProgressionComplete;

        public float Progression
        {
            get { return _progression; }
            set
            {
                if (_progression != value)
                {
                    _progression = value;
                    TowerProgressionUpdate(value);
                    if(_progression >= progressionToWin) 
                    {
                        TowerProgressionComplete?.Invoke();
                    }
                }
            }
        }



        private void OnEnable()
        {
            repairable.OnRepair += RepairTower;
            TowerSpawn?.Invoke(_progression);
            gameObject.GetComponent<Damageable>().OnTakeDamage += TakeDamage;
        }


        public void TakeDamage(int damage)
        {
            Progression -= damageFactor * damage;
        }

        private void RepairTower(Dictionary<Item.Type,int> materials)
        {
            foreach (var item in materials)
            {
                if(item.Key == Item.Type.Gold)
                {
                    Progression += goldWeight * item.Value;
                }else if(item.Key == Item.Type.Stone)
                {
                    Progression += stoneWeight * item.Value;
                }else if(item.Key == Item.Type.Wood)
                {
                    Progression += woodWeight * item.Value;
                }
            }
        }
    }
}
