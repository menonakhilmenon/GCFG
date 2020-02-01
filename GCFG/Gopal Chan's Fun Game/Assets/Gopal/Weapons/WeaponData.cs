using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using bilalAdarsh;

namespace Gopal
{
    public abstract class WeaponData : Item
    {
        public abstract void useWeapon(WeaponUser user);
    }

}