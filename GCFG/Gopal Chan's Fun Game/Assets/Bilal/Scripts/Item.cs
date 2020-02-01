using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public enum Type { Wood, Stone, Gold, Weapon };
    public Type resourceType;
    public float weight;
}
