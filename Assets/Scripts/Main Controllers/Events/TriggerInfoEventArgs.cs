using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO: THIS SHOULD BE USED FOR TRIGGER EVENTS, NOT FOR PICKUP.
public class TriggerInfoEventArgs : EventArgs {
    //ENUMS
    public enum EType {
        ENTER,
        LEAVE
    }

    //DATA
    public GameObject ColliderObject { get; }
    public string ColliderTag { get; }
    public Vector3 CollisionPosition { get; }

    public GameObject Dispatcher { get; }//NB: NECESSARY. EVENT SENDER MIGHT NOT BE A GAMEOBJECT


    //CONSTRUCTOR
    public TriggerInfoEventArgs(GameObject colliderObject, GameObject dispatcher) {
        ColliderObject = colliderObject;
        ColliderTag = colliderObject.tag;
        CollisionPosition = colliderObject.transform.position;

        //TODO: DISPATCHER SHOULD ALWAYS BE SPECIFIED
        Dispatcher = dispatcher;
    }

}
