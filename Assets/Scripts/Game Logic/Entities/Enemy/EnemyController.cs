using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityWithHealth
{
    //DATA


    //FUNCTIONALITIES
    //...

    //EntityWithHealth CONCRETIZATION
    protected override void HandleDeath()
    {
        Debug.Log("EnemyController - HandleDeath - TODO: PARTICLE AND OTHER DEATH STUFF");
        base.HandleDeath();
    }
}
