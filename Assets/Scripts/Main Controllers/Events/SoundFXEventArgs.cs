using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundFXEventArgs : EventArgs {
    //DATA
    public SoundSourceType EventType { get; }
    public AudioClipData ClipData { get; }


    //CONSTRUCTOR
    public SoundFXEventArgs(AudioClipData clipData) {
        ClipData = clipData;
    }
}
