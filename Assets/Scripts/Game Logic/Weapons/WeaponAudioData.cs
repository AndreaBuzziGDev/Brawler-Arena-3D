using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Audio Data", menuName = "Gameplay Data/Weapon Audio Data")]
public class WeaponAudioData : ScriptableObject
{
    //DATA - AUDIO CLIPS
    [Header("Audioclips")]
    [Tooltip("Plays when weapon is successfully used.")]
    [SerializeField] AudioClip operateClip;

    [Tooltip("Plays when weapon is used but it's still in cooldown.")]
    [SerializeField] AudioClip operateCooldownClip;
    
    [Tooltip("Plays when the weapon deals a hit.")]
    [SerializeField] AudioClip hitClip;


    //DATA GETTERS
    public AudioClip OperateClip { get {return operateClip;} }
    //TODO: USE THIS
    public AudioClip OperateCooldownClip { get {return operateCooldownClip;} }
    //TODO: USE THIS
    public AudioClip HitClip { get {return hitClip;} }
}
