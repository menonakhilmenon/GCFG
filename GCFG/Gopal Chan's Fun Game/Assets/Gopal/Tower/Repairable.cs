using bilalAdarsh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class Repairable : MonoBehaviour
    {
        public Action<Dictionary<Item.Type, int>> onRepairTower;
    }

}
