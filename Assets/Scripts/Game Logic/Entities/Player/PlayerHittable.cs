using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHittable : EntityWithHealth
{
    //DATA
    [Header("Gameobject References")]
    [SerializeField] private PlayerController pc;//TODO: I DON'T LIKE THIS. CAN IT BE SOLVED BY USING STATIC CODE?



    //LIFECYCLE FUNCTIONS
    //EntityWithHealth Override
    protected override void Start()
    {
        base.Start();
        pc.SubscribePlayerPickup(PickupController.EPickupTypes.Health, HandlePickupEvent);
    }

    void OnDestroy(){
        pc.UnsubscribePlayerPickup(PickupController.EPickupTypes.Health, HandlePickupEvent);
    }




    //EntityWithHealth CONCRETIZATION
    //TODO: MOVE TO PROTECTED OR DO SOMETHING ELSE
    public override void HandleDeath()
    {
        GameController.Instance.SetState(GameController.EGameState.GameOver);
        base.HandleDeath();
    }



    //PICKUP LOGIC IMPLEMENTATION
    private void HandlePickupEvent(object sender, EntityPickupEventArgs e)
    {
        //DO LOGIC...
        //IF EMITTER IS PLAYERCONTROLLER
        if(sender.GetType() != typeof(PlayerController)) return;
        
        //SWITCH ON PickupEventArgs
        switch(e.OriginalInfo.EventType)
        {
            case PickupController.EPickupTypes.Health:
                //
                Debug.Log("TODO: IMPLEMENT " + e.OriginalInfo.EventType);
                break;
            default:
                UnityEngine.Debug.LogWarning("Unsupported type: " + e.OriginalInfo.EventType);
                break;
        }
    }


}
