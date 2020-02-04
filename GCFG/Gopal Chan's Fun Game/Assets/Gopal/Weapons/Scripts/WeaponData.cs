using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using bilalAdarsh;

namespace Gopal
{
    public abstract class WeaponData : Item
    {
        public float weaponCooldown = 0.5f;
        public abstract void EquipWeapon(WeaponUser user);
        public abstract void UseWeapon(WeaponUser user);
        public abstract void UnEquipWeapon(WeaponUser user);
    }

}