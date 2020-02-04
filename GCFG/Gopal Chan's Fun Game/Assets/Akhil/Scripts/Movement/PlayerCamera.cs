using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField]
        private float _cameraSensitivityY = 5f;

        [SerializeField]
        private float cameraLowerAngle = 15f;

        [SerializeField]
        private float cameraUpperAngle = 90f;

        public float cameraSensitivityY 
        {
            get 
            {
                return _cameraSensitivityY;
            }
            set 
            {
                _cameraSensitivityY = value;
            }
        }
        void Update()
        {

            if (PlayerEventGenerator.isFreeLooking)
                return;
            var cameraAngle = transform.eulerAngles.x  + -Input.GetAxis("Mouse Y") * _cameraSensitivityY;
            if(cameraAngle > 180) 
            {
                cameraAngle -= 360f;
            }
            cameraAngle=Mathf.Clamp(cameraAngle, cameraLowerAngle, cameraUpperAngle);


            transform.localEulerAngles =   Vector3.right * cameraAngle;
        }
    }
}