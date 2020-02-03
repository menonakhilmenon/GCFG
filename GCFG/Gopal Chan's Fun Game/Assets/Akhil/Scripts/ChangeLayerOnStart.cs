using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerOnStart : MonoBehaviour
{
    [SerializeField]
    private PhotonView photonView = null;

    [SerializeField]
    private bool renameRecursively = true;

    [SerializeField]
    private string localLayerName = "Default";
    [SerializeField]
    private string remoteLayerName = "Default";

    private int localLayer;
    private int remoteLayer;
    void Start()
    {
        localLayer = LayerMask.NameToLayer(localLayerName);
        remoteLayer = LayerMask.NameToLayer(remoteLayerName);

        if (renameRecursively) 
        {
            ChangeLayerRecursively(gameObject);
        }
        else 
        {
            ChangeLayer(gameObject);
        }
    }
    public void ChangeLayerRecursively(GameObject obj) 
    {
        ChangeLayer(obj);
        foreach (Transform child in obj.transform)
        {
            ChangeLayerRecursively(child.gameObject);
        }
    }
    public void ChangeLayer(GameObject obj) 
    {
        if (photonView.IsMine) 
        {
            obj.layer = localLayer;
        }
        else 
        {
            obj.layer = remoteLayer;
        }
    }
}
