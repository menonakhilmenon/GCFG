using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [RequireComponent(typeof(PhotonView),typeof(CharacterController))]
    public class PlayerMotor : MonoBehaviour
    {
        private PhotonView view;
        private CharacterController characterController;

        public float lookSmoothing = 5f;


        private void OnEnable()
        {
            characterController = GetComponent<CharacterController>();
            view = GetComponent<PhotonView>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var rot = Input.GetAxis("Mouse X");
            transform.eulerAngles += (Vector3.up * lookSmoothing * rot * Time.deltaTime);
        }

    }
}