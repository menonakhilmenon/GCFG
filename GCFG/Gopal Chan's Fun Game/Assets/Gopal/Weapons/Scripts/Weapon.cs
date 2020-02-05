using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using bilalAdarsh;

namespace Gopal
{
    public abstract class Weapon : Item
    {
        public WeaponObject weaponObject = null;
        public float weaponCooldown = 0.5f;
        public int damage;

        public override string Type => "Weapon";
        public override bool IsUsable => true;

        public override string UIDescription => $"{base.UIDescription}\nAttack Speed : {1/weaponCooldown}\nDamage : {damage}";


        public virtual void UseWeapon(WeaponUser user) 
        {
            Debug.Log($"Using {name}");
        }
        public virtual void EquipWeapon(WeaponUser user)
        {
            Debug.Log($"Equpping {name}");
        }

        public virtual void UnEquipWeapon(WeaponUser user)
        {
            Debug.Log($"UnEqupping {name}");
        }

        public override void UseItem()
        {
            base.UseItem();
            EquipWeapon(PlayerManager.instance.LocalWeaponUser);
        }
    }

}