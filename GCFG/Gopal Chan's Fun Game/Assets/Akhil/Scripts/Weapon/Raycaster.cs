using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField]
        private float raycastLimit = 1000f;
        public Quaternion GetRotationWithoutRaycast(Transform start,float range) 
        {
            Vector3 forward;
            if (range <= raycastLimit) 
            {
                 forward = transform.position + transform.forward * range - start.position;
            }
            else 
            {
                forward = transform.forward;
            }
            Debug.Log(forward.ToString());
            return Quaternion.LookRotation(forward, transform.up);
        }
        public bool Raycast(float range,out RaycastHit hit,LayerMask layerMask) 
        {
            return Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask);
        }
    }
}