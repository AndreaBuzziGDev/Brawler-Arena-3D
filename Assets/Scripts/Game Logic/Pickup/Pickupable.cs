using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {
    [Header("Pickup Properties")]
    [Tooltip("Specify which type of pickup is this")]
    [SerializeField] PickupTypes pickupType;

    [Tooltip("Can the enemy pick this up? (UNIMPLEMENTED)")]
    [SerializeField] bool enemyPickup = false;


    //DATA
    bool isInert = false;
    int targetLayer = -1;


    //LIFECYCLE FUNCTIONS
    void OnEnable() {
        isInert = false;
        targetLayer = LayerMask.NameToLayer("Enemy Collider");//NB: Needed to avoid errors due to lifecycle functions binding
    }


    //TRIGGER
    private void OnTriggerEnter(Collider other) {
        Debug.Log("This is Pickupable Script colliding with: " + other.gameObject.name + " with Id: " + other.gameObject.GetInstanceID());

        if (!isInert) {
            bool isEnemy = other.gameObject.layer == targetLayer;
            if (!isEnemy || (isEnemy && enemyPickup)) {
                isInert = true;
                EventManager<PickupEventArgs>.Instance.Notify(
                    this,
                    new(this.pickupType, other.gameObject.GetInstanceID())
                );
                Destroy(this.gameObject);
            }
        }
    }
}
