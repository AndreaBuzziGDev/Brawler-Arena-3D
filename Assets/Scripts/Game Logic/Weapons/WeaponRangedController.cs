using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedController : WeaponController
{
    //INSPECTOR REFERENCES
    [SerializeField] WeaponProjectile projectile;
    [SerializeField] protected WeaponRangedData wData;


    //DATA GETTER
    override protected WeaponData WData { get { return wData; } }


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        if (projectile == null)
            Debug.LogWarning("No Ranged Weapon Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //FUNCTIONALITIES
    public override void Operate()
    {
        //BASE
        base.Operate();

        //SANITY CHECK
        if(!projectile)
        {
            Debug.LogError("No Projectile on weapon: " + gameObject.name);
            return;
        }
        else if(!aimingEntity)
        {
            Debug.LogError("No Aiming Entity on weapon: " + gameObject.name);
            return;
        }
        
        //
        Shoot();
    }


    private void Shoot()
    {
        //SPAWN PREFAB
        //TODO: IMPROVE/FIX PROJECTILE SHOOTING BY FOLLOWING GUIDE
        Vector3 pDirection = aimingEntity.AimingDirection3D();
        WeaponProjectile pInstance = Instantiate(
            projectile, 
            transform.position,
            projectile.transform.rotation
        );

        //TODO: IMPROVE VISIBILITY ISSUES WITH PROJECTILE DATA
        pInstance.ProjectileData = new WeaponProjectileData((WeaponRangedData) WData, pDirection);
    }
}
