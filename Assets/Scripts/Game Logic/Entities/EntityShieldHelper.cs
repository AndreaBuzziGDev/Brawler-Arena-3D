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
    
    
    
    //DATA GETTERS
    public float CurrentShield { get { return currentShield; } }
    public float MaxShield { get { return maxShield; } }
    public float ShieldCooldownTimer { get { return shieldCooldownTimer; } }
    public float MaxShieldCooldownTimer { get { return maxShieldCooldownTimer; } }
    public float ShieldRechargeRate { get { return shieldRechargeRate; } }


    //DATA FUNCTIONS





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
    
    
}
