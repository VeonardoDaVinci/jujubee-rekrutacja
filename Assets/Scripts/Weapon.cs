using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public string WeaponName { get; protected set; }
    [field: SerializeField] public float WeaponDamage { get; protected set; }
    public abstract void Attack();
    public Weapon Equip()
    {
        gameObject.SetActive(true);
        return this;
    }
    public Weapon Unequip()
    {
        gameObject.SetActive(false);
        return this;
    }
}
