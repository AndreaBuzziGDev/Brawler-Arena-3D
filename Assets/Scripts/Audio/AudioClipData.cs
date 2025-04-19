using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Clip Data", menuName = "Audio/Clip Data")]
public class AudioClipData : ScriptableObject {
    //DATA
    [SerializeField] AudioClip clip;
    [SerializeField] SoundPlaybackMode playbackMode = SoundPlaybackMode.Normal;

    [Tooltip("Minimum delay between iterations, expressed in seconds")]
    [Range(0.1f, 5.0f)]
    [SerializeField] float rateLimitTime = 0.1f; //Minimum delay between iterations

    [Tooltip("How many instances of this sound can play at the same time")]
    [Range(1, 30)]
    [SerializeField] int amountLimit = 1;


    //DATA GETTERS
    public AudioClip Clip => clip;
    public SoundPlaybackMode PlaybackMode => playbackMode;
    public float RateLimitTime => rateLimitTime;
    public int AmountLimit => amountLimit;

}
