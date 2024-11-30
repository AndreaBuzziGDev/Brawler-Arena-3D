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
    private Dictionary<Type, List<Action<object, EntityPickupEventArgs>>> playerPickupSubscribers = new();



    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //TODO: SUBSCRIBE TO EVENTMANAGER ON PROPER EVENT STREAM
    }


    void OnDestroy()
    {
        //TODO: UNSUBSCRIBE ALL SUBSCRIBERS?
    }

    
    //FUNCTIONALITIES

    //TODO: THIS ARCHITECTURE CAN BE FURTHER ABSTRACTED AND IMPLEMENTED IN PARENT ENTITIES INSTEAD.
    //ENTITY EVENTS SUBSCRIPTION
    public void SubscribePlayerPickup<T>(Action<object, EntityPickupEventArgs> listener) where T : EntityPickupEventArgs
    {
        if (listener == null) return;

        if(!playerPickupSubscribers.ContainsKey(typeof(T)))
            playerPickupSubscribers[typeof(T)] = new List<Action<object, EntityPickupEventArgs>>();
        playerPickupSubscribers[typeof(T)].Add(listener);
    }
    public void UnsubscribePlayerPickup<T>(Action<object, EntityPickupEventArgs> listener) where T : EntityPickupEventArgs
    {
        //TODO: CHECK THE IMPLICATIONS OF THIS WHEN MONOBEHAVIOURS ARE INVOLVED
        //if(instance == null) return;
        if(playerPickupSubscribers[typeof(T)].Contains(listener))
            playerPickupSubscribers[typeof(T)].Remove(listener);
    }


    //UTILITIES
    //...

}
