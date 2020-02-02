using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bilalAdarsh;
namespace Gopal
{
    public class Tower : MonoBehaviour
    {
        private float progression = 0;
        public Action<float> TowerSpawn;
        public Action<float> TowerProgressionUpdate;
        private float goldWeight = 5f;
        private float stoneWeight = 3f;
        private float woodWeight = 1f;
        private float damageFactor;

        public float Progression
        {
            get { return progression; }
            set
            {
                if (progression != value)
                {
                    progression = value;
                    TowerProgressionUpdate(value);
                }
                Debug.Log("Progression :"+progression);
            }
        }

        private void OnEnable()
        {
            TowerSpawn?.Invoke(progression);
            gameObject.GetComponent<Damageable>().onTakeDamage += takeDamage;
        }

        public void takeDamage(int damage)
        {
            Progression -= damageFactor * damage;
        }

        private void repairTower(Dictionary<Item.Type,int> materials)
        {
            Debug.Log("YYY");
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

        void Start()
        {
            gameObject.GetComponentInChildren<Repairable>().onRepairTower += repairTower;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Progression++;
            }
        }
    }
}
