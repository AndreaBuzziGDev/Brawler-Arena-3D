using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : EntityWithHealth
{
    //EntityWithHealth CONCRETIZATION
    public override void HandleDeath()
    {
        GameController.Instance.SetState(GameController.EGameState.GameOver);

        //TODO: LOGIC IS THE SAME BETWEEN ENEMIES AND PLAYER, SHOULD TAKE THIS INTO ACCOUNT AND REFACTOR ACCORDINGLY
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(SoundFXEventArgs.EType.A_FX_PLAYER, audioData.DeathClip));

        //TODO: PLAYER DEATH PARTICLE EFFECT
        //TODO: GAME OVER SCREEN (NOT HERE)

        //DESTROY
        Destroy(this.gameObject);
    }
}
