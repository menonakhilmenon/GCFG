using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Adarsh
{


    public class CameraMovement : MonoBehaviour
    {
        public float speedH = 2.0f;
        public float speedV = 2.0f;

        public float yaw = 0.0f;
        public float pitch = 0.0f;
        void Update()
        {
            //yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, 0.0f, 0.0f);

        }
    }
}
