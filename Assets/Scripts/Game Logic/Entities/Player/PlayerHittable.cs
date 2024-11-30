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
        //TODO: CHANGE THIS. SHOULD LISTEN TO SPECIFIC SUB-EVENTS CASTED BY THE PlayerController (NON EVENT-MANAGER BASED)
        EventManager<PickupEventArgs>.Instance.StartListening(HandlePickupEvent);
    }

    void OnDestroy(){
        //TODO: CHANGE THIS. SHOULD LISTEN TO SPECIFIC SUB-EVENTS CASTED BY THE PlayerController (NON EVENT-MANAGER BASED)
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
