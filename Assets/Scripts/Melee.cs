using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private float attackRange = 1f;
    public override void Attack()
    {
        Debug.Log("Doing melee attack with a "+WeaponName +" for " + WeaponDamage + " damage.");
    }
}
