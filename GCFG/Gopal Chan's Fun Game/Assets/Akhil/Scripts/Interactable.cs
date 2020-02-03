using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{

    [SerializeField]
    private InteractorEvent OnInteractionStart = null;
    [SerializeField]
    private InteractorEvent OnInteract = null;
    [SerializeField]
    private InteractorEvent OnInteractionEnd = null;

    private void OnTriggerEnter(Collider other)
    {
        var interactor = other.GetComponent<Interactor>();
        if (interactor != null)
        {
            OnInteractionStart?.Invoke(interactor);
        }
    }

    public void StartInteraction(Interactor other)
    {
        if (other != null)
        {
            OnInteractionStart?.Invoke(other);
        }
    }
    public void EndInteraction(Interactor other)
    {
        if (other != null)
        {
            OnInteractionEnd?.Invoke(other);
        }
    }

    public void Interact(Interactor interactor) 
    {
        OnInteract?.Invoke(interactor);
    }


}

[System.Serializable]
public class InteractorEvent : UnityEvent<Interactor> 
{

}
