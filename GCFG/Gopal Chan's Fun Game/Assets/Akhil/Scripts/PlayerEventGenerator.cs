using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventGenerator : MonoBehaviour
{
    public ScriptableGameEvent InteractEvent = null;
    public ScriptableGameEvent FreeLookBeginEvent = null;
    public ScriptableGameEvent FreeLookEndEvent = null;
    public ScriptableGameEvent FireEvent = null;
    public ScriptableGameEvent AltFireEvent = null;


    [SerializeField]
    private KeyCode InteractKey = KeyCode.F;
    [SerializeField]
    private KeyCode FreeLookKey = KeyCode.LeftAlt;


    private static bool _fullFreeLook = true;

    public static bool isFreeLooking = false;
    public bool isFullFreeLook
    {
        get => _fullFreeLook;
        set
        {
            if (_fullFreeLook != value)
            {
                _fullFreeLook = value;
                if (value == false)
                {
                    LockCursor();
                }
                else 
                {
                    ReleaseCursor();
                }
            }
        }
    }



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


        if (!isFullFreeLook)
        {
            if (Input.GetKeyDown(FreeLookKey))
            {
                FreeLookBeginEvent?.Invoke();
                ReleaseCursor();
            }
            isFreeLooking = Input.GetKey(FreeLookKey);

            if (Input.GetKeyUp(FreeLookKey))
            {
                FreeLookEndEvent?.Invoke();
                LockCursor();
            }
        }
        if (!isFreeLooking && Input.GetKeyDown(InteractKey))
        {
            InteractEvent?.Invoke();
        }
    }

    private static void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
