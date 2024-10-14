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
        EventManager<PickupEventArgs>.Instance.StartListening(HandlePickupEvent);
    }
    
    void OnDestroy()
    {
        EventManager<PickupEventArgs>.Instance.StopListening(HandlePickupEvent);
    }

    //EVENT HANDLING
    private void HandlePickupEvent(object sender, PickupEventArgs e)
    {
        switch(e.EventType)
        {
            case EPickupTypes.Health:
                //
                
                break;
            case EPickupTypes.Weapon:
                //
                
                break;
            case EPickupTypes.Ability:
                //
                
                break;
            case EPickupTypes.Buff:
                //
                
                break;
            default:
                UnityEngine.Debug.LogWarning("Invalid Pickup Type: " + e.EventType);
                break;
        }
    }
    
    
    
}
