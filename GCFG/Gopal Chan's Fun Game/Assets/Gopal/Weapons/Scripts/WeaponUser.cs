using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class WeaponUser : MonoBehaviour
    {
        public Transform spawnPoint;
        public bool weaponEquipped = true;
        public WeaponData weapon;
        public Action<WeaponData> onEquippedWeapon;
        private DateTime lastUsage = DateTime.Now;

        private void Start()
        {
            onEquippedWeapon += EquipWeapon;
        }

        public void EquipWeapon(WeaponData newWeapon)
        {
            weapon = newWeapon;
            weaponEquipped = true;
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