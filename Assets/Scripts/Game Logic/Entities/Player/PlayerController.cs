using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //TODO: SHOULD THIS ACT AS A REFERENCE HANDLER FOR LOGIC ENTITIES "BELOW" IT?

    //PLAYER EVENT SUBSCRIBERS
    //TODO: THESE MIGHT NEED TO BE RENAMED.
    //TODO: DEVELOP AND USE "PICKUP HELPER"
    private List<Action<object, EntityPickupEventArgs>> playerPickupSubscribers = new();



    //LIFECYCLE FUNCTIONS
    //LIFECYCLE FUNCTIONS
    //EntityWithHealth Override
    void Start()
    {
        EventManager<PickupEventArgs>.Instance.StartListening(publishToSubscribers);
    }

    void OnDestroy(){
        EventManager<PickupEventArgs>.Instance.StopListening(publishToSubscribers);
    }

    
    //FUNCTIONALITIES

    //TODO: THIS ARCHITECTURE CAN BE FURTHER ABSTRACTED AND IMPLEMENTED IN PARENT ENTITIES INSTEAD.
    //      DO THIS, OR USE A HELPER OF SORTS TO HANDLE THE LOGIC
    
    //ENTITY EVENTS SUBSCRIPTION
    public void SubscribePlayerPickup<T>(Action<object, EntityPickupEventArgs> listener) where T : EntityPickupEventArgs
    {
        if (listener == null) return;

        playerPickupSubscribers.Add(listener);
    }
    public void UnsubscribePlayerPickup<T>(Action<object, EntityPickupEventArgs> listener) where T : EntityPickupEventArgs
    {
        if(listener == null) return;

        //
        if(playerPickupSubscribers.Contains(listener))
        {
            playerPickupSubscribers.Remove(listener);
        }
    }


    //TODO: RENAME
    private void publishToSubscribers(object sender, PickupEventArgs e)
    {
        //INVOKE EVENT ON playerPickupSubscribers
        //TODO: IMPLEMENT
        //Dictionary<Type, List<Action<object, EntityPickupEventArgs>>> playerPickupSubscribers
        foreach(Action<object, EntityPickupEventArgs> act in playerPickupSubscribers)
        {
            act?.Invoke(this, new EntityPickupEventArgs(e));
        }
    }


    //UTILITIES
    //...
    
    

}
