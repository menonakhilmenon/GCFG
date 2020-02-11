using bilalAdarsh;
using GCFG;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class WeaponUser : MonoBehaviourPun
    {
        [SerializeField]
        private Transform _localEquipPoint = null;
        [SerializeField]
        private Transform _remoteEquipPoint = null;
        [SerializeField]
        private Raycaster _raycastOrigin = null;

        public Transform localEquipPoint =>_localEquipPoint;
        public Transform remoteEquipPoint => _remoteEquipPoint;
        public Raycaster raycastOrigin => _raycastOrigin;
        public bool weaponEquipped => currentWeapon!=null;
        public Weapon currentWeapon { get; private set; } = null;


        public void EquipWeapon(Weapon newWeapon)
        {
            if (weaponEquipped)
            {
                currentWeapon.UnEquipWeapon(this);
            }
            currentWeapon = newWeapon;
            currentWeapon.EquipWeapon(this);
        }



        public void UnEquipWeapon() 
        {
            if(!weaponEquipped) 
            {
                return;
            }
            currentWeapon.UnEquipWeapon(this);
            currentWeapon = null;
        }


        public void UseWeapon()
        {
            currentWeapon.UseWeapon(this);
        }

        public bool TryUseWeapon() 
        {
            if (currentWeapon==null) 
            {
                return false;
            }
            return currentWeapon.TryUseWeapon(this);
        }

    }

}