using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="Gun")]
    public class GunData : WeaponData
    {
        public GameObject model;
        public int damage;
        public int range;
        public int reloadTime;
        public Bullet bullet;

        public override void useWeapon()
        {
            Debug.Log("Thape Thape Thape");
            Instantiate(bullet);
        }
    }
}
