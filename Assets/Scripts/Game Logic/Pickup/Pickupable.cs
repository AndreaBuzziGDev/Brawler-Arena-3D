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
        TriggerInfoEventArgs tInfo = new(other.gameObject, this.gameObject);
        
        //DISPATCH EVENT
        EventManager<TriggerInfoEventArgs>.Instance.Notify(this, new(other.gameObject, this.gameObject));
        
        //ADDITIONAL ACTIONS?
        //TODO: IS THIS SUPPOSED TO IMPLEMENT A DELEGATE OR A SIMILAR FUNCTIONALITY OF SOME SORT?
        //      MOST LIKELY, YES.
        
    }
}
