using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gopal
{
    public class GunWeaponObject : MonoBehaviour
    {
        [SerializeField]
        private Transform bulletSpawnPoint = null;
        public Transform BulletSpawnPoint => bulletSpawnPoint;

    }
}