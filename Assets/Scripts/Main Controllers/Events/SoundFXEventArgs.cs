using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundFXEventArgs : ManagedEvent
{
    //DATA
    private EType eventType;
    public EType EventType { get { return eventType; } }


    //CONSTRUCTOR
    public SoundFXEventArgs (EType eventType = EType.UNBOUND)
    {
        this.eventType = eventType;
    }

    //ABSTRACT CONCRETIZATION
    public override int EventId{ get { return (int) eventType; } }


    //ENUMS
    public enum EType
    {
        UNBOUND,//UNBOUND VALUE - SHOULD NOT USE
        A_FX_MOB_DEATH_SUICIDE_BOMBER
    }
}
