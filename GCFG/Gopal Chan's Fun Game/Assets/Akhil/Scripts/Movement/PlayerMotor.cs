using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [RequireComponent(typeof(PhotonView),typeof(CharacterController))]
    public class PlayerMotor : MonoBehaviour
    {
        private CharacterController characterController;

        public float mouseSensitivity = 5f;
        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private float jumpSpeed = 8;
  
        private float vSpeed = 0f;

        private void OnEnable()
        {
            characterController = GetComponent<CharacterController>();
        }

       

        private void Update()
        {
            var motion = Vector3.zero;
            if (!PlayerEventGenerator.isFreeLooking) 
            {
                var rot = Input.GetAxis("Mouse X");
                transform.eulerAngles += (Vector3.up * mouseSensitivity * rot * Time.deltaTime);


                motion += Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
            }
            if (characterController.isGrounded) 
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    vSpeed = jumpSpeed;
                }
            }
            vSpeed += Physics.gravity.y * Time.deltaTime;
            motion.y = vSpeed;

            characterController.Move(motion * speed * Time.deltaTime);
        }

    }
}