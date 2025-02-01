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
        Debugger.Log(DebugProperties);
        
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
        
        //TODO: USE ADVANCED DEBUG FUNCTIONALITY
        //1) DEBUG WILL BE DONE VIA DELEGATES
        //THIS METHOD WILL BE ONE OF SAID DELEGATES
        
        
        //2) Debugger WILL DO A NUMBER OF FLOW/LOGIC CONTROLS TO DETERMINE WETHER THE DELEGATE WILL BE EXECUTED
        
        //3) THESE CONTROLS WILL BE AIDED VIA CONFIGURATIONS SET IN THE DebuggerConfig CLASS.
        //THESE CONFIGURATIONS WILL BE HANDLED AS FLAGS/MULTI-SELECT PICKLISTS IN THE EDITOR.
        
        //4) IF NECESSARY, DEBUGGERCONFIGS WILL BE CHANGED TO BE/USE ScriptableObjects INSTEAD OF JUST CODE, IN ORDER TO MAKE CONFIGS REUSABLE.

        //5) THE DEBUGGER WILL RECEIVE IN INPUT A PARAMETER THAT THE INVOKING CLASS (This one...) WILL PROVIDE IN ORDER TO ACKNOWLEDGE CONTEXT
        //THIS "CONTEXT" WILL BE AN OPTIONAL PARAMETER.
        //BY DEFAULT IT WILL BE A "FALLBACK" CONTEXT, WHICH WILL NORMALLY BE DEBUGGED (CAN BE SET TO FALSE, THOUGH, IN SETUP)

        //6) WEAPONS WILL SUPPORT PRECISE DEBUGS, MEANING THAT IF NECESSARY, A DEBUG FOR A SPECIFIC WEAPON INSTANCE CAN BE ACHIEVED VIA INSPECTOR MODIFICATIONS
        //SO IT'S SUPPOSED TO BE AN INSTANCE/MONOBEHAVIOUR CONFIG
        
    }

}
