using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Audio")]
public class EntityAudioData : ScriptableObject {
    //DATA - TYPE
    [Header("Type")]
    [SerializeField] SoundSourceType type;

    //DATA - AUDIO CLIPS
    [Header("Audio Clips")]

    [SerializeField] AudioClipData spawnClipData;
    [SerializeField] AudioClipData damageShieldClipData;
    [SerializeField] AudioClipData damageHealthClipData;
    [SerializeField] AudioClipData deathClipData;


    //DATA GETTERS
    public SoundSourceType Type => type;
    public AudioClipData SpawnClipData => spawnClipData;
    public AudioClipData DamageShieldClipData => damageShieldClipData;
    public AudioClipData DamageHealthClipData => damageHealthClipData;
    public AudioClipData DeathClipData => deathClipData;

}
