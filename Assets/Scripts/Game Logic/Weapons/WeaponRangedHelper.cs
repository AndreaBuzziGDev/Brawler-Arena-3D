using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedHelper
{
    //DATA
    bool isOperating = false;
    float attackTimer = 0.0f;
    float threshold = 1;
    
    
    //DATA GETTERS
    bool ReadyToShoot { get { return attackTimer > threshold; } }
    
    
    
    
    //CONSTRUCTOR
    //TODO: THIS EVENTUALLY CAN BE MODIFIED TO HANDLE GENERALIZATION OF LOGIC
    public WeaponRangedHelper(WeaponRangedData wData){
        //
        threshold = 1.0f/wData.AttackRate;
        
    }
    
    
    //FUNCTIONALITIES
    //TODO: METHOD THAT HANDLES SHOOTING LOGIC
    //...
    public void HandleWeaponTimer(float deltaTime){
        if(!ReadyToShoot){
            attackTimer += deltaTime;
            Debug.Log("WeaponRangedHelper - attackTimer: " + attackTimer);
            Debug.Log("WeaponRangedHelper - threshold: " + threshold);
            Debug.Log("WeaponRangedHelper - readyToShoot: " + ReadyToShoot);
        }
    }
    
    

}
