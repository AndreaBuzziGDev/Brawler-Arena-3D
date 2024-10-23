using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

//TODO: REFACTOR THIS
//      THIS WILL BE USED AS A MULTIPLEXING SCRIPT THAT CAN HANDLE SOME FUNCTIONALITIES AS A SORT OF INCAPSULATOR.
//      THE CODE CURRENTLY PRESENT IN THIS SCRIPT WILL BE MOVED IN A PlayerMovementController SCRIPT INSTEAD
//      THIS SHOULD REFERENCE PlayerHittable, PlayerController, AND MAYBE EVEN OTHER FUTURE SCRIPTS
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : EntityWithAiming
{
    //PLAYER EVENT SUBSCRIBERS
    private List<Action<object, EntityActionEventArgs>> pActSubscribers = new List<Action<object, EntityActionEventArgs>>();
    private List<Action<object, EntityPickupEventArgs>> pUpSubscribers = new List<Action<object, EntityPickupEventArgs>>();


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


    void OnDestroy()
    {
        InputTermination();
        //TODO: UNSUBSCRIBE ALL SUBSCRIBERS
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


    //ENTITY EVENTS SUBSCRIPTION
    //TODO: THIS ARCHITECTURE CAN BE FURTHER ABSTRACTED AND IMPLEMENTED IN PARENT ENTITIES INSTEAD.
    public void SubscribePlayerAction(Action<object, EntityActionEventArgs> listener)
    {
        if (listener == null) return;
        pActSubscribers.Add(listener);
    }
    public void UnsubscribePlayerAction(Action<object, EntityActionEventArgs> listener)
    {
        //TODO: CHECK THE IMPLICATIONS OF THIS WHEN MONOBEHAVIOURS ARE INVOLVED
        //if(instance == null) return;
        if(pActSubscribers.Contains(listener))
            pActSubscribers.Remove(listener);
    }


    public void SubscribePlayerPickup(Action<object, EntityPickupEventArgs> listener)
    {
        if (listener == null) return;
        pUpSubscribers.Add(listener);
    }
    public void UnsubscribePlayerPickup(Action<object, EntityPickupEventArgs> listener)
    {
        //TODO: CHECK THE IMPLICATIONS OF THIS WHEN MONOBEHAVIOURS ARE INVOLVED
        //if(instance == null) return;
        if(pUpSubscribers.Contains(listener))
            pUpSubscribers.Remove(listener);
    }




    //INPUT HANDLING
    void UseMovement(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        movementDirection = value.ReadValue<Vector2>().normalized;

        foreach(Action<object, EntityActionEventArgs> sub in pActSubscribers)
        {
            Debug.Log("Subscriber: " + sub);
            sub?.Invoke(this, new(movementDirection));
        }
    }
    void ReleaseMovement(InputAction.CallbackContext value)
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;

        movementDirection = Vector2.zero;
        foreach(Action<object, EntityActionEventArgs> sub in pActSubscribers)
        {
            sub?.Invoke(this, new(movementDirection));
        }
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
        
        //weaponRanged.Operate();
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
