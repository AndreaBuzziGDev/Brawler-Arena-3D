using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundFXEventArgs : EventArgs
{
    //DATA
    public SoundSourceType EventType { get; }
    public AudioClip CarriedAudioClip { get; }


    //CONSTRUCTOR
    public SoundFXEventArgs (SoundSourceType eventType = SoundSourceType.UNBOUND, AudioClip aClip = null)
    {
        this.EventType = eventType;
        this.CarriedAudioClip = aClip;
    }
}
