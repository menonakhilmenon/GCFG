using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameEvent")]
public class ScriptableGameEvent : ScriptableObject
{
    [NonSerialized]
    private List<IListener> listeners = new List<IListener>();

    public void Invoke(params object[] parameters) 
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(parameters);
        }
    }
    public void InvokeWithoutParams() 
    {
        Invoke();
    }
    public void RegisterListener(IListener listener) 
    {
        if (!listeners.Contains(listener)) 
        {
            listeners.Add(listener);
        }
    }
    public void UnRegisterListener(IListener listener) 
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
