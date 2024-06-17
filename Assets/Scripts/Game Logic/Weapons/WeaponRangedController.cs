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


    //FUNCTIONALITIES
    //TODO: IS IT OVERKILL TO MAKE THIS PRIVATE AND EXECUTE THIS VIA EVENT?
    public override void Operate()
    {
        base.Operate();

        //UNBOUND AUDIO EMISSION

        if(!projectile)
        {
            Debug.LogError("No Projectile on weapon: " + gameObject.name);
            return;
        }
        
        //SPAWN PREFAB
        //TODO: IMPROVE/FIX PROJECTILE SHOOTING BY FOLLOWING GUIDE
        Vector3 pDirection = ownerEntity.AimingDirection3D();
        WeaponProjectile pInstance = Instantiate(
            projectile, 
            transform.position,
            projectile.transform.rotation
        );

        //TODO: IMPROVE VISIBILITY ISSUES WITH PROJECTILE DATA
        pInstance.ProjectileData = new WeaponProjectileData(WData, pDirection);
    }

}
