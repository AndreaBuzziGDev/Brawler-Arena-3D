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
    bool isOperating = false;
    //TODO: EVENTUALLY EXPORT ATTACK RATE FUNCTIONALITY TO UPPER CLASS
    float attackTimer = 0.0f;
    bool readyToShoot = true;
    float threshold = 1;
    
    


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
        threshold = 1.0f/wData.AttackRate;
    }
    
    
    //TODO: IMPLEMENT UPDATE METHOD
    //TODO: SHOULD THIS LOGIC MOVE TO FIXEDUPDATE INSTEAD, USE FIXED DELTA TIME
    void Update(){
        
        if(!GameController.Instance.IsPlaying) return;
        if(!readyToShoot){
            //STEP 1: ADD TIMER 
            attackTimer += Time.deltaTime;
            readyToShoot = attackTimer > threshold;
            Debug.Log("WeaponRangedController - attackTimer: " + attackTimer);
            Debug.Log("WeaponRangedController - threshold: " + threshold);
            Debug.Log("WeaponRangedController - readyToShoot: " + readyToShoot);
        }

        if(!isOperating) return;
        
        //
        if(readyToShoot){
            //
            readyToShoot = false;
            attackTimer = Mathf.Max(0 + (attackTimer - threshold), 0);
            Debug.Log("WeaponRangedController - reset attackTimer: " + attackTimer);

            //TODO: WEAPONS MIGHT BENEFIT FROM AN HELPER HANDLING THE DETAILS OF LOGIC, SUCH AS COOLDOWNS ETC
            switch(wData.OperateMode){
                case WeaponRangedData.EOperateMode.AUTO:
                    //TODO: IMPLEMENT AUTO-SHOOTING MODE
                    //      AUTO SHOULD SHOOT WHILE IT'S "OPERATING"
                    Shoot();
                    break;
                case WeaponRangedData.EOperateMode.BURST:
                    //TODO: IMPLEMENT CHRGED MODE
                    //      BURST SHOULD ACT LIKE AUTO UP TO (N) TIMES
                    Debug.Log("Weapon Operate Mode: BURST NOT IMPLEMENTED");
                    break;
                case WeaponRangedData.EOperateMode.CHARGED:
                    //TODO: IMPLEMENT CHARGED MODE
                    //      CHARGED SHOULD LOAD UNTIL RELEASE HAPPENS, THEN SHOOT BASED ON HOW LONG WAS LOADED (UP TO A CAP)
                    Debug.Log("Weapon Operate Mode: CHARGED NOT IMPLEMENTED");
                    break;
                case WeaponRangedData.EOperateMode.SINGLE:
                    Shoot();
                    isOperating = false;
                    break;
                default:
                    Debug.LogWarning("Invalid Ranged Weapon Operate Mode: " + wData.OperateMode);
                    break;
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
        
        //TODO: TO ACHIEVE A BETTER IMPLEMENTATION, MIGHT BE BETTER TO HANDLE SOME INITIAL LOGIC HERE
        //TODO: EVENTUALLY MOVE THAT INITIAL LOGIC TO AN HELPER

        isOperating = true;
    }
    
    public override void Release(){
        base.Release();
        isOperating = false;
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
