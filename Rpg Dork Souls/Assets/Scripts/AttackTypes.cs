using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "attacksAttributes", menuName = "AttacksType")]
public class AttackTypes : ScriptableObject
{
    public int attackDamage_min;
    public int attackDamage_max;
    public int attackDamage_critical;    
}
