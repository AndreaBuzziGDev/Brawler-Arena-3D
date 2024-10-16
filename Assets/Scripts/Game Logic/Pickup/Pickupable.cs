using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: EVOLVE TO HANDLE INSTANT PICKUP VS PROMPTED PICKUP
public class Pickupable : MonoBehaviour
{
    //DATA
    [SerializeField] PickupController.EPickupTypes pickupType;
    [SerializeField] bool enemyPickup = false;
    bool isInert = false;


    //LIFECYCLE FUNCTIONS
    void OnEnable()
    {
        isInert = false;
    }


    //TRIGGER
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("This is Pickupable Script colliding with: " + other.gameObject.name);
        if(!isInert)
        {
            isInert = true;
            //TODO: SHOULD THIS CHECK FOR PLAYER IN ADVANCE?
            //TODO: SHOULD THIS IGNORE AND SHOULD IT JUST RELY ON COLLISION MATRIX?
            //DISPATCH EVENT
            EventManager<PickupEventArgs>.Instance.Notify(this, new(this.pickupType));
            
            Destroy(this.gameObject);
        }
    }
}
