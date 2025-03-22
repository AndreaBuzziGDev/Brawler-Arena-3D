using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Audio")]
public class EntityAudioData : ScriptableObject
{
    //DATA - TYPE
    [Header("Type")]
    [SerializeField] SoundSourceType type;

    //DATA - AUDIO CLIPS
    [Header("Audio Clips")]
    
    //TODO: TO FURTHER AVOID SPAMMING AUDIO FEED FROM MULTIPLE SPAWN POINTS, IMPLEMENT A COOLDOWN ON SOUND SYSTEM

    //TODO: THESE SHOULD EVOLVE INTO STRUCTS THAT CONTAIN DATA ON EACH CLIP: PLAYBACK MODE, RATE LIMIT, AUDIOCLIP REFERENCE
    
    //TODO: ACTUALLY USE THESE CLIPS
    [SerializeField] AudioClip spawnClip;
    [SerializeField] AudioClipData spawnClipData;
    
    [SerializeField] AudioClip damageShieldClip;
    [SerializeField] AudioClipData damageShieldClipData;
    
    [SerializeField] AudioClip damageHealthClip;
    [SerializeField] AudioClipData damageHealthClipData;
    
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClipData deathClipData;
    

    //DATA GETTERS
    public SoundSourceType Type => type;
    public AudioClip SpawnClip => spawnClip;
    public AudioClip DamageShieldClip => damageShieldClip;
    public AudioClip DamageHealthClip => damageHealthClip;
    public AudioClip DeathClip => deathClip;
    
    //TODO: REPLACE THOSE ABOVE WITH THESE:
    public AudioClipData SpawnClipData => spawnClipData;
    public AudioClipData DamageShieldClipData => damageShieldClipData;
    public AudioClipData DamageHealthClipData => damageHealthClipData;
    public AudioClipData DeathClipData => deathClipData;

}
