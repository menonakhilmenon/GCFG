using Gopal;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponUser))]
public class WeaponNetworking : MonoBehaviour
{
    [SerializeField]
    private PhotonView photonView = null;
    private WeaponUser weaponUser = null;

    private void Awake()
    {
        weaponUser = GetComponent<WeaponUser>();
    }

    public void NetworkUseWeapon() 
    {
        if (weaponUser.TryUseWeapon()) 
        {
            photonView.RPC(nameof(UseWeaponRPC), RpcTarget.AllViaServer);
        }
    }

    [PunRPC]
    private void UseWeaponRPC() 
    {
        weaponUser.UseWeapon();
    }
}
