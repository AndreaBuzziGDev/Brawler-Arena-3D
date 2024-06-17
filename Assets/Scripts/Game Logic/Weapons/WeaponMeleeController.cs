using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMeleeController : WeaponController
{
    
    //INSPECTOR REFERENCES
    [SerializeField] protected WeaponMeleeData wData;


    //DATA GETTER
    override protected WeaponData WData { get { return wData; } }


    //FUNCTIONALITIES
    public override void Operate(){
        base.Operate();
        //TODO: IMPLEMENT
        Debug.Log("Melee Weapon " + gameObject.name + " Yet to be implemented");
    }

}
