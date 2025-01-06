using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //LIFECYCLE FUNCTIONS
    void Start()
    {
        EventManager<PickupEventArgs>.Instance.StartListening(PublishToSubscribers);
    }

    void OnDestroy()
    {
        EventManager<PickupEventArgs>.Instance.StopListening(PublishToSubscribers);
    }

    
    //FUNCTIONALITIES
    private void PublishToSubscribers(object sender, PickupEventArgs e)
    {
        if(e.PickerId == this.gameObject.GetInstanceID()){
            foreach(Action<object, EntityPickupEventArgs> act in PlayerPickupHelper.Subscribers[e.EventType])
                act?.Invoke(this, new EntityPickupEventArgs(e));
        }
    }


    //UTILITIES
    //...
    
    

}
