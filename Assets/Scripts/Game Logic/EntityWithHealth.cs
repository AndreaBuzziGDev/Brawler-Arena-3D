using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityWithHealth : MonoBehaviour, IHittable
{
    //SCRIPTABLE OBJECTS
    //TODO: NOTIFY TO EDITOR OR GAME THAT DATA IS MISSING?
    [SerializeField] PlayerCharacterData data;


    //DATA
    //TODO: HEALTH AND SHIELD ARCHITECTURE COULD BE IMPLEMENTED VIA A HELPER
    //HEALTH
    float currentHealth = 1;
    float maxHealth = 1;

    //SHIELD
    float currentShield = 1;
    float maxShield = 1;

    //SHIELD RECHARGE
    float shieldCooldownTimer = 0;
    float maxShieldCooldownTimer = 1;
    float shieldRechargeRate = 1;
    
    //SPEED
    float movementSpeed = 1;


    //DATA-RELATED FUNCTIONS
    Boolean IsAlive { get { return currentHealth > 0; } }
    Boolean IsShielded { get { return currentShield > 0; } }
    Boolean IsWaitingRecharge { get { return shieldCooldownTimer > 0; } }
    Boolean IsRecharging { get { return currentShield < maxHealth; } }



    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    protected virtual void Start()
    {
        DataInitialization();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(IsAlive)
        {
            HandleShieldAndHealthLogic();
        }
        else
        {
            //TODO: FIRE DEATH EVENT
            
        }
    }

    //INITIALIZATION
    public void DataInitialization()
    {
        currentHealth = data.MaxHealth;
        maxHealth = data.MaxHealth;//TODO: MIGHT ADDRESS DIRECTLY THE PROPERTY FROM THE SCRIPTABLE OBJECTS IN THESE CASES

        currentShield = data.MaxShield;
        maxShield = data.MaxShield;

        shieldCooldownTimer = 0;
        maxShieldCooldownTimer = data.ShieldCooldownTimer;
        shieldRechargeRate = data.ShieldRechargeRate;

        movementSpeed = data.MovementSpeed;
        currentHealth = data.MaxHealth;
    }




    //IHittable INTERFACE IMPLEMENTATION
    public void HandleHit(DamageInstance dInstance)
    {
        Debug.Log(gameObject.name + " has been Hit for " + dInstance.DamageAmount + " Damage.");
        ReceiveDamage(dInstance.DamageAmount);
    }

    public abstract void HandleDeath();




    //HEALTH AND SHIELD FUNCTIONALITIES
    public void ReceiveDamage(float damageAmount)
    {
        if(IsShielded)
            DamageShield(damageAmount);
        else
            DamageHealth(damageAmount);
        
        //SHIELD RECHARGE STUFF
        shieldCooldownTimer = data.ShieldCooldownTimer;
    }
    private void DamageHealth(float damageAmount) => currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);


    private void DamageShield(float damageAmount) => currentShield = Mathf.Clamp(currentShield - damageAmount, 0, maxShield);
    private float GetShieldRecharge() => Time.deltaTime * shieldRechargeRate;
    private void RechargeShield(float rechargedAmount) => currentShield = Mathf.Clamp(currentShield + rechargedAmount, 0, maxShield);
    private void DepleteShieldTimer() => shieldCooldownTimer = Mathf.Clamp(shieldCooldownTimer - Time.deltaTime, 0, maxShieldCooldownTimer);

    protected void HandleShieldAndHealthLogic()
    {
        //
        if(IsWaitingRecharge)
            DepleteShieldTimer();
        else if(IsRecharging)
            RechargeShield(GetShieldRecharge());
    }
}
