using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Audio Data", menuName = "Gameplay Data/Weapon Audio Data")]
public class WeaponAudioData : ScriptableObject
{
    //DATA - AUDIO CLIPS
    [Header("Audioclips")]
    [Tooltip("The type of this audio data.")]
    [SerializeField] SoundSourceType audioType = SoundSourceType.AUDIO_FX_MOB;
    
    //TODO: USE AUDIO CLIP DATA
    [Tooltip("Plays when weapon is successfully used.")]
    [SerializeField] AudioClip operateClip;//TODO: DISMISS AFTER MANAGING SCRIPTABLE OBJECTS
    [SerializeField] AudioClipData operateClipData;

    [Tooltip("Plays when weapon is used but it's still in cooldown.")]
    [SerializeField] AudioClip operateCooldownClip;//TODO: DISMISS AFTER MANAGING SCRIPTABLE OBJECTS
    [SerializeField] AudioClipData operateCooldownClipData;
    
    [Tooltip("Plays when the weapon deals a hit.")]
    [SerializeField] AudioClip hitClip;//TODO: DISMISS AFTER MANAGING SCRIPTABLE OBJECTS
    [SerializeField] AudioClipData hitClipData;
    //TODO: DIFFER HITTING HITTABLE WITH HITTING A RANDOM OBSTACLE THAT DESTROYS THE PROJECTILE
    
    


    //DATA GETTERS
    public SoundSourceType AudioType => audioType;
    public AudioClipData OperateClipData => operateClipData;
    //TODO: USE THIS
    public AudioClipData OperateCooldownClipData => operateCooldownClipData;
    //TODO: USE THIS
    public AudioClipData HitClipData => hitClipData;
}
