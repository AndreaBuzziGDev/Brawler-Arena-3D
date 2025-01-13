using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedController : WeaponController
{
    //DATA
    [Header("Inspector References")]

    [Tooltip("Reference to WeaponRangedData Scriptable Object.")]
    [SerializeField] protected WeaponRangedData wData;

    [Tooltip("Reference to the projectile Prefab.")]
    [SerializeField] WeaponProjectile projectile;//TODO: COULD/SHOULD THIS BE ON THE WEAPON DATA INSTEAD? -> PROBABLY YES


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



    //LIFECYCLE FUNCTIONS
    //TODO: IMPLEMENT UPDATE METHOD
    //TODO: WEAPONS MIGHT BENEFIT FROM AN HELPER HANDLING THE DETAILS OF LOGIC, SUCH AS COOLDOWNS ETC



    //PARENT CLASS OVERRIDE
    public override void Operate()
    {
        //BASE
        base.Operate();

        //SANITY CHECK
        //TODO: IMPROVE THIS BY USING ANOTHER SOLUTION, VALIDATE SCRIPTABLE OBJECTS OR TAKE INSPIRATION FROM SOMEWHERE ELSE.
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
        switch(wData.OperateMode){
            case WeaponRangedData.EOperateMode.AUTO:
                //TODO: IMPLEMENT AUTO-SHOOTING MODE
                Debug.Log("Weapon Operate Mode: Auto NOT IMPLEMENTED");
                break;
            case WeaponRangedData.EOperateMode.CHARGED:
                //TODO: IMPLEMENT CHRGED MODE
                Debug.Log("Weapon Operate Mode: Auto NOT IMPLEMENTED");
                break;
            case WeaponRangedData.EOperateMode.SINGLE:
                Shoot();
                break;
            default:
                Debug.Log("Unhandled Pause Event");
                break;
        }
    }



    //FUNCTIONALITIES
    private void Shoot()
    {
        //SPAWN PREFAB
        Vector3 pDirection = aimingEntity.AimingDirection3D();
        WeaponProjectile pInstance = Instantiate(
            projectile, 
            transform.position,
            projectile.transform.rotation
        );
        
        pInstance.ProjectileData = new WeaponProjectileData((WeaponRangedData) WData, pDirection);
    }
}
