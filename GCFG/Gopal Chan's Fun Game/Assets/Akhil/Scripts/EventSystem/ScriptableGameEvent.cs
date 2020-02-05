using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableGameEvent : ScriptableObject
{
    [NonSerialized]
    private HashSet<IListener> listeners = new HashSet<IListener>();

    public void Invoke(params object[] parameters) 
    {
        foreach (var item in listeners)
        {
            item.OnEventRaised(parameters);
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
