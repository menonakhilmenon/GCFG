using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilalAdarsh
{
    public class ChangeColor : MonoBehaviour
    {
        // Start is called before the first frame update
        public Resource resourceType;
        void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material.color = resourceType.color;
        }


    }
}

