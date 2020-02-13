using bilalAdarsh;
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
            if (photonView.IsMine) 
            {
                PlayerManager.instance.WeaponNetworking = this;
            }
        }

        public void NetworkUseWeapon()
        {
            if (weaponUser.TryUseWeapon())
            {
                photonView.RPC(nameof(UseWeaponRPC), RpcTarget.AllViaServer);
            }
        }
        public void CheckIfDiscarded()
        {
            if(weaponUser.currentWeapon == null) 
            {
                return;
            }
            if (!PlayerManager.instance.LocalPlayerInventory.TryRemove(weaponUser.currentWeapon, 1))
            {
                NetworkEquipWeapon(null);
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
            Debug.Log(weaponUser.photonView.Owner.NickName);
            weaponUser.UnEquipWeapon();
        }
        [PunRPC]
        private void UseWeaponRPC()
        {
            weaponUser.UseWeapon();
        }
    }
}