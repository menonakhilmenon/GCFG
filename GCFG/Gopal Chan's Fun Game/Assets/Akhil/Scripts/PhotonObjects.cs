using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this class to refer prefabs and scriptable objects across network
/// </summary>
[CreateAssetMenu(menuName ="PhotonObjectList")]
public class PhotonObjects : ScriptableObject
{
    [SerializeField]
    [ReorderableList]
    private List<Object> photonObjects = null;

    public int GetIndex(Object obj) 
    {
        if(photonObjects.Contains(obj))
            return photonObjects.IndexOf(obj);
        Debug.LogError($"{obj.name} hasn't been added to PhotonObjects List..");
        return -1;
    }

    public Object GetObject(int index) 
    {
        if(0<=index && index < photonObjects.Count)
            return photonObjects[index];
        Debug.LogError("Index out of bounds..");
        return null;
    }
}
