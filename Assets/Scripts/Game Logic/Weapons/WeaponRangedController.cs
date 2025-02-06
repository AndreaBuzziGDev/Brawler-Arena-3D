using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedController : WeaponController
{
    //INSPECTOR REFERENCES
    [Header("Inspector References")]

    [Tooltip("Reference to WeaponRangedData Scriptable Object.")]
    [SerializeField] protected WeaponRangedData wData;

    [Tooltip("Reference to the projectile Prefab.")]
    [SerializeField] WeaponProjectile projectile;//TODO: COULD/SHOULD THIS BE ON THE WEAPON DATA INSTEAD? -> PROBABLY YES


    //DATA GETTER
    override protected WeaponData WData { get { return wData; } }
    
    
    //DATA
    float attackTimer = 0.0f;
    float threshold = 1;
    
    WeaponRangedHelper logicHelper;
    
    


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
    
    void Start(){
        logicHelper = new WeaponRangedHelper(wData, this);
        threshold = 1.0f/wData.AttackRate;
    }
    
    
    //TODO: IMPLEMENT UPDATE METHOD
    //TODO: SHOULD THIS LOGIC MOVE TO FIXEDUPDATE INSTEAD, USE FIXED DELTA TIME
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
        

        //TODO: LOGIC FOR THIS CAN BE MOVED IN THE HELPER
        if(wData.OperateMode != WeaponRangedData.EOperateMode.BURST || logicHelper.IsBurstReady){
            logicHelper.IsOperating = true;
        }
    }
    
    public override void Release(){
        //TODO: LOGIC FOR THIS CAN BE MOVED IN THE HELPER
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
            projectile, 
            transform.position,
            projectile.transform.rotation
        );
        
        pInstance.ProjectileData = new WeaponProjectileData((WeaponRangedData) WData, pDirection);
    }
}
