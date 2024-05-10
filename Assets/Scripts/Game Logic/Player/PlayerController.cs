using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //SCRIPTABLE OBJECTS
    //TODO: NOTIFY TO EDITOR OR GAME THAT DATA IS MISSING?
    [SerializeField] PlayerCharacterData data;


    //INPUT
    GameInputAction inputPlayer;

    //DATA

    //TODO: HEALTH AND SHIELD ARCHITECTURE COULD BE IMPLEMENTED VIA A HELPER
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
    void Start()
    {
        //LISTEN TO INPUTS
        InputInitialization();
        
        //INITIALIZE PARAMS BASED ON DATA
        DataInitialization();
        
        //

    }


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


    void OnDestroy()
    {
        InputTermination();
    }

    
    //FUNCTIONALITIES
    void DataInitialization()
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
    



    //INPUT FUNCTIONS
    void InputInitialization()
    {
        inputPlayer = new GameInputAction();
        inputPlayer.Enable();

        //TODO: HANDLE THE VARIOUS INPUTS
        inputPlayer.BaseActionMap.DirectionalMovement.performed += UseMovement;
        inputPlayer.BaseActionMap.DirectionalRotation.performed += UseRotation;

    }

    void InputTermination()
    {
        inputPlayer.Disable();

        //TODO: HANDLE THE VARIOUS INPUTS
        inputPlayer.BaseActionMap.DirectionalMovement.performed -= UseMovement;
        inputPlayer.BaseActionMap.DirectionalRotation.performed -= UseRotation;
    }

    //INPUT HANDLING
    void UseMovement(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP
        Debug.Log("UseMovement - value: " + value.ReadValue<Vector2>());
    }

    void UseRotation(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP
        Debug.Log("UseRotation - value: " + value.ReadValue<Vector2>());
        Debug.Log("UseRotation - Last Mouse Position: " + Mouse.current.position.value.normalized);
        lastValueInput = value.ReadValue<Vector2>().normalized;
        lastValueMousePosition = Mouse.current.position.value.normalized;
    }

    void UseAttackMelee(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP

    }

    void UseAttackRanged(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP

    }

    void UseAbility(InputAction.CallbackContext value)
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


    //GIZMOS
    Vector2 lastValueInput;
    Vector2 lastValueMousePosition;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, new Vector3(lastValueInput.x, 0, lastValueInput.y) * 5);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(lastValueMousePosition.x, 0, lastValueMousePosition.y) * 15);
    }

}
