using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponAttributes", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string name;
    public float range;
    public AttackTypes[] attacks;
}

