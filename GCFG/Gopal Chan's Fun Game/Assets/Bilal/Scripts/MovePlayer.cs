using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bilalAdarsh
{
    public class MovePlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody rb;
        public float speed;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector3 force = new Vector3(moveX, 0, moveY);

            rb.AddForce(force * speed);
        }
    }
}
