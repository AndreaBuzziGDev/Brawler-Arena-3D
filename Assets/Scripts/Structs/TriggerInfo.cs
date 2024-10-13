using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo
{
    public GameObject ColliderObject { get; private set; }
    public string ColliderTag { get; private set; }
    public Vector3 CollisionPosition { get; private set; }

    public TriggerInfo(GameObject colliderObject){
        ColliderObject = colliderObject;
        ColliderTag = colliderObject.tag;
        CollisionPosition = colliderObject.transform.position;
    }
}
