using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    //DAMAGE
    [Tooltip("The damage dealt by operating this weapon")]
    [Range(0, 100)]
    [SerializeField] float damageAmount = 1;
    

    //OWNERSHIP
    [Tooltip("If checked, this weapon needs to be linked to an owner (EG: self-destruction)")]
    [SerializeField] bool needsOwnerToOperate = false;


    //FRIENDLY FIRE
    [Tooltip("Used for enemies. If checked, this weapon can damage other enemies")]
    [SerializeField] bool hasFriendlyFire = false;


    //DATA GETTER
    public float DamageAmount => damageAmount;
    public bool NeedsOwnerToOperate { get { return needsOwnerToOperate; } }
    public bool HasFriendlyFire { get { return hasFriendlyFire; } }
    
    //ABSTRACT DATA GETTER
    abstract public WeaponAudioData WAudioData { get; }

}

