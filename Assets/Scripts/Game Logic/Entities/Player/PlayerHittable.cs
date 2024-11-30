using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerHittable : EntityWithHealth
{
    //LIFECYCLE FUNCTIONS
    //EntityWithHealth Override
    protected override void Start()
    {
        base.Start();
        EventManager<PickupEventArgs>.Instance.StartListening(HandlePickupEvent);
    }

    void OnDestroy(){
        EventManager<PickupEventArgs>.Instance.StopListening(HandlePickupEvent);
    }




    //EntityWithHealth CONCRETIZATION
    //TODO: MOVE TO PROTECTED OR DO SOMETHING ELSE
    public override void HandleDeath()
    {
        GameController.Instance.SetState(GameController.EGameState.GameOver);
        base.HandleDeath();
    }



    //PICKUP LOGIC IMPLEMENTATION
    private void HandlePickupEvent(object sender, PickupEventArgs e)
    {
        //DO LOGIC...
        
    }


}
