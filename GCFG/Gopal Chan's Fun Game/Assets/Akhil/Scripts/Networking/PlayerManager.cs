using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gopal;
using bilalAdarsh;
using Photon.Pun;
using GCFG;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;

    private Dictionary<Player, Tower> playerTowers = null;
    private Dictionary<Player, PhotonView> playerObjects = null;


    public WeaponNetworking WeaponNetworking { get; set; } = null;
    public Inventory LocalPlayerInventory { get; set; } = null;
    public WeaponUser LocalWeaponUser { get; set; } = null;
    public Tower LocalTower { get; set; } = null;
    public PhotonView LocalPlayerView { get; set; } = null;

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
            return;
        }
        playerTowers = new Dictionary<Player, Tower>();
        playerObjects = new Dictionary<Player, PhotonView>();
    }

    public void RegisterPlayerTower(Player player, Tower tower)
    {
        playerTowers.Add(player, tower);
    }

    public void RegisterPlayer(Player player, PhotonView view)
    {
        playerObjects.Add(player, view);
    }

    public PhotonView GetPlayerView(Player player) 
    {
        return playerObjects.ContainsKey(player) ? playerObjects[player] : null;
    }


    public Tower GetPlayerTower(Player player) 
    {
        return playerTowers.ContainsKey(player) ?  playerTowers[player] : null;
    }



}
