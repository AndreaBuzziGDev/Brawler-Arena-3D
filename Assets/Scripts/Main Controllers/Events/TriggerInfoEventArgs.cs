using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO: THIS SHOULD BE USED FOR TRIGGER EVENTS, NOT FOR PICKUP.
public class TriggerInfoEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        ENTER,
        LEAVE
    }

    //DATA
    public GameObject ColliderObject { get; private set; }
    public string ColliderTag { get; private set; }
    public Vector3 CollisionPosition { get; private set; }
    
    public GameObject Dispatcher { get; private set; }//NB: NECESSARY. EVENT SENDER MIGHT NOT BE A GAMEOBJECT
    

    //CONSTRUCTOR
    public TriggerInfoEventArgs(GameObject colliderObject, GameObject dispatcher){
        ColliderObject = colliderObject;
        ColliderTag = colliderObject.tag;
        CollisionPosition = colliderObject.transform.position;
        
        //TODO: DISPATCHER SHOULD ALWAYS BE SPECIFIED
        Dispatcher = dispatcher;
    }

}
