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
        public Action<WeaponData> EquipWeapon;

        private void Start()
        {
            EquipWeapon += onEquipWeapon;
        }

        public void onEquipWeapon(WeaponData newWeapon)
        {
            weapon = newWeapon;
            weaponEquipped = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                weapon.useWeapon(this);
            }
        }

    }

}