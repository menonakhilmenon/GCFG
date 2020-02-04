using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class WeaponUser : MonoBehaviour
    {
        [SerializeField]
        private PhotonView photonView = null;

        public Transform spawnPoint;
        public bool weaponEquipped = true;
        public Weapon weapon;
        public Action<Weapon> onEquippedWeapon;
        private DateTime lastUsage = DateTime.Now;

        private void Start()
        {
            onEquippedWeapon += EquipWeapon;
        }

        public void EquipWeapon(Weapon newWeapon)
        {
            weapon?.UnEquipWeapon(this);
            weapon = newWeapon;
            weaponEquipped = true;
        }
        public void UnEquipWeapon() 
        {
            weapon.UnEquipWeapon(this);
            weaponEquipped = false;
            weapon = null;
        }


        public void UseWeapon()
        {
            lastUsage = DateTime.Now;
            weapon.UseWeapon(this);
        }

        public bool TryUseWeapon() 
        {
            if ((DateTime.Now - lastUsage).TotalSeconds >= weapon.weaponCooldown) 
                return true;
            return false;
        }
    }

}