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
    public ScriptableGameEvent InventoryEvent = null;

    [SerializeField]
    private KeyCode InteractKey = KeyCode.F;
    [SerializeField]
    private KeyCode FreeLookKey = KeyCode.LeftAlt;
    [SerializeField]
    private KeyCode InventoryKey = KeyCode.I;

    private static bool _fullFreeLook = true;


    public static bool isFreeLooking => isFullFreeLook || _isFreeLooking;
    private static bool _isFreeLooking = false;

    public bool isPlaying { get; set; } = false;

    public static bool isFullFreeLook
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

    public bool FullFreeLook { get => isFullFreeLook; set => isFullFreeLook = value; }

    private void Update()
    {
        if (!isPlaying)
            return;
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

        if (Input.GetKeyDown(InventoryKey)) 
        {
            InventoryEvent?.Invoke();
        }



        if (!isFullFreeLook)
        {
            if (Input.GetKeyDown(FreeLookKey))
            {
                FreeLookBeginEvent?.Invoke();
                ReleaseCursor();
            }
            _isFreeLooking = Input.GetKey(FreeLookKey);

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
