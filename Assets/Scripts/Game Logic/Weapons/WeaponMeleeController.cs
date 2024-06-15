using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMeleeController : WeaponController
{
    public override void Operate(){
        base.Operate();
        //TODO: IMPLEMENT
        Debug.Log("Melee Weapon " + gameObject.name + " Yet to be implemented");
    }
}
