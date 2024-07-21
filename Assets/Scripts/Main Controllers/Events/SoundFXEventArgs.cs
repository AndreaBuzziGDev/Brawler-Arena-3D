using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundFXEventArgs : EventArgs
{
    //DATA
    private EType eventType;
    public EType EventType { get { return eventType; } }

    private AudioClip carriedAudioClip;
    public AudioClip CarriedAudioClip { get {return carriedAudioClip;} }


    //CONSTRUCTOR
    public SoundFXEventArgs (EType eventType = EType.UNBOUND, AudioClip aClip = null)
    {
        this.eventType = eventType;
        this.carriedAudioClip = aClip;
    }


    //ENUMS
    public enum EType
    {
        UNBOUND,//UNBOUND VALUE - SHOULD NOT USE
        A_FX_PLAYER,
        A_FX_MOB
    }
}
