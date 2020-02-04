using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gopal;
using System;

public class WeaponContainer : MonoBehaviour
{
    [SerializeField]
    private WeaponData weapon = null;
    [SerializeField]
    private WeaponUser user = null;

    private DateTime lastUsage = DateTime.Now;



    public void UseWeapon() 
    {
        if((DateTime.Now - lastUsage).TotalSeconds >= weapon.weaponCooldown) 
        {
            weapon.UseWeapon(user);
            lastUsage = DateTime.Now;
        }
    }
}
