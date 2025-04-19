using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHittable : EntityWithHealth {
    //DATA
    [Header("Inspector References")]
    [SerializeField] private PlayerController master;



    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected override void OnValidate() {
        base.OnValidate();
        if (master == null)
            Debug.LogWarning("No Entity PlayerController Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //LIFECYCLE FUNCTIONS
    //EntityWithHealth Override
    protected override void Start() {
        base.Start();
        PlayerPickupHelper.Subscribe(PickupTypes.Health, HandlePickupEvent);
    }

    void OnDestroy() {
        PlayerPickupHelper.Unsubscribe(PickupTypes.Health, HandlePickupEvent);
    }




    //EntityWithHealth CONCRETIZATION
    //TODO: MOVE TO PROTECTED OR DO SOMETHING ELSE
    public override void HandleDeath() {
        GameController.Instance.SetState(GameController.EGameState.GameOver);
        base.HandleDeath();
    }



    //PICKUP LOGIC IMPLEMENTATION
    private void HandlePickupEvent(object sender, EntityPickupEventArgs e) {
        //CHECK VALID EMITTER
        PlayerController recastSender = sender as PlayerController;
        if (!recastSender || recastSender != master) return;

        //SWITCH ON PickupEventArgs
        switch (e.OriginalInfo.EventType) {
            case PickupTypes.Health:
                //TODO: WHO DETERMINES HOW MUCH HEALTH IS RESTORED AND HOW DOES IT DO IT?
                //      VIA A PICKUP OBJECT SCRIPTABLE OBJECT
                health.ChangeHealth(1);
                break;
            default:
                //TODO: ADD PICKUP LOG TYPE TO Debugger?
                UnityEngine.Debug.LogWarning("Unsupported type: " + e.OriginalInfo.EventType);
                break;
        }
    }


}
