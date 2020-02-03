using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraEventListener : MonoBehaviour,IListener
{
    [SerializeField]
    private ScriptableGameEvent cameraEvent = null;

    [SerializeField]
    private CameraEvent onEventRaised = null;
    private void OnEnable()
    {
        cameraEvent.RegisterListener(this);
    }
    public void OnEventRaised(params object[] parameters)
    {
        onEventRaised?.Invoke(parameters[0] as Camera);
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