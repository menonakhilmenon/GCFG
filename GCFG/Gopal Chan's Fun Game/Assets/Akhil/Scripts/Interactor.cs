using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Interactable currentInteractable = null;

    public void Interact() 
    {
        if(currentInteractable != null) 
        {
            currentInteractable?.Interact(this);
        }
    }
}
