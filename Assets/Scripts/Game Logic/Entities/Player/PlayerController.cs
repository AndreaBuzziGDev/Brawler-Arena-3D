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
    [SerializeField] float gravityScale = 0.65f;

    //TODO: USE REQUIRED ON COMPONENTS LIKE RIGID BODY?
    Rigidbody rb;


    //INPUT
    GameInputAction inputPlayer;

    //DATA
    Vector2 movementDirection;

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
            rb.velocity = new Vector3(0, 0, 0);
        else
        {
            rb.velocity = movementSpeed * new Vector3(movementDirection.x, 0, movementDirection.y);
            rb.velocity += gravityScale * Physics.gravity;
        }
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
        inputPlayer.BaseActionMap.ControllerRotation.performed += UseControllerRotation;
        inputPlayer.BaseActionMap.MouseRotation.performed += UseMouseRotation;

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
        
        //MOVEMENT INPUT
        inputPlayer.BaseActionMap.DirectionalMovement.performed -= UseMovement;
        inputPlayer.BaseActionMap.DirectionalMovement.canceled -= ReleaseMovement;

        //ROTATION INPUT
        inputPlayer.BaseActionMap.ControllerRotation.performed -= UseControllerRotation;
        inputPlayer.BaseActionMap.MouseRotation.performed -= UseMouseRotation;
        
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

    void UseControllerRotation(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        lastValueInput = value.ReadValue<Vector2>().normalized;

        //USING CHILD OBJECTS TO MAKE DIRECTION VISIBLE
        dir.lastDirection2D = lastValueInput;
        weaponRanged.lastDirection2D = lastValueInput;
    }
    
    //TODO: MOVE APPROPRIATELY
    Vector2 testDirection = Vector2.up;
    float lerpSpeedMouse = 0.1f;


    //TODO: SHOULD BE UNIFIED WITH UseControllerRotation
    void UseMouseRotation(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePos2D = new(mousePos.x, mousePos.y);
        Debug.Log("Mouse Pos: " + mousePos2D);
        testDirection = mousePos2D - new Vector2(Screen.width/2, Screen.height/2);

        //USING CHILD OBJECTS TO MAKE DIRECTION VISIBLE
        dir.lastDirection2D = testDirection;
        weaponRanged.lastDirection2D = testDirection;
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
        Debug.Log("Is Game Over: " + GameController.Instance.IsGameOver);
        if(!GameController.Instance.IsGameOver)
        {
            if(GameController.Instance.IsPaused)
                GameController.Instance.SetState(GameController.EGameState.Playing);
            else
                GameController.Instance.SetState(GameController.EGameState.Paused);
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
        GameController.Instance.SetState(GameController.EGameState.GameOver);

        //TODO: LOGIC IS THE SAME BETWEEN ENEMIES AND PLAYER, SHOULD TAKE THIS INTO ACCOUNT AND REFACTOR ACCORDINGLY
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(SoundFXEventArgs.EType.A_FX_PLAYER, audioData.DeathClip));

        //TODO: PLAYER DEATH PARTICLE EFFECT
        //TODO: GAME OVER SCREEN (NOT HERE)

        //DESTROY
        Destroy(this.gameObject);
    }

}
