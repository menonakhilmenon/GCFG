using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour, IListener
{
    public ScriptableGameEvent Event;
    public UnityEvent Response = null;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    public void OnEventRaised(params object[] parameters)
    {
        Response?.Invoke();
    }

    private void OnDisable()
    {
        Event.UnRegisterListener(this);
    }
}

public interface IListener
{
    void OnEventRaised(params object[] parameters);
}