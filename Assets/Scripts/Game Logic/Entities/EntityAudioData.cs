using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Audio")]
public class EntityAudioData : ScriptableObject
{
    //DATA - TYPE
    [Header("Type")]
    [SerializeField] SoundFXEventArgs.EType type;

    //DATA - AUDIO CLIPS
    [Header("Audio Clips")]
    //TODO: USE THIS
    //TODO: TO AVOID SPAMMING AUDIO FEED, MAKE ENEMIES SPAWN IN GROUPS
    //TODO: TO FURTHER AVOID SPAMMING AUDIO FEED FROM MULTIPLE SPAWN POINTS, IMPLEMENT A COOLDOWN ON SOUND SYSTEM
    [SerializeField] AudioClip spawnClip;
    [SerializeField] AudioClip damageShieldClip;
    [SerializeField] AudioClip damageHealthClip;
    [SerializeField] AudioClip deathClip;

    //DATA GETTERS
    public SoundFXEventArgs.EType Type => type;
    public AudioClip SpawnClip => spawnClip;
    public AudioClip DamageShieldClip => damageShieldClip;
    public AudioClip DamageHealthClip => damageHealthClip;
    public AudioClip DeathClip => deathClip;

}
