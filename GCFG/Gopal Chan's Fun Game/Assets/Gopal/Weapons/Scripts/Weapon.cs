using System.Collections.Generic;
using UnityEngine;
using bilalAdarsh;
using System;

namespace Gopal
{
    public abstract class Weapon : Item
    {
        [SerializeField]
        private float _weaponCooldown = 0.5f;
        public float weaponCooldown =>_weaponCooldown;
        [SerializeField]
        private float _damage = 10f;
        public float damage=>_damage;
        public override string Type => "Weapon";
        public override bool IsUsable => true;
        public override string UIDescription => $"{base.UIDescription}\nAttack Speed : {1 / weaponCooldown}\nDamage : {damage}";
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
            PlayerManager.instance.WeaponNetworking.NetworkEquipWeapon(this);
        }
        public virtual bool TryUseWeapon(WeaponUser user) 
        {
            return true;
        }
    };
    public abstract class Weapon<T> : Weapon where T : WeaponUsageData,new()
    {

        [NonSerialized]
        private Dictionary<WeaponUser, T> weaponUsageData = new Dictionary<WeaponUser, T>();
        public override bool TryUseWeapon(WeaponUser user)
        {
            if ((DateTime.Now - GetWeaponUsageData(user).lastUsage).TotalSeconds >= weaponCooldown)
                return true;
            return false;
        }

        protected T GetWeaponUsageData(WeaponUser user) 
        {
            if (!weaponUsageData.ContainsKey(user))
            {
                weaponUsageData.Add(user, new T());
            }
            return weaponUsageData[user];
        }
    }
    public class WeaponUsageData
    {
        public DateTime lastUsage = DateTime.MinValue;
    }
}