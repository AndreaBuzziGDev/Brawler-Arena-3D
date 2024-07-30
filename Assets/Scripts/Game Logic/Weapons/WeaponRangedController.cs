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
        //      THE ONLY PLAUSIBLE FIX TO THIS ISSUE IS MOVING WeaponProjectileData CREATION INTO WeaponProjectile 
        //      THIS IS ACHIEVED BY IMPLEMENTING A WeaponRangedData VARIABLE DIRECTLY INTO WeaponProjectile AND SET UP PREFABS ACCORDINGLY.
        //      IT ALSO IS THE BEST SOLUTION AS, IN THIS WAY, THE SAME WEAPON MIGHT SHOOT DIFFERENT PROJECTILES, WITHOUT HAVING TO DO MULTIPLE WEAPONS.
        //      THE ISSUE MIGHT REMAIN WITH pDirection, BUT NOT IN A WAY THAT IS HARMFUL TO THE OVERALL CODE.
        //      ALSO THIS SOLUTION SHOULD BE WAY BETTER WHEN IT COMES TO HANDLING POOLING OF OBJECTS.
        pInstance.ProjectileData = new WeaponProjectileData((WeaponRangedData) WData, pDirection);
    }
}
