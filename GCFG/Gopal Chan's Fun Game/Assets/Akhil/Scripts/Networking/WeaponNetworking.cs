using Gopal;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{

    [RequireComponent(typeof(WeaponUser))]
    [RequireComponent(typeof(PhotonView))]
    public class WeaponNetworking : MonoBehaviourPun
    {

        private WeaponUser weaponUser = null;

        [SerializeField]
        private PhotonObjects photonObjectSettings = null;


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

        public void NetworkEquipWeapon(Weapon weaponData)
        {
            if(weaponData != null) 
            {
                photonView.RPC(nameof(EquipWeaponRPC), RpcTarget.AllBufferedViaServer, photonObjectSettings.GetIndex(weaponData));
            }
            else 
            {
                photonView.RPC(nameof(UnEquipWeaponRPC), RpcTarget.AllBufferedViaServer);
            }
        }

        [PunRPC]
        private void EquipWeaponRPC(int weaponIndex)
        {
            weaponUser.EquipWeapon(photonObjectSettings.GetObject(weaponIndex) as Weapon);
        }
        [PunRPC]
        private void UnEquipWeaponRPC() 
        {
            weaponUser.UnEquipWeapon();
        }
        [PunRPC]
        private void UseWeaponRPC()
        {
            weaponUser.UseWeapon();
        }
    }
}