using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Audio Data", menuName = "Gameplay Data/Weapon Audio Data")]
public class WeaponAudioData : ScriptableObject
{
    //DATA - AUDIO CLIPS
    [Header("Audioclips")]
    [Tooltip("The type of this audio data.")]
    [SerializeField] SoundFXEventArgs.EType audioType = SoundFXEventArgs.EType.A_FX_MOB;
    
    [Tooltip("Plays when weapon is successfully used.")]
    [SerializeField] AudioClip operateClip;

    [Tooltip("Plays when weapon is used but it's still in cooldown.")]
    [SerializeField] AudioClip operateCooldownClip;
    
    [Tooltip("Plays when the weapon deals a hit.")]
    [SerializeField] AudioClip hitClip;
    //TODO: DIFFER HITTING HITTABLE WITH HITTING A RANDOM OBSTACLE THAT DESTROYS THE PROJECTILE
    
    


    //DATA GETTERS
    public SoundFXEventArgs.EType AudioType { get {return audioType;} }
    public AudioClip OperateClip { get {return operateClip;} }
    //TODO: USE THIS
    public AudioClip OperateCooldownClip { get {return operateCooldownClip;} }
    //TODO: USE THIS
    public AudioClip HitClip { get {return hitClip;} }
}
