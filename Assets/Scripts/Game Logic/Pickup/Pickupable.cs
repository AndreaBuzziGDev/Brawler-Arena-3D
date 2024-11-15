using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: EVOLVE TO HANDLE INSTANT PICKUP VS PROMPTED PICKUP
public class Pickupable : MonoBehaviour
{
    [Header("Pickup Properties")]
    [SerializeField] PickupController.EPickupTypes pickupType;
    [SerializeField] bool enemyPickup = false;//TODO: USE THIS TO SPECIFY THAT ENEMIES CAN PICK UP THIS PICKUPABLE


    //DATA
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
            EventManager<PickupEventArgs>.Instance.Notify(this, new(this.pickupType));
            Destroy(this.gameObject);
        }
    }
}
