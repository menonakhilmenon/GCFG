using bilalAdarsh;
using GCFG;
using Gopal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Potion : Item
{
    [SerializeField]
    private float regenHP = 50f;
    [SerializeField]
    private FloatEvent regenEvent = null;
    public override bool IsUsable => true;

    public override void UseItem()
    {
        if (PlayerManager.instance.LocalPlayerInventory.TryRemove(this, 1)) 
        {
            PlayerManager.instance.LocalPlayerInventory.RemoveItem(this, 1);
            regenEvent?.InvokeWithFloat(regenHP);
        }
    }
}
