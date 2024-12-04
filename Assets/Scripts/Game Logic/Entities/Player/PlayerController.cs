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
    //NB: HELPER MIGHT BE ENTIRELY STATIC CODE INSTEAD, AND THIS CLASS MIGHT RELY ON THE HELPER.
    //THIS SHOULD ALSO SOLVE REFERENCING ISSUES.
    private Dictionary<PickupController.EPickupTypes, List<Action<object, EntityPickupEventArgs>>> playerPickupSubscribers = new();


    //LIFECYCLE FUNCTIONS
    //EntityWithHealth Override
    void Start()
    {
        foreach(PickupController.EPickupTypes pickupType in Enum.GetValues(typeof(PickupController.EPickupTypes)))
            playerPickupSubscribers.Add(pickupType, new());
        
        EventManager<PickupEventArgs>.Instance.StartListening(PublishToSubscribers);
    }

    void OnDestroy()
    {
        EventManager<PickupEventArgs>.Instance.StopListening(PublishToSubscribers);
    }

    
    //FUNCTIONALITIES

    //TODO: THIS ARCHITECTURE CAN BE FURTHER ABSTRACTED AND IMPLEMENTED IN PARENT ENTITIES INSTEAD.
    //      DO THIS, OR USE A HELPER OF SORTS TO HANDLE THE LOGIC
    
    //ENTITY EVENTS SUBSCRIPTION
    public void SubscribePlayerPickup(PickupController.EPickupTypes type, Action<object, EntityPickupEventArgs> listener)
    {
        if (listener == null) 
            return;

        playerPickupSubscribers[type].Add(listener);
    }
    public void UnsubscribePlayerPickup(PickupController.EPickupTypes type, Action<object, EntityPickupEventArgs> listener)
    {
        if(listener == null || !playerPickupSubscribers.ContainsKey(type)) 
            return;

        //
        if(playerPickupSubscribers[type].Contains(listener))
            playerPickupSubscribers[type].Remove(listener);
    }


    //TODO: RENAME
    private void PublishToSubscribers(object sender, PickupEventArgs e)
    {
        //INVOKE EVENT ON playerPickupSubscribers
        //TODO: IMPLEMENT
        //Dictionary<Type, List<Action<object, EntityPickupEventArgs>>> playerPickupSubscribers
        foreach(Action<object, EntityPickupEventArgs> act in playerPickupSubscribers[e.EventType])
            act?.Invoke(this, new EntityPickupEventArgs(e));
    }


    //UTILITIES
    //...
    
    

}
