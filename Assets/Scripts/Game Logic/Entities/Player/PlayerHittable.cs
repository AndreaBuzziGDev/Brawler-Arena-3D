using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : EntityWithHealth
{
    //EntityWithHealth CONCRETIZATION
    public override void HandleDeath()
    {
        Debug.Log("PlayerHittable - HandleDeath - TODO: PARTICLE AND OTHER DEATH STUFF");
        GameController.Instance.SetState(GameController.EGameState.GameOver);
        base.HandleDeath();
    }
}
