using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo
{
    public GameObject ColliderObject { get; private set; }
    public string ColliderTag { get; private set; }
    public Vector3 CollisionPosition { get; private set; }

    public GameObject Dispatcher { get; private set; }

    public TriggerInfo(GameObject colliderObject, GameObject dispatcher){
        ColliderObject = colliderObject;
        ColliderTag = colliderObject.tag;
        CollisionPosition = colliderObject.transform.position;
        
        //TODO: DISPATCHER SHOULD ALWAYS BE SPECIFIED
        Dispatcher = dispatcher;
    }
}
