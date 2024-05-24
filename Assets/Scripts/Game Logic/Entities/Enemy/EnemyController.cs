using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityWithHealth
{
    //DATA
    //WEAPONS HERE?


    //FUNCTIONALITIES
    public override void HandleDeath()
    {
        Debug.Log("EnemyController - HandleDeath - TODO: PARTICLE AND OTHER DEATH STUFF");
        Destroy(gameObject);
    }

    //ON COLLISION


    //WEAPON OPERATE
    

}
