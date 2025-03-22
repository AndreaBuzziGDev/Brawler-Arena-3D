using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Clip Data", menuName = "Audio/Clip Data")]
public class AudioClipData : ScriptableObject
{
    //DATA
    //TODO: ADD HEADERS AND DESCRIPTORS
    [SerializeField] AudioClip clip;
    [SerializeField] SoundPlaybackMode playbackMode = SoundPlaybackMode.Normal;
    [SerializeField] float rateLimitTime = 0.1f; //Minimum delay between iterations
    [SerializeField] int amountLimit = 1;//TODO: MAKE THIS AVAILABLE AS RANGE IN EDITOR
    
    //DATA GETTERS
    public AudioClip Clip => clip;
    public SoundPlaybackMode PlaybackMode => playbackMode;
    public float RateLimitTime => rateLimitTime;
    public int AmountLimit => amountLimit;
    
}
