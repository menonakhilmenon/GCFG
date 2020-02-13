using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class Raycaster : MonoBehaviour
    {
        public Quaternion GetRotationWithoutRaycast(Transform start) 
        {
            //Vector3 forward;
            //if (range <= raycastLimit) 
            //{
            //     forward = transform.position + transform.forward * range - start.position;
            //}
            //else 
            //{
            //    forward = transform.forward;
            //}
            //Debug.Log(forward.ToString());
            //return Quaternion.LookRotation(forward, transform.up);
            return Quaternion.LookRotation(start.forward,start.up);
        }
        public bool Raycast(float range,out RaycastHit hit,LayerMask layerMask) 
        {
            return Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask);
        }
    }
}