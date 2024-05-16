using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //SCRIPTABLE OBJECTS
    //TODO: NOTIFY TO EDITOR OR GAME THAT DATA IS MISSING?
    [SerializeField] PlayerCharacterData data;

    //INSPECTOR REFERENCES
    //TODO: THIS COULD BE IMPROVED. MAYBE EVALUATE ANOTHER ARCHITECTURE, LIKE INPUT DIRECTLY HANDLED IN CHILD OBJECTS
    [SerializeField] PlayerDirection dir;
    [SerializeField] WeaponController weaponRanged;

    //TODO: USE REQUIRED ON COMPONENTS LIKE RIGID BODY?
    Rigidbody rb;


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
        //ASSIGN REFERENCES
        rb = gameObject.GetComponent<Rigidbody>();

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

    //TODO: BETTER MOVE THIS LOGIC INTO ANOTHER SCRIPT. IT'S GETTING CROWDED HERE
    Vector2 movementDirection;
    void FixedUpdate()
    {
        //Debug.Log("movementDirection: " + movementDirection);
        //TODO: SHOULD THIS USE FORCES OR SOMETHING ELSE?
        //TODO: READ VAMEDECUM ABOUT RIGIDBODY USAGE
        rb.AddForce(movementDirection.x, 0, movementDirection.y, ForceMode.Impulse);
        //rb.MovePosition(transform.position +  new Vector3(movementDirection.x, 0, movementDirection.y));
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

        //MOVEMENT INPUT
        inputPlayer.BaseActionMap.DirectionalMovement.performed += UseMovement;
        inputPlayer.BaseActionMap.DirectionalMovement.canceled += ReleaseMovement;
        
        //ROTATION INPUT
        inputPlayer.BaseActionMap.DirectionalRotation.performed += UseRotation;

        //EQUIPMENT INPUT
        inputPlayer.BaseActionMap.WeaponMelee.performed += UseAttackMelee;
        inputPlayer.BaseActionMap.WeaponRanged.performed += UseAttackRanged;
        inputPlayer.BaseActionMap.WeaponUtility.performed += UseAbility;
    }

    void InputTermination()
    {
        inputPlayer.Disable();

        //TODO: INPUT MUST ALSO BE MANAGED IN THE CASE THE GAME IS PAUSED

        //MOVEMENT INPUT
        inputPlayer.BaseActionMap.DirectionalMovement.performed -= UseMovement;
        inputPlayer.BaseActionMap.DirectionalMovement.canceled -= ReleaseMovement;

        //ROTATION INPUT
        inputPlayer.BaseActionMap.DirectionalRotation.performed -= UseRotation;
        
        //EQUIPMENT INPUT
        inputPlayer.BaseActionMap.WeaponMelee.performed -= UseAttackMelee;
        inputPlayer.BaseActionMap.WeaponRanged.performed -= UseAttackRanged;
        inputPlayer.BaseActionMap.WeaponUtility.performed -= UseAbility;
    }

    //INPUT HANDLING
    void UseMovement(InputAction.CallbackContext value)
    {
        movementDirection = value.ReadValue<Vector2>().normalized;
    }
    void ReleaseMovement(InputAction.CallbackContext value)
    {
        movementDirection = Vector2.zero;
    }

    void UseRotation(InputAction.CallbackContext value)
    {
        lastValueInput = value.ReadValue<Vector2>().normalized;
        //Debug.Log("UseRotation - value: " + lastValueInput);

        //USING CHILD OBJECTS TO MAKE DIRECTION VISIBLE
        dir.lastDirection2D = lastValueInput;
        weaponRanged.lastDirection2D = lastValueInput;

        //TODO: MOUSE DIRECTION NEEDS TO BE IMPLEMENTED IN ANOTHER WAY

    }


    void UseAttackMelee(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP
        Debug.Log("No Melee Weapon");

    }

    void UseAttackRanged(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP
        weaponRanged.Operate();

    }

    void UseAbility(InputAction.CallbackContext value)
    {
        //TODO: DEVELOP
        Debug.Log("No Ability");
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
    float lastValueMouse;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, new Vector3(lastValueInput.x, 0, lastValueInput.y) * 5);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(lastValueMouse, 0, 0) * 5);
    }

}
