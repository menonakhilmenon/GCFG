using bilalAdarsh;
using Gopal;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class LocalPlayer : MonoBehaviour
    {
        [SerializeField]
        private PhotonView photonView = null;
        [SerializeField]
        private Damageable _localDamageable = null;
        [SerializeField]
        private Inventory _inventory = null;
        [SerializeField]
        private WeaponUser _weaponUser = null;

        [SerializeField]
        private FloatEvent healthUpdateEvent = null;

        [SerializeField]
        private Health _health = null;

        public Health health => _health;
        public Damageable damageable => _localDamageable;
        public Inventory inventory => _inventory;
        public WeaponUser weaponUser => _weaponUser;


        private void OnEnable()
        {
            if (!photonView.IsMine) 
            {
                enabled = false;
                return;
            }
            PlayerManager.instance.LocalPlayerObject = this;
        }

        public void CheckHealth(float healthUpdate) 
        {
            if (photonView.IsMine) 
            {
                healthUpdateEvent?.InvokeWithFloat(healthUpdate);
            }
        }
    }
}