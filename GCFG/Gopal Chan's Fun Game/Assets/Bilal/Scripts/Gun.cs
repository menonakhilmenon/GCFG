using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gopal;

public class Gun : MonoBehaviour
{
    public ProjectileData gunData;
    public WeaponUser user;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gunData.model, transform.position, transform.rotation,transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunData.useWeapon(user);
        }
    }
}
