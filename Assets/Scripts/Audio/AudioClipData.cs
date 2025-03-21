using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Clip Data", menuName = "Audio/Clip Data")]
public class AudioClipData : ScriptableObject
{
    public AudioClip clip;
    public SoundPlaybackMode playbackMode = SoundPlaybackMode.Normal;
    public float rateLimitTime = 0.1f; //Minimum delay between iterations
    public int amountLimit = 1;//TODO: MAKE THIS AVAILABLE AS RANGE IN EDITOR
}
