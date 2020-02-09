using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private PhotonView photonView = null;

    [Header("Interaction Raycast Data")]
    [SerializeField]
    private Camera interactionCamera = null;
    [SerializeField]
    private float interactionRange = 5f;
    [SerializeField]
    private LayerMask interactionLayerMask = 0;

    public PhotonView PhotonView 
    {
        get => photonView;
    }

    public static Interactor localInteractor = null;

    public Interactable currentInteractable { get; private set; } = null;
    private Interactable lastInteractable = null;


    private void OnEnable()
    {
        if (photonView.IsMine) 
        {
            localInteractor = this;
        }
    }

    public void Interact() 
    {
        if(currentInteractable != null) 
        {
            currentInteractable?.Interact();
        }
    }
    private void Update()
    {
        if(Physics.Raycast(interactionCamera.transform.position,interactionCamera.transform.forward,out var hit, interactionRange, interactionLayerMask)) 
        {
            var interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null) 
            {
                currentInteractable = interactable;
            }
        }
        else 
        {
            currentInteractable = null;
        }
        if(lastInteractable != currentInteractable) 
        {
            if (lastInteractable != null) 
            {
                lastInteractable.EndInteraction();
            }
            if(currentInteractable != null) 
            {
                currentInteractable.StartInteraction();
            }
            lastInteractable = currentInteractable;
        }
    }
}
