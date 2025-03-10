using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMeleeController : WeaponController
{
    //DATA
    [Header("Inspector References")]
    [Tooltip("Reference to WeaponMeleeData Scriptable Object.")]
    [SerializeField] protected WeaponMeleeData wData;


    //DATA GETTER
    override protected WeaponData WData { get { return wData; } }


    //FUNCTIONALITIES
    public override void Operate(){
        base.Operate();
        //TODO: IMPLEMENT
        //TODO: USE UNIFIED DEBUG?
        Debug.Log("Melee Weapon " + gameObject.name + " Yet to be implemented");
    }
}
