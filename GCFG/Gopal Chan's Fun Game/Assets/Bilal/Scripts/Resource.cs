using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilal
{

    public class Resource : MonoBehaviour
    {
        public Action onCollect;

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            onCollect?.Invoke();
        }
    }

}