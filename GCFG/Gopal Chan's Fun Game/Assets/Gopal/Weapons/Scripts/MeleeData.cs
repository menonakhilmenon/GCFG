using GCFG;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    [CreateAssetMenu(menuName ="MeleeWeapon")]
    public class MeleeData : Weapon<MeleeWeaponUsageData>
    {
        [SerializeField]
        private LayerMask hitLayerMask = 0;
        [SerializeField]
        private float _range = 2f;
        public float range => _range;
        [SerializeField]
        private float _spread = 1f;
        public float spread =>_spread;
        [SerializeField]
        private MeleeWeaponObject _weaponEquipPrefab = null;

        [SerializeField]
        private ScriptableGameEvent attackHitEvent = null;

        private MeleeWeaponObject weaponEquipPrefab => _weaponEquipPrefab;


        public override void EquipWeapon(WeaponUser user)
        {
            base.EquipWeapon(user);
            var usageData = GetWeaponUsageData(user);
            if(usageData.weaponObject == null) 
            {
                if (user.photonView.IsMine) 
                {
                    usageData.equipPoint = user.localEquipPoint;
                }
                else 
                {
                    usageData.equipPoint = user.remoteEquipPoint;
                }
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
            var usageData = GetWeaponUsageData(user);
            usageData.raycaster = user.raycastOrigin.transform;
            if (user.photonView.IsMine) 
            {
                // Get all enemies in range of the sword
                Collider[] hitEnemies = Physics.OverlapBox(usageData.raycaster.position, new Vector3(spread, spread, range), usageData.raycaster.rotation, hitLayerMask);
                // Damage each enemy
                foreach (Collider enemy in hitEnemies)
                {
                    var target = enemy.GetComponent<Damageable>();
                    if (target != null) 
                    {
                        attackHitEvent?.Invoke();
                        target.TakeDamage(damage);
                    }
                }

            }
            usageData.weaponObject.UseWeapon();
        }
    }

    public class MeleeWeaponUsageData : WeaponUsageData
    {
        public Transform equipPoint = null;
        public Transform raycaster = null;
        public MeleeWeaponObject weaponObject = null;
    }
}

