using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraEventListener : MonoBehaviour,IListener
{
    private static Camera currentCamera = null;

    [SerializeField]
    private ScriptableGameEvent cameraEvent = null;

    [SerializeField]
    private CameraEvent onEventRaised = null;
    private void OnEnable()
    {
        cameraEvent.RegisterListener(this);

        InvokeCameraEvent();
    }

    private void InvokeCameraEvent()
    {
        onEventRaised?.Invoke(currentCamera);
    }

    public void OnEventRaised(params object[] parameters)
    {
        currentCamera = parameters[0] as Camera;
        InvokeCameraEvent();
    }
    private void OnDisable()
    {
        cameraEvent.UnRegisterListener(this);
    }
}
[System.Serializable]
public class CameraEvent : UnityEvent<Camera> 
{

}