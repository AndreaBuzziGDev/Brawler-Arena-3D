using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : EntityWithAiming
{
    [Header("Inspector References")]
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] PlayerController masterController;
    [SerializeField] WeaponController weaponRanged;
    //TODO: WEAPON MELEE
    //TODO: ABILITY



    //PHYSICS PARAMETERS
    [Header("Physics Parameters")]
    [SerializeField] float gravityScale = 0.65f;
    [SerializeField] float movementSpeed = 1.0f;
    //TODO: MOMENTUM?



    //INTERNAL DATA
    //DIRECTION VECTORS
    Vector2 movementDirection;
    //INPUT
    GameInputAction inputPlayer;




    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected void OnValidate()
    {
        if (playerRigidBody == null)
            Debug.LogWarning("No Rigid Body Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if (masterController == null)
            Debug.LogWarning("No Player Controller Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if (weaponRanged == null)
            Debug.LogWarning("No Ranged Weapon Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        //TODO: WEAPON MELEE
        //TODO: ABILITY
    }
#endif





    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //LISTEN TO INPUTS
        InputInitialization();
    }

    void FixedUpdate()
    {
        if(!GameController.Instance.IsPlaying)
            playerRigidBody.velocity = new Vector3(0, 0, 0);
        else
        {
            playerRigidBody.velocity = movementSpeed * new Vector3(movementDirection.x, 0, movementDirection.y);
            playerRigidBody.velocity += gravityScale * Physics.gravity;
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
        
        aimingDirection = value.ReadValue<Vector2>().normalized;
    }
    
    void UseMouseRotation(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePos2D = new(mousePos.x, mousePos.y);
        aimingDirection = mousePos2D - new Vector2(Screen.width/2, Screen.height/2);
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
                GameController.Instance.SetState(GameController.EGameState.Playing);
            else
                GameController.Instance.SetState(GameController.EGameState.Paused);
        }
    }



    //GIZMOS
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, new Vector3(aimingDirection.x, 0, aimingDirection.y) * 5);
    }
    

    //UTILITIES
    //...

}
