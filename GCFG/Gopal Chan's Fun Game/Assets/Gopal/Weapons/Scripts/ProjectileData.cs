using GCFG;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="ProjectileWeapon")]
    public class ProjectileData : Weapon<ProjectileUsageData>
    {
        public float range = float.MaxValue;
        public float reloadTime;
        public Bullet bullet;
        [SerializeField]
        private GunWeaponObject weaponEquipPrefab = null;

        public override string UIDescription => $"{base.UIDescription}\nRange : {range}";

        public override void EquipWeapon(WeaponUser user)
        {
            base.EquipWeapon(user);
            if(bullet == null) 
            {
                Debug.LogError("BULLET UNASSIGNED FOR WEAPON!!");
            }
            var usageData = GetWeaponUsageData(user);
            if (usageData.weaponObject == null)
            {
                if (user.photonView.IsMine)
                {
                    usageData.equipPoint = user.localEquipPoint;
                }
                else
                {
                    usageData.equipPoint = user.remoteEquipPoint;
                }
                usageData.raycaster = user.raycastOrigin;
                usageData.weaponObject = Instantiate(weaponEquipPrefab, usageData.equipPoint.position, usageData.equipPoint.rotation, usageData.equipPoint);
            }
            usageData.weaponObject.gameObject.SetActive(true);
        }

        public override void UnEquipWeapon(WeaponUser user)
        {
            base.UnEquipWeapon(user);
            GetWeaponUsageData(user)?.weaponObject?.gameObject.SetActive(false);
        }

        public override void UseWeapon(WeaponUser user)
        {
            // Create a new bullet at the the instantiate point
            var data = GetWeaponUsageData(user);
            if (user.photonView.IsMine) 
            {
                var obj = PhotonNetwork.Instantiate(bullet.name,
                    data.weaponObject.BulletSpawnPoint.position,
                    data.raycaster.GetRotationWithoutRaycast(data.weaponObject.BulletSpawnPoint, range));
                obj.GetComponent<Bullet>().SetBulletData(damage, range);
            }
        }
    }
    public class ProjectileUsageData : WeaponUsageData 
    {
        public Transform equipPoint = null;
        public Raycaster raycaster = null;
        public GunWeaponObject weaponObject = null;
    }
}
