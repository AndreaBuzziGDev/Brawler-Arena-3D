using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//TODO: THIS CLASS HAS BECOME UNNECESSARY.
//      KEEP THIS ONLY TO HANDLE VALIDATION-RELATED SCENARIOS, LIKE "PICKUP EVENTS" CAN ONLY HAPPEN IF THIS CLASS HANDLES THEM
//      THIS IS INTENDED TO BE DEVELOPED LATE AND NOT PART OF THE MAIN GAME MECHANICS FOR THE TIME BEING
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
    //TODO: DECIDE WHAT TO DO. SHOULD THIS BE RE-MODELED ENTIRELY AND CHANGE THE BEHAVIOUR SO THAT IT ISN'T BASED ON EVENTS BUT ON INTERFACES INSTEAD?
    //      INTERFACES SHOULD BE MORE IMMEDIATE AND OUTRIGHT UNDERSTANDABLE.
    private void HandlePickupEvent(object sender, PickupEventArgs e)
    {
        PlayerController pc = GameController.Instance.GetPlayerAnywhere;
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
