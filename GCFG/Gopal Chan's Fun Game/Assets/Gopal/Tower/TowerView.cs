using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class TowerView : MonoBehaviour
    {
        public GameObject child;
        [SerializeField]
        private int lowerThreshold = 0;
        [SerializeField]
        private int upperThreshold = 100;


        public void OnProgressionUpdate(float value)
        {
            Debug.Log("XXX");
            if(value >= lowerThreshold && value < upperThreshold)
            {
                child.SetActive(true);
            }
            else
            {
                child.SetActive(false);
            }
        }
    }

}