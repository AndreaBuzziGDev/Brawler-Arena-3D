using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageInstance
{
    //DATA
    float damageAmount = 0;


    //DATA GETTERS
    public float DamageAmount => damageAmount;


    //CONSTRUCTOR
    public DamageInstance(WeaponData weaponData)
    {
        this.damageAmount = weaponData.DamageAmount;
    }
}
