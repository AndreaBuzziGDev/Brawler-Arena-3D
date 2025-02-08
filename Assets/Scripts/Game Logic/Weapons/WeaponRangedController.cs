using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedController : WeaponController
{
    //INSPECTOR REFERENCES
    [Header("Inspector References")]

    [Tooltip("Reference to WeaponRangedData Scriptable Object.")]
    [SerializeField] protected WeaponRangedData wData;


    //DATA GETTER
    override protected WeaponData WData { get { return wData; } }
    
    
    //DATA
    float attackTimer = 0.0f;
    float threshold = 1;
    
    WeaponRangedHelper logicHelper;




    //LIFECYCLE FUNCTIONS
    
    void Start(){
        logicHelper = new WeaponRangedHelper(wData, this);
        threshold = 1.0f/wData.AttackRate;
    }
    
    
    
    void FixedUpdate(){
        
        if(!GameController.Instance.IsPlaying) return;
        
        logicHelper.HandleWeaponTimer(Time.fixedDeltaTime);

        if(!logicHelper.IsOperating) return;
        
        if(logicHelper.ReadyToShoot && logicHelper.HandleShooting()){
            for(int i = 0; i <= logicHelper.GetExtraBulletCount; i++){
                Shoot();
            }
        }
    }



    //PARENT CLASS OVERRIDE
    public override void Operate()
    {
        if(wData.OperateMode != WeaponRangedData.EOperateMode.BURST || logicHelper.IsBurstReady){
            logicHelper.IsOperating = true;
        }
    }
    
    public override void Release(){
        if(wData.OperateMode != WeaponRangedData.EOperateMode.BURST){
            base.Release();
            logicHelper.IsOperating = false;
        }
    }



    //FUNCTIONALITIES
    private void Shoot()
    {
        //
        base.Operate();

        //SPAWN PREFAB
        Vector3 pDirection = aimingEntity.AimingDirection3D();
        WeaponProjectile pInstance = Instantiate(
            wData.Projectile, 
            transform.position,
            wData.Projectile.transform.rotation
        );
        
        pInstance.ProjectileData = new WeaponProjectileData((WeaponRangedData) WData, pDirection);
    }
}
