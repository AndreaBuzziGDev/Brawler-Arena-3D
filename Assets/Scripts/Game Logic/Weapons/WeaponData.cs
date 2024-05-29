using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data")]
public class WeaponData : ScriptableObject
{
    //TODO: POLISH WITH MULTIPLE SUPPORTED TYPES
    //TODO: EMBELLISH

    
    //TODO: DAMAGE TYPE?
    //TODO: SPECIAL EFFECTS?
    //DAMAGE
    [SerializeField] float damageAmount = 1;
    public float DamageAmount => damageAmount;


    //PROJECTILE DATA
    [SerializeField] float projectileSpeed = 10;
    public float ProjectileSpeed => projectileSpeed;

    [SerializeField] float maxLifetime = 10;
    public float MaxLifetime => maxLifetime;

    //
    [SerializeField] bool needsOwnerToOperate = false;
    public bool NeedsOwnerToOperate { get { return needsOwnerToOperate; } }

}

