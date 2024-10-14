using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    //ENUMS
    public enum EPickupTypes
    {
        Health,
        Weapon,
        Ability,
        Buff
    }
    
    //DATA
    
    
    //LIFECYCLE FUNCTIONS
    
    // Start is called before the first frame update
    void Start()
    {
        //REGISTER TO EVENT
        EventManager<TriggerInfoEventArgs>.Instance.StartListening(HandlePickupEvent);
    }
    
    void OnDestroy()
    {
        EventManager<TriggerInfoEventArgs>.Instance.StopListening(HandlePickupEvent);
    }

    //EVENT HANDLING
    private void HandlePickupEvent(object sender, TriggerInfoEventArgs e)
    {
        //TODO: HANDLE ENTER VS LEAVE?
        /*
        Switch(e.EventType)
        {

        }
        */
    }
    
    
    
}
