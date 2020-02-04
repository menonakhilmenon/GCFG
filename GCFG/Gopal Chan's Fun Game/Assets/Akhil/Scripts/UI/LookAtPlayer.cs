using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class LookAtPlayer : MonoBehaviour
    {
        private Camera targetCamera = null;
        public void SetTarget(Camera camera) 
        {
            targetCamera = camera;
        }

        private void Update()
        {
            if(targetCamera != null) 
            {
                transform.LookAt(targetCamera.transform, Vector3.up);
            }
        }
    }
}