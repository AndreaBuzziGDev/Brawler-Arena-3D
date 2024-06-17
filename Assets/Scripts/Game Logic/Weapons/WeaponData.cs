using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    //TODO: EMBELLISH
    //TODO: DAMAGE TYPE?


    //DAMAGE
    [SerializeField] float damageAmount = 1;
    public float DamageAmount => damageAmount;

    //OWNERSHIP
    [SerializeField] bool needsOwnerToOperate = false;
    public bool NeedsOwnerToOperate { get { return needsOwnerToOperate; } }

    //FRIENDLY FIRE
    [SerializeField] bool hasFriendlyFire = false;
    public bool HasFriendlyFire { get { return hasFriendlyFire; } }

}

