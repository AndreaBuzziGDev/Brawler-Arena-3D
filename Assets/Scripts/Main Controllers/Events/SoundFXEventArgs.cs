using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundFXEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        UNBOUND,//UNBOUND VALUE - SHOULD USE AS LITTLE AS POSSIBLE
        A_FX_PLAYER,
        A_FX_MOB
    }
    
    
    //DATA
    public EType EventType { get; }
    public AudioClip CarriedAudioClip { get; }


    //CONSTRUCTOR
    public SoundFXEventArgs (EType eventType = EType.UNBOUND, AudioClip aClip = null)
    {
        this.EventType = eventType;
        this.CarriedAudioClip = aClip;
    }
}
