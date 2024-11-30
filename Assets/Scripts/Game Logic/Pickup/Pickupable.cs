using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: EVOLVE TO HANDLE INSTANT PICKUP VS PROMPTED PICKUP
public class Pickupable : MonoBehaviour
{
    [Header("Pickup Properties")]
    [Tooltip("Specify which type of pickup is this")]
    [SerializeField] PickupController.EPickupTypes pickupType;

    [Tooltip("Can the enemy pick this up? (UNIMPLEMENTED)")]
    [SerializeField] bool enemyPickup = false;//TODO: IMPLEMENT


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
        Debug.Log("This is Pickupable Script colliding with: " + other.gameObject.name + " with Id: " + other.gameObject.GetInstanceID());
        if(!isInert)
        {
            isInert = true;
            EventManager<PickupEventArgs>.Instance.Notify(
                this, 
                new(this.pickupType, other.gameObject.GetInstanceID())
            );
            Destroy(this.gameObject);
        }
    }
}
