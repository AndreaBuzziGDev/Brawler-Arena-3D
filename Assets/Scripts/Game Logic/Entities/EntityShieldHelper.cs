using System.Text;
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
    public float CurrentShield => currentShield;
    public float MaxShield => maxShield;
    public float ShieldCooldownTimer => shieldCooldownTimer;
    public float MaxShieldCooldownTimer => maxShieldCooldownTimer;
    public float ShieldRechargeRate => shieldRechargeRate;



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
    public void ChangeShield(float changeAmount){
        currentShield = Mathf.Clamp(currentShield + changeAmount, 0, maxShield);
        NotifyValueChange();
        Debugger.Log(DebugProperties, LogType.ENTITY_PARAMS);
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
    
    
    //NOTIFICATION
    private void NotifyValueChange(){
        switch(entityType){
            case EntityData.EEntityType.PLAYER:
                EventManager<PlayerDamageEventArgs>.Instance.Notify(this, new PlayerDamageEventArgs(EntityDamageEventArgs.EDamageType.SHIELD, maxShield, currentShield));
                break;
            case EntityData.EEntityType.NPC:
            default:
                //EventManager<EntityDamageEventArgs>.Instance.Notify(this, new(EntityDamageEventArgs.EDamageType.SHIELD, maxHealth, currentHealth));
                break;
            
        }
    }


    //DEBUG
    public void DebugProperties(){

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("");
        sb.AppendLine("==== SHIELD HELPER START INFO ===="); //TODO: MASTER ENTITY NAME (ADD IN ENTITY DATA)

        // DATA DEBUG
        sb.AppendLine($"Entity Health Helper - currentShield: {currentShield}");
        sb.AppendLine($"Entity Health Helper - maxShield: {maxShield}");
        sb.AppendLine($"Entity Health Helper - shieldCooldownTimer: {shieldCooldownTimer}");
        sb.AppendLine($"Entity Health Helper - maxShieldCooldownTimer: {maxShieldCooldownTimer}");
        sb.AppendLine($"Entity Health Helper - shieldRechargeRate: {shieldRechargeRate}");

        // FUNCTIONS DEBUG
        sb.AppendLine($"Entity Health Helper - IsShielded: {IsShielded}");
        sb.AppendLine($"Entity Health Helper - IsWaitingRecharge: {IsWaitingRecharge}");
        sb.AppendLine($"Entity Health Helper - IsRecharging: {IsRecharging}");

        sb.AppendLine("==== SHIELD HELPER END INFO ====");

        Debug.Log(sb.ToString());
    }
}
