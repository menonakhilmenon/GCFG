using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class AlwaysLookUp : MonoBehaviour
    {
        void Update()
        {
            transform.up = Vector3.up;
        }
    }
}