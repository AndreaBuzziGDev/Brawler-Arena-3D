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
public class PlayerController : MonoBehaviour
{
    //PLAYER EVENT SUBSCRIBERS
    private Dictionary<Type, List<Action<object, EntityPickupEventArgs>>> pUpSubscribers = new();
    //TODO: THE IDEA BEHIND THIS HAS BEEN DISCARDED AND SIMPLIFIED
    //TODO: THIS WILL BE USED AS A MEAN TO LET RECEIVERS BE ACKNOWLEDGED THAT AN ACTION HAS BEEN PERFORMED.
    //      THIS SHOULD HOWEVER BE MOVED IN PlayerActionController
    private Dictionary<Type, List<Action<object, EntityActionEventArgs>>> pActSubscribers = new();


    //LIFECYCLE FUNCTIONS
    void Start()
    {

    }


    void OnDestroy()
    {

    }

    
    //FUNCTIONALITIES


    //TODO: THIS ARCHITECTURE CAN BE FURTHER ABSTRACTED AND IMPLEMENTED IN PARENT ENTITIES INSTEAD.
    //ENTITY EVENTS SUBSCRIPTION

    //TODO: MOVE IN PlayerActionController
    public void SubscribePlayerAction<T>(Action<object, EntityActionEventArgs> listener) where T : EntityActionEventArgs
    {
        if (listener == null) return;
        if(!pActSubscribers.ContainsKey(typeof(T)))
            pActSubscribers[typeof(T)] = new List<Action<object, EntityActionEventArgs>>();
        pActSubscribers[typeof(T)].Add(listener);
    }

    //TODO: MOVE IN PlayerActionController
    public void UnsubscribePlayerAction<T>(Action<object, EntityActionEventArgs> listener) where T : EntityActionEventArgs
    {
        //TODO: CHECK THE IMPLICATIONS OF THIS WHEN MONOBEHAVIOURS ARE INVOLVED
        //if(instance == null) return;
        if(pActSubscribers[typeof(T)].Contains(listener))
            pActSubscribers[typeof(T)].Remove(listener);
    }


    public void SubscribePlayerPickup<T>(Action<object, EntityPickupEventArgs> listener) where T : EntityPickupEventArgs
    {
        if (listener == null) return;

        if(!pUpSubscribers.ContainsKey(typeof(T)))
            pUpSubscribers[typeof(T)] = new List<Action<object, EntityPickupEventArgs>>();
        pUpSubscribers[typeof(T)].Add(listener);
    }
    public void UnsubscribePlayerPickup<T>(Action<object, EntityPickupEventArgs> listener) where T : EntityPickupEventArgs
    {
        //TODO: CHECK THE IMPLICATIONS OF THIS WHEN MONOBEHAVIOURS ARE INVOLVED
        //if(instance == null) return;
        if(pUpSubscribers[typeof(T)].Contains(listener))
            pUpSubscribers[typeof(T)].Remove(listener);
    }


    //UTILITIES
    //...

}
