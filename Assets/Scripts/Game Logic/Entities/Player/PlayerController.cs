using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

//TODO: IS THIS SUPPOSED TO BE ANOTHER CONTROLLER ENTIRELY, SEPARATED FROM THE CONTROLLER HANDLING THE HEALTH LOGIC?
public class PlayerController : EntityWithHealth
{
    //INSPECTOR REFERENCES
    //TODO: THIS COULD BE IMPROVED. MAYBE EVALUATE ANOTHER ARCHITECTURE, LIKE INPUT DIRECTLY HANDLED IN CHILD OBJECTS
    [SerializeField] PlayerDirection dir;
    [SerializeField] WeaponController weaponRanged;

    //TODO: USE REQUIRED ON COMPONENTS LIKE RIGID BODY?
    Rigidbody rb;


    //INPUT
    GameInputAction inputPlayer;

    //DATA
    Vector2 movementDirection;
    //float movementSpeed = 1;//TODO: USE THIS. - ALSO NEEDS TO BE INITIALIZED IF TAKEN FROM OTHER SOURCE

    //LIFECYCLE FUNCTIONS
    protected override void Start()
    {
        base.Start();
        //ASSIGN REFERENCES
        rb = gameObject.GetComponent<Rigidbody>();

        //LISTEN TO INPUTS
        InputInitialization();
        
        //

    }

    void FixedUpdate()
    {
        //TODO: IS THIS SUPPOSED TO USE FORCES, OR SHOULD IT USE SOMETHING ELSE?
        //TODO: READ VAMEDECUM ABOUT RIGIDBODY USAGE
        if(!GameController.Instance.IsPlaying)
            return;
        
        rb.AddForce(movementDirection.x, 0, movementDirection.y, ForceMode.Impulse);
    }


    void OnDestroy()
    {
        InputTermination();
    }

    
    //FUNCTIONALITIES
    
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

        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed += UseEscape;
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

        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed -= UseEscape;
    }

    //INPUT HANDLING
    void UseMovement(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        movementDirection = value.ReadValue<Vector2>().normalized;
    }
    void ReleaseMovement(InputAction.CallbackContext value)
    {
        
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;

        movementDirection = Vector2.zero;
    }

    void UseRotation(InputAction.CallbackContext value)
    {
        
        if(!GameController.Instance.IsPlaying)
            return;
        
        lastValueInput = value.ReadValue<Vector2>().normalized;
        //Debug.Log("UseRotation - value: " + lastValueInput);

        //USING CHILD OBJECTS TO MAKE DIRECTION VISIBLE
        dir.lastDirection2D = lastValueInput;
        weaponRanged.lastDirection2D = lastValueInput;
        
        //TODO: MOUSE DIRECTION NEEDS TO BE IMPLEMENTED IN ANOTHER WAY
    }


    void UseAttackMelee(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;

        //TODO: DEVELOP
        Debug.Log("No Melee Weapon");
    }

    void UseAttackRanged(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        weaponRanged.Operate();
    }

    void UseAbility(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;

        //TODO: DEVELOP
        Debug.Log("No Ability");
    }

    void UseEscape(InputAction.CallbackContext value)
    {
        if(!GameController.Instance.IsGameOver)
        {
            if(GameController.Instance.IsPaused)
                GameController.Instance.SetState(GameController.EGameState.Paused);
            else
                GameController.Instance.SetState(GameController.EGameState.Playing);
        }
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

    
    public override void HandleDeath()
    {
        //TODO: DEVELOP
        Debug.Log("PlayerController - Handle Death - TODO DEVELOP");
        EventManager<GameMenuEventArgs>.Instance.Notify(this, new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_OVER));
    }

}
