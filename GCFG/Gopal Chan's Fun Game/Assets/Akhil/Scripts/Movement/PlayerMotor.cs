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
        public float speed = 5f;

        private void OnEnable()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var rot = Input.GetAxis("Mouse X");
            var motion = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
            transform.eulerAngles += (Vector3.up * mouseSensitivity * rot * Time.deltaTime);

            characterController.Move(motion * speed);
        }

    }
}