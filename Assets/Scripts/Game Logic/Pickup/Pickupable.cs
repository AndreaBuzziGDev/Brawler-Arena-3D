using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //TODO: CHECK IF COLLIDER IS PLAYER
        //TRIGGER INFO
        TriggerInfo tInfo = new(other.gameObject, this.gameObject);
        
        //DISPATCH EVENT
        
        //ADDITIONAL ACTIONS?
    }
}
