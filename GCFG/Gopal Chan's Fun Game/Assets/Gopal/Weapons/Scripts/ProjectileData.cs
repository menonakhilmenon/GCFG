using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="ProjectileWeapon")]
    public class ProjectileData : Weapon
    {
        public int range;
        public int reloadTime;
        public Bullet bullet;

        public override string UIDescription => $"{base.UIDescription}\nRange : {range}";

        public override void UseWeapon(WeaponUser user)
        {
            // Create a new bullet at the the instantiate point
            var obj = Instantiate(bullet,user.localEquipPoint.position,user.localEquipPoint.rotation);
            obj.damage = damage;
        }
    }
}
