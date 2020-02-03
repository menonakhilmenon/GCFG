using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gopal
{
    public class Damageable : MonoBehaviour
    {
        public Action<int> OnTakeDamage;
    }
}
