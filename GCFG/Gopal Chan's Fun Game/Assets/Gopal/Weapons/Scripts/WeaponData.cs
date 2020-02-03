using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using bilalAdarsh;

namespace Gopal
{
    public abstract class WeaponData : Item
    {
        public float weaponCooldown = 0.5f;
        public abstract void useWeapon(WeaponUser user);
    }

}