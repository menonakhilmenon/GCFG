using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class Raycaster : MonoBehaviour
    {
        public Quaternion GetRotationWithoutRaycast(Transform start,float range) 
        {
            return Quaternion.LookRotation(transform.position + transform.forward * range - start.position, Vector3.up);
        }
        public bool Raycast(float range,out RaycastHit hit,LayerMask layerMask) 
        {
            return Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask);
        }
    }
}