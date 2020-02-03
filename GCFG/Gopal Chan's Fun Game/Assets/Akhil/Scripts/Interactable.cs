using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Interactor> OnInteractionStart = null;
    [SerializeField]
    private UnityEvent<Interactor> OnInteract = null;
    [SerializeField]
    private UnityEvent<Interactor> OnInteractionEnd = null;

    private void OnTriggerEnter(Collider other)
    {
        var interactor = other.GetComponent<Interactor>();
        if (interactor != null)
        {
            OnInteractionStart?.Invoke(interactor);
        }
    }

    public void Interact(Interactor interactor) 
    {
        OnInteract?.Invoke(interactor);
    }

    private void OnTriggerExit(Collider other)
    {
        var interactor = other.GetComponent<Interactor>();
        if (interactor != null)
        {
            OnInteractionEnd?.Invoke(interactor);
        }
    }
}
