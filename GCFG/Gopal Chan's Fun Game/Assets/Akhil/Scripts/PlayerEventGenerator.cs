using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventGenerator : MonoBehaviour
{
    public static Action InteractEvent = null;
    public static Action FreeLookBeginEvent = null;
    public static Action FreeLookEndEvent = null;
    public static Action FireEvent = null;
    public static Action AltFireEvent = null;


    [SerializeField]
    private KeyCode InteractKey = KeyCode.F;
    [SerializeField]
    private KeyCode FreeLookKey = KeyCode.LeftAlt;


    private bool isFreeLooking = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFreeLooking) 
        {
            if (!Input.GetMouseButton(1)) 
            {
                FireEvent?.Invoke();
            }
            else 
            {
                AltFireEvent?.Invoke();
            }
        }

        if (Input.GetKeyDown(FreeLookKey)) 
        {
            FreeLookBeginEvent?.Invoke();
        }
        isFreeLooking = Input.GetKey(FreeLookKey);

        if (Input.GetKeyUp(FreeLookKey)) 
        {
            FreeLookEndEvent?.Invoke();
        }

        if(!isFreeLooking && Input.GetKeyDown(InteractKey)) 
        {
            InteractEvent?.Invoke();
        }


    }
}
