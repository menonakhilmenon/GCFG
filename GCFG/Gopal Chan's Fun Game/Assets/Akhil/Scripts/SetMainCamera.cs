using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SetMainCamera : MonoBehaviour
{
    [SerializeField]
    private ScriptableGameEvent cameraSetEvent = null;
    [SerializeField]
    private PhotonView photonView = null;
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        if (photonView.IsMine) 
        {
            cameraSetEvent?.Invoke(cam);
        }
    }
    private void OnDisable()
    {
        if (photonView.IsMine)
        {
            cameraSetEvent?.Invoke(cam);
        }
    }

}
