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
        //TODO: SHOULD THIS REGISTER TO OTHER (NOT YET IMPLEMENTED/DESIGNED) GAME EVENTS THAT ALTER THE GAME'S PARAMETERS?
    }
    
    void OnDestroy()
    {
        EventManager<PickupEventArgs>.Instance.StopListening(HandlePickupEvent);
    }

    //EVENT HANDLING
    private void HandlePickupEvent(object sender, PickupEventArgs e)
    {
        UnityEngine.Debug.Log("Just Debugging for test reasons");
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
    
    //TODO: IMPLEMENT ALL THE PICKUP FUNCTIONALITIES
    //      SHOULD THIS RELY ON AN "EQUIPMENT HELPER" SCRIPT ON THE PLAYER ITSELF?
    
}
