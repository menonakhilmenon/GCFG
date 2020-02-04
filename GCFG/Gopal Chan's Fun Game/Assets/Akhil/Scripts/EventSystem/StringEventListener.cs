using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringEventListener : MonoBehaviour,IListener
{
    [SerializeField]
    private ScriptableGameEvent stringEvent = null;
    [SerializeField]
    private StringEvent stringEventCallback = null;


    private void OnEnable()
    {
        stringEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        stringEvent.UnRegisterListener(this);
    }

    public void OnEventRaised(params object[] parameters)
    {
        stringEventCallback?.Invoke(parameters[0] as string);
    }
}

[System.Serializable]
public class StringEvent : UnityEvent<string> 
{

}
