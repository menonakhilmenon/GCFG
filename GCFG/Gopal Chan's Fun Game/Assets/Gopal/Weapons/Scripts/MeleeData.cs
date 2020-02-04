using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="MeleeWeapon")]
    public class MeleeData : Weapon
    {
        public GameObject model;
        public int damage;
        public float range;

        public override void EquipWeapon(WeaponUser user)
        {
            throw new System.NotImplementedException();
        }

        public override void UnEquipWeapon(WeaponUser user)
        {
            throw new System.NotImplementedException();
        }

        public override void UseWeapon(WeaponUser user)
        {

            // Get all enemies in range of the sword
            Collider[] hitEnemies = Physics.OverlapSphere(user.spawnPoint.position,range);
            
            // Damage each enemy
            foreach(Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Damageable>()?.OnTakeDamage?.Invoke(damage);
            }
        }
    }
}

