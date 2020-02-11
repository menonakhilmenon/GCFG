using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{

    [SerializeField]
    private UnityEvent OnInteractionStart = null;
    [SerializeField]
    private UnityEvent OnInteract = null;
    [SerializeField]
    private UnityEvent OnInteractionEnd = null;


    public void StartInteraction()
    {
        OnInteractionStart?.Invoke();
    }
    public void EndInteraction()
    {
        OnInteractionEnd?.Invoke();
    }

    public void Interact() 
    {
        OnInteract?.Invoke();
    }

    private void OnDisable()
    {
        if(Interactor.localInteractor == null) 
        {
            return;
        }

        if(Interactor.localInteractor.currentInteractable == this) 
        {
            EndInteraction();
        }
    }

}

[System.Serializable]
public class InteractorEvent : UnityEvent<Interactor> 
{

}
