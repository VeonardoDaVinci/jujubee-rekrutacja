using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    [SerializeField] private int magazineCapacity = 0;
    private int projectilesLeft = 0;
    public override void Attack()
    {
        if(projectilesLeft == 0)
        {
            Reload();
            return;
        }
        projectilesLeft--;
        Debug.Log("Fiering weapon");
    }

    private void Reload()
    {
        Debug.Log("Reload");
        projectilesLeft = magazineCapacity;
    }
}
