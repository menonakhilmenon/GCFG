using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class TowerView : MonoBehaviour
    {
        public Tower parent;
        public GameObject child;
        [SerializeField]
        private int lowerThreshold = 0;
        [SerializeField]
        private int upperThreshold = 100;

        private void OnEnable()
        {
            parent.TowerProgressionUpdate += onProgressionUpdate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void onProgressionUpdate(float value)
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