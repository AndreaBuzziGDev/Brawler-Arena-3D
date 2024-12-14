using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShieldHelper
{
    //DATA

    //SHIELD
    float currentShield = 1;
    float maxShield = 1;

    //SHIELD RECHARGE
    float shieldCooldownTimer = 0;
    float maxShieldCooldownTimer = 1;
    float shieldRechargeRate = 1;



    //DATA FUNCTIONS
    public bool IsShielded { get { return currentShield > 0; } }
    public bool IsWaitingRecharge { get { return shieldCooldownTimer > 0; } }
    public bool IsRecharging { get { return currentShield < maxShield; } }




    //CONSTRUCTOR
    public EntityShieldHelper(EntityData data)
    {
        currentShield = data.MaxShield;
        maxShield = data.MaxShield;

        shieldCooldownTimer = 0;
        maxShieldCooldownTimer = data.ShieldCooldownTimer;
        shieldRechargeRate = data.ShieldRechargeRate;
    }



    //FUNCTIONALITIES
    //TODO: MIGHT NOT WORK WITH DELTATIME OUTSIDE OF GAMEOBJECTS
    public void DamageShield(float damageAmount) => currentShield = Mathf.Clamp(currentShield - damageAmount, 0, maxShield);
    public void RechargeShield(float rechargedAmount) => currentShield = Mathf.Clamp(currentShield + rechargedAmount, 0, maxShield);
    public float GetShieldRecharge() => Time.deltaTime * shieldRechargeRate;
    public void DepleteShieldTimer() => shieldCooldownTimer = Mathf.Clamp(shieldCooldownTimer - Time.deltaTime, 0, maxShieldCooldownTimer);
    public void ResetShieldTimer() => shieldCooldownTimer = maxShieldCooldownTimer;



    //COMPOSITE FUNCTIONALITIES
    public void HandleLogic()
    {
        //
        if(IsWaitingRecharge)
            DepleteShieldTimer();
        else if(IsRecharging)
            RechargeShield(GetShieldRecharge());
    }


    //DEBUG
    public void PrintDebug()
    {
        //DATA DEBUG
        Debug.Log("currentShield: " + currentShield);
        Debug.Log("maxShield: " + maxShield);
        Debug.Log("shieldCooldownTimer: " + shieldCooldownTimer);
        Debug.Log("maxShieldCooldownTimer: " + maxShieldCooldownTimer);
        Debug.Log("shieldRechargeRate: " + shieldRechargeRate);

        //FUNCTIONS DEBUG
        Debug.Log("IsShielded: " + IsShielded);
        Debug.Log("IsWaitingRecharge: " + IsWaitingRecharge);
        Debug.Log("IsRecharging: " + IsRecharging);
    }
}
