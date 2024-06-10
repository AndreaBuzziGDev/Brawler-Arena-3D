using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityWithHealth : MonoBehaviour, IHittable, IAimingCapable
{
    //SCRIPTABLE OBJECTS
    //TODO: NOTIFY TO EDITOR OR GAME THAT DATA IS MISSING?
    [SerializeField] protected EntityData data;
    [SerializeField] protected EntityAudioData audioData;


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
    protected float movementSpeed = 1;//TODO: THIS HAS BECOME UNNECESSARY, CODE SHOULD BE REFACTORED


    //DATA-RELATED FUNCTIONS
    Boolean IsAlive { get { return currentHealth > 0; } }
    Boolean IsShielded { get { return currentShield > 0; } }
    Boolean IsWaitingRecharge { get { return shieldCooldownTimer > 0; } }
    Boolean IsRecharging { get { return currentShield < maxHealth; } }



    //LIFECYCLE FUNCTIONS
    protected virtual void Start()
    {
        DataInitialization();
    }

    protected virtual void Update()
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;

        if(IsAlive)
            HandleShieldAndHealthLogic();
        else
            HandleDeath();
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



    //IAimingCapable IMPLEMENTATION
    public abstract Vector2 AimingDirection();
    public abstract Vector3 AimingDirection3D();
    public abstract void SetAimTarget();




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
