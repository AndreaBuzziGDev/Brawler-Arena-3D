using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : EntityWithHealth
{
    //EntityWithHealth CONCRETIZATION
    public override void HandleDeath()
    {
        GameController.Instance.SetState(GameController.EGameState.GameOver);
        base.HandleDeath();
    }
}
