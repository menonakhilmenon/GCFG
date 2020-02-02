using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gopal;
public class Repair : MonoBehaviour
{
    public bool canCraft = false;
    public RepairZone zone;
    private void OnTriggerEnter(Collider other)
    {
        canCraft = true;
    }
    private void OnTriggerStay(Collider other)
    {
        canCraft = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canCraft = false;
    }
}
