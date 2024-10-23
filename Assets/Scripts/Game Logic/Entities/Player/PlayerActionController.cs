using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : EntityWithAiming
{
    //INSPECTOR REFERENCES
    [SerializeField] WeaponController weaponRanged;
    //TODO: WEAPON MELEE
    //TODO: ABILITY

    [SerializeField] Rigidbody rb;


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        if (rb == null)
            Debug.LogWarning("No Rigid Body Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if (weaponRanged == null)
            Debug.LogWarning("No Ranged Weapon Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        //TODO: WEAPON MELEE
        //TODO: ABILITY
    }
#endif


    //PHYSICS PARAMETERS
    [SerializeField] float gravityScale = 0.65f;//TODO: RELY ON PHYSICS ENGINE INSTEAD OF SIMULATING IT?
    [SerializeField] float movementSpeed = 1.0f;
    
    //DIRECTION VECTORS
    Vector2 movementDirection;

    //INPUT
    GameInputAction inputPlayer;





    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //LISTEN TO INPUTS
        InputInitialization();
        
    }

    void FixedUpdate()
    {
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
        //TODO: THIS SHOULD INSTEAD START LISTENING FROM THE "PlayerController" FOR EVENTS
    }

    void InputTermination()
    {
        //TODO: THIS SHOULD INSTEAD STOP LISTENING FROM THE "PlayerController" FOR EVENTS
    }

    //INPUT HANDLING
    void UseMovement(InputAction.CallbackContext value)
    {
        
    }
    void ReleaseMovement(InputAction.CallbackContext value)
    {
        
    }


    void UseControllerRotation(InputAction.CallbackContext value)
    {
        
    }
    
    void UseMouseRotation(InputAction.CallbackContext value)
    {
       
    }


    void UseAttackMelee(InputAction.CallbackContext value)
    {
        
    }

    void UseAttackRanged(InputAction.CallbackContext value)
    {
        
    }

    void UseAbility(InputAction.CallbackContext value)
    {
        
    }

    void UseEscape(InputAction.CallbackContext value)
    {
        
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
