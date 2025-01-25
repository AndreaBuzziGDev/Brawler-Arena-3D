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
    float chargeTimerMax = 1.0f;
    float chargeTimer = 0.0f;
    float chargeRate = 1.0f;
    
    
    
    WeaponRangedData.EOperateMode operateMode;

    
    //DATA FUNCTIONS
    public bool IsOperating { get; set; }
    public bool ReadyToShoot { get { return attackTimer >= threshold; } }
    public float GetExtraBulletCount { get { return Mathf.Max((int)((attackTimer / threshold)-1), 0); } }
    public bool IsBursting { get { return burstCountMax > burstCount; } }
    public bool IsBurstReady { get { return burstCooldown > burstCooldownMax; } }
    public bool IsCharged { get { return chargeTimer > chargeTimerMax; } }
    
    
    
    
    //CONSTRUCTOR
    //TODO: THIS EVENTUALLY CAN BE MODIFIED TO HANDLE GENERALIZATION OF LOGIC
    public WeaponRangedHelper(WeaponRangedData wData){
        
        operateMode = wData?.OperateMode ?? WeaponRangedData.EOperateMode.SINGLE;
        
        //TODO: THRESHOLD MIGHT NEED TO BE ADJUSTED SPECIFICALLY FOR BURST GAMEPLAY IN ORDER TO MAKE BURST WEAPONS SHOOT FASTER
        threshold = 1.0f/wData.AttackRate;
        attackTimer = threshold;
        
        burstCountMax = wData.BurstCount;
        burstCooldownMax = wData.BurstCooldown;
        burstCooldown = burstCooldownMax;

        chargeTimerMax = wData.ChargeTime;
        chargeRate = wData.AttackRate;
    }
    
    
    //FUNCTIONALITIES
    public void HandleWeaponTimer(float deltaTime){
        if(!ReadyToShoot){
            attackTimer += deltaTime;
        }
        if(!IsBurstReady){
            burstCooldown += deltaTime;
        }
        if(IsOperating && operateMode == WeaponRangedData.EOperateMode.CHARGED){
            chargeTimer += (deltaTime * chargeRate);
        } else {
            chargeTimer = 0.0f;
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
                //CHARGED SHOULD LOAD UNTIL A CHARGE TIMER HAS BEEN REACHED, THEN RELASE SHOT
                if(IsCharged){
                    result = true;
                    IsOperating = false;
                    chargeTimer = 0.0f;
                    attackTimer = 0.0f;
                }
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
        Debugger.Log("WeaponRangedHelper - attackTimer: " + attackTimer);
        Debugger.Log("WeaponRangedHelper - threshold: " + threshold);
        Debugger.Log("WeaponRangedHelper - readyToShoot: " + ReadyToShoot);
        
        //TODO: ADD DEBUG FOR OTHER PROPERTIES BASED ON OPERATE MODE
        
        //TODO: USE A UNIFIED DEBUGGER
        //WIP THIS NOW
        //1) UNIFIED DEBUGGER MUST WORK ALWAYS
        //2) IF DEBUGGER HAS NOT BEEN INSTANCIATED, ONE IS ADDED TO THE SCENE AS SOON AS UNIFIED DEBUGGING IS ATTEMPTED
        //3) IF POSSIBLE, INSTANTIATE/USE A MONOSINGLETON 
        
    }

}
