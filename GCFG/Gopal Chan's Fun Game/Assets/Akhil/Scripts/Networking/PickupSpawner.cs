using bilalAdarsh;
using GCFG;
using NaughtyAttributes;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ItemDropRate 
{
    [SerializeReference]
#pragma warning disable CA2235 // Mark all non-serializable fields
    public Item item = null;
#pragma warning restore CA2235 // Mark all non-serializable fields
    public float dropRate = 1;
}

public static class ItemDropExtension 
{
    public static Item GetItemRandomly(this List<ItemDropRate> items) 
    {
        if(items.Count == 0)
        {
            return null;
        }
        float totalDropRate = 0f;
        foreach (var item in items)
        {
            totalDropRate += item.dropRate;
        }
        float currentDropRate = 0f;
        float rng = Random.Range(0f, totalDropRate);

        for (int i = 0; i < items.Count; i++)
        {
            if(rng < currentDropRate + items[i].dropRate) 
            {
                return items[i].item;
            }
            currentDropRate += items[i].dropRate;
        }
        return items[items.Count -1].item;
    }
}

[System.Serializable]
public class SpawnDelay 
{
    public int spawnCount = 0;
    public float spawnDelay = 10f;
}



[RequireComponent(typeof(PhotonView))]
public class PickupSpawner : MonoBehaviourPun
{
    [SerializeField]
    private PhotonObjects photonObjects = null;
    public static PickupSpawner instance = null;

    [SerializeField]
    [ReorderableList]
    private List<ItemDropRate> itemDropRates = new List<ItemDropRate>();

    [SerializeField]
    [ReorderableList]
    private List<SpawnDelay> spawnDelays = new List<SpawnDelay>();


    [SerializeField]
    private Transform centreSpawnObject = null;


    private Coroutine pickupSpawnRoutine = null;


    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }


    [Button("Spawn Shit")]
    public void SpawnAtOrigin() 
    {
        SpawnPickupAtCentre(1);
    }

    public static void SpawnPickup(Item  itemType, int count,Vector3 position,Quaternion rotation) 
    {
        instance.photonView.RPC(nameof(SpawnPickupRPC), RpcTarget.All, instance.photonObjects.GetIndex(itemType), count, position, rotation);
    }

    [PunRPC]
    private void SpawnPickupRPC(int itemIndex,int count,Vector3 position,Quaternion rotation) 
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        var item = photonObjects.GetObject(itemIndex) as Item;
        if (item != null) 
        {
            var obj = PhotonNetwork.Instantiate(item.dropModel.name, position, rotation);
            obj.GetComponent<DroppedItem>().Count = count;
        }
    }

    public void StartSpawningPickupOverTime() 
    {
        if(pickupSpawnRoutine != null) 
        {
            StopCoroutine(pickupSpawnRoutine);
        }
        pickupSpawnRoutine = StartCoroutine(PickupSpawnRoutine());
    }

    public void StopSpawnPickupRoutine() 
    {
        if(pickupSpawnRoutine != null) 
        {
            StopCoroutine(pickupSpawnRoutine);
            pickupSpawnRoutine = null;
        }
    }

    private IEnumerator PickupSpawnRoutine() 
    {
        while (true) 
        {
            for (int i = 0; i < spawnDelays.Count; i++)
            {
                if (PhotonNetwork.IsMasterClient) 
                {
                    SpawnPickupAtCentre(spawnDelays[i].spawnCount);
                }
                yield return new WaitForSeconds(spawnDelays[i].spawnDelay);
            }
        }
    }

    private void SpawnPickupAtCentre(int itemDropCount) 
    {
        for (int i = 0; i < itemDropCount; i++)
        {
            Vector3 SpawnLocation = Random.insideUnitSphere;
            SpawnLocation.y = 3f;
            SpawnLocation.x *= centreSpawnObject.localScale.x/2f;
            SpawnLocation.z *= centreSpawnObject.localScale.z/2f;
            SpawnLocation += centreSpawnObject.position;
            SpawnPickup(itemDropRates.GetItemRandomly(), 1, SpawnLocation, Quaternion.identity);
        }
    }


    private void OnDestroy()
    {
        if(instance == this) 
        {
            instance = null;
        }
    }
}
