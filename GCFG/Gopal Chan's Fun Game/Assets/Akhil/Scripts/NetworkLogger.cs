using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class NetworkLogger : MonoBehaviour
{
    public static NetworkLogger instance;
    private TMPro.TMP_Text text;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            text = GetComponent<TMPro.TMP_Text>();
        }
        else
        {
            Destroy(this);
        }
    }

    public static void Log(string value)
    {
        instance.text.text = value;
    }
}
