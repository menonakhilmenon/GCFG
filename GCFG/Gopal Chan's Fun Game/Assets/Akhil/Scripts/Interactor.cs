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

    private Interactable currentInteractable = null;
    private Interactable lastInteractable = null;


    private Vector3 screenCentre = new Vector3(0.5f, 0.5f, 0f);

    public void Interact() 
    {
        if(currentInteractable != null) 
        {
            currentInteractable?.Interact(this);
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
                lastInteractable.EndInteraction(this);
            }
            if(currentInteractable != null) 
            {
                currentInteractable.StartInteraction(this);
            }
            lastInteractable = currentInteractable;
        }
    }
}
