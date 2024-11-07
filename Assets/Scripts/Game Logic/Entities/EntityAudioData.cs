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
    [SerializeField] AudioClip spawnClip;
    [SerializeField] AudioClip damageShieldClip;
    [SerializeField] AudioClip damageHealthClip;
    [SerializeField] AudioClip deathClip;

    //DATA GETTERS
    public SoundFXEventArgs.EType Type { get { return type; } }
    public AudioClip SpawnClip { get {return spawnClip;} }
    public AudioClip DamageShieldClip { get {return damageShieldClip;} }
    public AudioClip DamageHealthClip { get {return damageHealthClip;} }
    public AudioClip DeathClip { get {return deathClip;} }

}
