using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="MeleeWeapon")]
    public class MeleeData : WeaponData
    {
        public GameObject model;
        public int damage;
        public float range;

        public override void useWeapon(WeaponUser user)
        {
            Debug.Log("Splish Slash, Your Opinion is Trash");

            // Get all enemies in range of the sword
            Collider[] hitEnemies = Physics.OverlapSphere(user.spawnPoint.position,range);
            
            // Damage each enemy
            foreach(Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Damageable>()?.onTakeDamage?.Invoke(damage);
            }
        }
    }
}

