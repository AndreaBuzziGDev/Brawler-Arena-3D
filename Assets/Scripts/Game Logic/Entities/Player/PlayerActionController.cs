using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : EntityWithAiming
{
    //INSPECTOR REFERENCES
    [SerializeField] PlayerController pc;
    [SerializeField] WeaponController weaponRanged;
    //TODO: WEAPON MELEE
    //TODO: ABILITY

    [SerializeField] Rigidbody rb;


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        if (pc == null)
            Debug.LogWarning("No Player Controller Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if (rb == null)
            Debug.LogWarning("No Rigid Body Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if (weaponRanged == null)
            Debug.LogWarning("No Ranged Weapon Reference Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        //TODO: WEAPON MELEE
        //TODO: ABILITY
    }
#endif


    //PHYSICS PARAMETERS
    [SerializeField] float gravityScale = 0.65f;
    [SerializeField] float movementSpeed = 1.0f;
    
    //DIRECTION VECTORS
    Vector2 movementDirection;




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
    //TODO: RENAME
    void InputInitialization()
    {
        //TODO: THIS SHOULD INSTEAD START LISTENING FROM THE "PlayerController" FOR EVENTS
        //TODO: SUBSCRIBE TO PARENT
        pc.SubscribePlayerAction(HandleMovement);
    }

    //TODO: RENAME
    void InputTermination()
    {
        //TODO: THIS SHOULD INSTEAD STOP LISTENING FROM THE "PlayerController" FOR EVENTS
        //TODO: UN-SUBSCRIBE TO PARENT
        //NB: THIS MIGHT NOT BE NECESSARY. 
        
        pc.UnsubscribePlayerAction(HandleMovement);
    }

    //INPUT HANDLING
    void HandleMovement(object sender, EntityActionEventArgs value)
    {
        Debug.Log("This is HandleMovement in Action Controller");
        //TODO: IGNORE INPUTS WHEN SENDER IS NOT pc? --> MIGHT IMPROVE FIDELITY
        //      NO IT WOULDN'T REALLY. THE REASON BEING, REMEMBER THIS IS INCAPSULATED. THIS ENTITY DECIDES ON ITS OWN ON WHO TO SUBSCRIBE
        //TODO: HOW TO PREVENT OBJECTS FROM SENDING SOMEONE ELSE TO PRETEND TO BE THEM?
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        movementDirection = (Vector2) value.CarriedInfo;
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
    //TODO: UNCOMMENT HERE AND REMOVE ON PlayerController
    /*
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, new Vector3(aimingDirection.x, 0, aimingDirection.y) * 5);
    }
    */

    //UTILITIES
    //...

}
