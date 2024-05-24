using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileData
{
    //DATA
    private DamageInstance dInstance;

    private float lifetime = 0.0f;
    private float maxLifetime = 10;

    private float projectileSpeed = 1.0f;
    private Vector3 direction = Vector3.up;


    //DATA GETTERS
    public DamageInstance DamageInstance => dInstance;

    public float MaxLifetime => maxLifetime;
    public bool HasExpired => lifetime >= maxLifetime;

    public float Speed => projectileSpeed;
    public Vector3 Direction => direction;



    //CONSTRUCTOR
    public WeaponProjectileData(WeaponData wData, Vector3 pDirection)
    {
        this.dInstance = new DamageInstance(wData);
        this.maxLifetime = wData.MaxLifetime;
        this.projectileSpeed = wData.ProjectileSpeed;
        this.direction = pDirection;
    }


    //FUNCTIONALITIES
    public void HandleLifetime(float lifetimeChange)
    {
        lifetime += lifetimeChange;
    }
}
