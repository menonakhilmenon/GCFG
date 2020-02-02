using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="ProjectileWeapon")]
    public class ProjectileData : WeaponData
    {
        public GameObject model;
        public int damage;
        public int range;
        public int reloadTime;
        public Bullet bullet;

        public override void useWeapon(WeaponUser user)
        {
            Debug.Log("Thape Thape Thape");
            // Create a new bullet at the the instantiate point
            Instantiate(bullet,user.spawnPoint.position,user.spawnPoint.rotation);
        }
    }
}
