using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class Tower : MonoBehaviour
    {
        private int progression = 0;
        public Action<int> TowerSpawn;
        public Action<int> TowerProgressionUpdate;

        public int Progression
        {
            get { return progression; }
            set
            {
                if (progression != value)
                {
                    progression = value;
                    TowerProgressionUpdate(value);
                }
                Debug.Log(progression);
            }
        }

        private void OnEnable()
        {
            TowerSpawn?.Invoke(progression);
        }

        void Start()
        {
            
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
