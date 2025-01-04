using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //TODO: SHOULD THIS ACT AS A REFERENCE HANDLER FOR LOGIC ENTITIES "BELOW" IT?
    //      IN REALITY, THIS IS GOING TO BACKFIRE FOR SOME REASONS, EXPECIALLY WHEN TRYING TO INCAPSULATE AND HIDE FUNCTIONALITIES FROM THE OUTSIDE.
    //      IT MIGHT HAVE ITS BENEFITS, BUT FOR NOW, THEY AREN'T THERE.
    [Header("Inspector References")]
    [SerializeField] private PlayerHittable playerHS;//TODO: ENFORCE REQUIREMENT LIKE I ALREADY DID SOMEWHERE ELSE

    //ACCESSORS
    public PlayerHittable PlayerHealthAndShield { get { return playerHS; } }




    //LIFECYCLE FUNCTIONS
#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        if (playerHS == null)
            Debug.LogWarning("No Entity PlayerHittable Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif




    //LIFECYCLE FUNCTIONS
    void Start()
    {
        EventManager<PickupEventArgs>.Instance.StartListening(PublishToSubscribers);
    }

    void OnDestroy()
    {
        //TODO: MIGHT NEED FLUSHING OF PlayerPickupHelper's Subscribers IN SOME WAY.
        EventManager<PickupEventArgs>.Instance.StopListening(PublishToSubscribers);
    }

    
    //FUNCTIONALITIES
    private void PublishToSubscribers(object sender, PickupEventArgs e)
    {
        foreach(Action<object, EntityPickupEventArgs> act in PlayerPickupHelper.Subscribers[e.EventType])
            act?.Invoke(this, new EntityPickupEventArgs(e));
    }


    //UTILITIES
    //...
    
    

}
