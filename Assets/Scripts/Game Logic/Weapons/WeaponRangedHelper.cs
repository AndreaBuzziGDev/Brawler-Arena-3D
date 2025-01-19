using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedHelper
{
    //DATA
    float attackTimer = 0.0f;
    float threshold = 1;
    WeaponRangedData.EOperateMode operateMode;

    
    //DATA FUNCTIONS
    public bool IsOperating { get; set; }
    public bool ReadyToShoot { get { return attackTimer >= threshold; } }
    
    
    
    
    //CONSTRUCTOR
    //TODO: THIS EVENTUALLY CAN BE MODIFIED TO HANDLE GENERALIZATION OF LOGIC
    public WeaponRangedHelper(WeaponRangedData wData){
        //TODO: IMPLEMENT DEFAULTING WHEN wData IS NOT PROVIDED
        threshold = 1.0f/wData.AttackRate;
        attackTimer = threshold;
        operateMode = wData.OperateMode;
    }
    
    
    //FUNCTIONALITIES
    public void HandleWeaponTimer(float deltaTime){
        if(!ReadyToShoot){
            attackTimer += deltaTime;
            //DebugProperties();
        }
    }
    
    
    public bool HandleShooting(){
        attackTimer = Mathf.Max(0 + (attackTimer - threshold), 0);
        Debug.Log("WeaponRangedController - reset attackTimer: " + attackTimer);
        
        bool result = false;
        switch(operateMode){
            case WeaponRangedData.EOperateMode.AUTO:
                //AUTO SHOULD SHOOT WHILE IT'S "OPERATING"
                result = true;
                break;
            case WeaponRangedData.EOperateMode.BURST:
                //TODO: IMPLEMENT BURST MODE
                
                //BURST SHOULD ACT LIKE AUTO UP TO (N) TIMES
                Debug.Log("Weapon Operate Mode: BURST NOT IMPLEMENTED");
                break;
            case WeaponRangedData.EOperateMode.CHARGED:
                //TODO: IMPLEMENT CHARGED MODE
                
                //CHARGED SHOULD LOAD UNTIL RELEASE HAPPENS, THEN SHOOT BASED ON HOW LONG WAS LOADED (UP TO A CAP)
                Debug.Log("Weapon Operate Mode: CHARGED NOT IMPLEMENTED");
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
    }

}
