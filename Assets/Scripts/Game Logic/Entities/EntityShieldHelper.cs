using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShieldHelper
{
    //DATA
    EntityData.EEntityType entityType;

    //SHIELD
    float currentShield = 1;
    float maxShield = 1;

    //SHIELD RECHARGE
    float shieldCooldownTimer = 0;
    float maxShieldCooldownTimer = 1;
    float shieldRechargeRate = 1;


    //DATA GETTERS
    public float CurrentShield { get { return currentShield; } }
    public float MaxShield { get { return maxShield; } }
    public float ShieldCooldownTimer { get { return shieldCooldownTimer; } }
    public float MaxShieldCooldownTimer { get { return maxShieldCooldownTimer; } }
    public float ShieldRechargeRate { get { return shieldRechargeRate; } }



    //DATA FUNCTIONS
    public bool IsShielded { get { return currentShield > 0; } }
    public bool IsWaitingRecharge { get { return shieldCooldownTimer > 0; } }
    public bool IsRecharging { get { return currentShield < maxShield; } }




    //CONSTRUCTOR
    public EntityShieldHelper(EntityData data)
    {
        this.entityType = data.EntityType;
        
        this.currentShield = data.MaxShield;
        this.maxShield = data.MaxShield;
        
        this.shieldCooldownTimer = 0;
        this.maxShieldCooldownTimer = data.ShieldCooldownTimer;
        this.shieldRechargeRate = data.ShieldRechargeRate;
    }



    //FUNCTIONALITIES
    //TODO: MIGHT NOT WORK WITH DELTATIME OUTSIDE OF GAMEOBJECTS
    public void ChangeShield(float changeAmount){
        currentShield = Mathf.Clamp(currentShield + changeAmount, 0, maxShield);
        
        switch(entityType){
            case EntityData.EEntityType.PLAYER:
                EventManager<PlayerDamageEventArgs>.Instance.Notify(this, new(EntityDamageEventArgs.EDamageType.SHIELD, maxShield, currentShield));
                break;
            case EntityData.EEntityType.NPC:
            default:
                //EventManager<PlayerDamageEventArgs>.Instance.Notify(this, new(EntityDamageEventArgs.EDamageType.SHIELD, maxShield, currentShield));
                break;
            
        }
    }

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
            ChangeShield(GetShieldRecharge());
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
