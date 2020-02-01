﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bilalAdarsh
{
    public class PickUp : MonoBehaviour
    {
        public Resource r;

        private void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material.color = r.color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameObject player = other.gameObject;
                Inventory i = player.GetComponent<Inventory>();
                i.addItem(r);
                Destroy(gameObject);
            }
        }
    }
}