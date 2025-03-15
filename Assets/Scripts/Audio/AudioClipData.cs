using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSound", menuName = "Audio/Sound Data")]
public class AudioClipData : ScriptableObject
{
    public AudioClip clip;
    public SoundPlaybackMode playbackMode = SoundPlaybackMode.Normal;
    public float rateLimitTime = 0.1f; //Minimum delay between iterations
}
