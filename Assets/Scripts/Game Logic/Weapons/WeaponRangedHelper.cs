using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedHelper
{
    //DATA
    float attackTimer = 0.0f;
    float threshold = 1;
    
    ///BURST LOGIC
    int burstCountMax = 0;
    int burstCount = 0;
    float burstCooldownMax = 0.5f;
    float burstCooldown = 0.0f;
    
    ///CHARGE LOGIC
    
    
    WeaponRangedData.EOperateMode operateMode;

    
    //DATA FUNCTIONS
    public bool IsOperating { get; set; }
    public bool ReadyToShoot { get { return attackTimer >= threshold; } }
    public bool IsBursting { get { return burstCountMax > burstCount; } }
    public bool IsBurstReady { get { return burstCooldown > burstCooldownMax; } }
    
    
    
    
    //CONSTRUCTOR
    //TODO: THIS EVENTUALLY CAN BE MODIFIED TO HANDLE GENERALIZATION OF LOGIC
    public WeaponRangedHelper(WeaponRangedData wData){
        //TODO: IMPLEMENT DEFAULTING WHEN wData IS NOT PROVIDED
        operateMode = wData.OperateMode;
        
        //TODO: THRESHOLD MIGHT NEED TO BE ADJUSTED SPECIFICALLY FOR BURST GAMEPLAY IN ORDER TO MAKE BURST WEAPONS SHOOT FASTER
        threshold = 1.0f/wData.AttackRate;
        attackTimer = threshold;
        
        burstCountMax = wData.BurstCount;
        burstCooldownMax = wData.BurstCooldown;
        burstCooldown = burstCooldownMax;
    }
    
    
    //FUNCTIONALITIES
    public void HandleWeaponTimer(float deltaTime){
        if(!ReadyToShoot){
            attackTimer += deltaTime;
        }
        if(!IsBurstReady){
            burstCooldown += deltaTime;
        }
        //DebugProperties();
    }
    
    
    public bool HandleShooting(){
        
        attackTimer = Mathf.Max(0 + (attackTimer - threshold), 0);
        bool result = false;
        
        switch(operateMode){
            case WeaponRangedData.EOperateMode.AUTO:
                //AUTO SHOULD SHOOT WHILE IT'S "OPERATING"
                result = true;
                break;
            case WeaponRangedData.EOperateMode.BURST:
                //BURST SHOULD ACT LIKE AUTO UP TO (N) TIMES
                result = true;
                burstCount++;
                if(!IsBursting){
                    IsOperating = false;
                    burstCount = 0;
                    burstCooldown = 0.0f;
                }
                break;
            case WeaponRangedData.EOperateMode.CHARGED:
                //TODO: IMPLEMENT CHARGED MODE
                
                //CHARGED SHOULD LOAD UNTIL RELEASE HAPPENS, THEN SHOOT BASED ON HOW LONG WAS LOADED (UP TO A CAP)
                Debug.LogWarning("Weapon Operate Mode: CHARGED NOT IMPLEMENTED");
                break;
            case WeaponRangedData.EOperateMode.SINGLE:
                result = true;
                IsOperating = false;
                break;
            default:
                Debug.LogWarning("Invalid Ranged Weapon Operate Mode: " + operateMode);
                break;
        }
        
        return result;
    }
    
    
    
    
    //DEBUG
    public void DebugProperties(){
        Debug.Log("WeaponRangedHelper - attackTimer: " + attackTimer);
        Debug.Log("WeaponRangedHelper - threshold: " + threshold);
        Debug.Log("WeaponRangedHelper - readyToShoot: " + ReadyToShoot);
        
        //TODO: ADD DEBUG FOR OTHER PROPERTIES BASED ON OPERATE MODE
    }

}
