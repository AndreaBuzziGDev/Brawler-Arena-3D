using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: EVOLVE TO HANDLE INSTANT PICKUP VS PROMPTED PICKUP
public class Pickupable : MonoBehaviour
{
    //DATA
    [SerializeField] Boolean enemyPickup = false;
    Boolean isInert = false;
    
    //DATA GETTERS
    public Boolean IsInert { get {return isInert; } }
    

    //TODO: PICKUPPABLES SHOULD PROBABLY BECOME INERT AFTER PLAYER PICKS THEM UP
    //
    void OnEnable()
    {
        isInert = false;
    }




    //TRIGGER
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("This is Pickupable Script");
        if(!IsInert)
        {
            isInert = true;
            //TODO: SHOULD THIS CHECK FOR PLAYER IN ADVANCE?
            //TODO: SHOULD THIS IGNORE AND SHOULD IT JUST RELY ON COLLISION MATRIX?
            //DISPATCH EVENT
            EventManager<TriggerInfoEventArgs>.Instance.Notify(this, new(other.gameObject, this.gameObject));
            
            //ADDITIONAL ACTIONS?
            //TODO: IS THIS SUPPOSED TO IMPLEMENT A DELEGATE OR A SIMILAR FUNCTIONALITY OF SOME SORT?
            //      MOST LIKELY, YES.
            //      ACTUALLY: NO. DOESN'T NEED THAT BECAUSE IN THIS CASE, PICKUPABLES LOGIC WILL BE HANDLED BY A CENTRALIZED SCRIPT WITH EVENT HANDLING.

        }
    }
}
