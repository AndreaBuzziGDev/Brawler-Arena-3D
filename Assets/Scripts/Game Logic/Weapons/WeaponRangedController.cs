using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedController : WeaponController
{
    //INSPECTOR REFERENCES
    //TODO: ENFORCE "wType" AS PROJECTILE/RANGED?

    [SerializeField] WeaponProjectile projectile;
    
    //FUNCTIONALITIES
    //TODO: IS IT OVERKILL TO MAKE THIS PRIVATE AND EXECUTE THIS VIA EVENT?
    public override void Operate(){

        if(!projectile)
        {
            Debug.LogError("No Projectile on weapon: " + gameObject.name);
            return;
        }
        
        //SPAWN PREFAB
        //TODO: IMPROVE/FIX PROJECTILE SHOOTING BY FOLLOWING GUIDE
        Vector3 pDirection = ShootingDirection();
        Debug.Log("Value 1: " + Quaternion.Euler(ShootingDirection()));
        Debug.Log("Value 2: " + projectile.transform.rotation);

        WeaponProjectile pInstance = Instantiate(
            projectile, 
            transform.position,
            projectile.transform.rotation
        );
        pInstance.ProjectileData = new WeaponProjectileData(weaponData, pDirection);
    }
    
    //UTILITIES
    //TODO: SOLVE ISSUE WITH 
    public Vector3 ShootingDirection() => new Vector3(lastDirection2D.x, 0, lastDirection2D.y).normalized;
}
