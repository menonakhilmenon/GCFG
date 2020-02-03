using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Interactor> OnInteractionStart;
    [SerializeField]
    private UnityEvent<Interactor> OnInteract;
    [SerializeField]
    private UnityEvent<Interactor> OnInteractionEnd;

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
