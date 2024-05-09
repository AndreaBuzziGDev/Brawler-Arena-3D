using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //SCRIPTABLE OBJECTS
    //TODO: NOTIFY TO EDITOR OR GAME THAT DATA IS MISSING?
    [SerializeField] PlayerCharacterData data;


    //INPUT
    GameInputAction inputPlayer = new GameInputAction();

    //DATA
    //HEALTH
    int currentHealth = 1;
    int maxHealth = 1;

    //SHIELD
    float currentShield = 1;
    int maxShield = 1;

    //SHIELD RECHARGE
    float shieldCooldownTimer = 0;
    int maxShieldCooldownTimer = 1;
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
    void Start()
    {
        //LISTEN TO INPUTS
        InputInitialization();
        
        //INITIALIZE PARAMS BASED ON DATA
        DataInitialization();
        
        //

    }

    // Update is called once per frame
    void Update()
    {
        if(IsAlive)
        {
            HandleShieldAndHealthLogic();
        }
        else
        {
            //TODO: FIRE GAME OVER EVENT
            
        }

        //TODO: HANDLE MOVEMENT
    }

    
    //FUNCTIONALITIES
    void InputInitialization()
    {
        inputPlayer.Enable();

        //TODO: HANDLE THE VARIOUS INPUTS

    }

    void DataInitialization()
    {
        currentHealth = data.MaxHealth;
        maxHealth = data.MaxHealth;

        currentShield = data.MaxShield;
        maxShield = data.MaxShield;

        shieldCooldownTimer = 0;
        maxShieldCooldownTimer = data.ShieldCooldownTimer;
        shieldRechargeRate = data.ShieldRechargeRate;

        movementSpeed = data.MovementSpeed;
        currentHealth = data.MaxHealth;
    }
    



    //INPUT HANDLING
    void UseMovement()
    {
        //TODO: DEVELOP

    }

    void UseRotation()
    {
        //TODO: DEVELOP

    }

    void UseAttackMelee()
    {
        //TODO: DEVELOP

    }

    void UseAttackRanged()
    {
        //TODO: DEVELOP

    }

    void UseAbility()
    {
        //TODO: DEVELOP

    }



    //HEALTH AND SHIELD METHODOLOGY
    //TODO: DEVELOP AND INTEGRATE AN INTERFACE FOR EVERYTHING THAT CAN BE HIT
    public void ReceiveDamage(int damageAmount)
    {
        if(IsShielded)
            DamageShield(damageAmount);
        else
            DamageHealth(damageAmount);
        
        //SHIELD RECHARGE STUFF
        shieldCooldownTimer = data.ShieldCooldownTimer;
    }
    private void DamageHealth(int damageAmount) => currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);


    private void DamageShield(int damageAmount) => currentShield = Mathf.Clamp(currentShield - damageAmount, 0, maxShield);
    private float GetShieldRecharge() => Time.deltaTime * shieldRechargeRate;
    private void RechargeShield(float rechargedAmount) => currentShield = Mathf.Clamp(currentShield + rechargedAmount, 0, maxShield);
    private void DepleteShieldTimer() => shieldCooldownTimer = Mathf.Clamp(shieldCooldownTimer - Time.deltaTime, 0, maxShieldCooldownTimer);


    private void HandleShieldAndHealthLogic()
    {
        //
        if(IsWaitingRecharge)
            DepleteShieldTimer();
        else if(IsRecharging)
            RechargeShield(GetShieldRecharge());
    }


    //UTILITIES
    //TODO: DEVELOP AND INTEGRATE AN INTERFACE FOR EVERYTHING THAT CAN BE HIT
    //TODO: CHANGE METHOD SIGNATURE (EMPLOY AN ENTITY THAT CAN TRANSFER ALL DAMAGE-RELATED DATA)
    public void GetHit()
    {
        //TODO: DEVELOP
        //TODO: USE ReceiveDamage(int damageAmount)
    }

}
