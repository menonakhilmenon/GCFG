using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeWeaponObject : MonoBehaviour
{
    [HideInInspector]
    public Transform hitStartPoint;
    [SerializeField]
    private UnityEvent onMeleeUseCallback = null;

    public void UseWeapon() 
    {
        onMeleeUseCallback?.Invoke();
    }

}
