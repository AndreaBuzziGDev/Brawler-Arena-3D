using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Audio Data", menuName = "Gameplay Data/Weapon Audio Data")]
public class WeaponAudioData : ScriptableObject
{
    //DATA - AUDIO CLIPS
    [SerializeField] AudioClip operateClip;
    [SerializeField] AudioClip operateCooldownClip;
    [SerializeField] AudioClip hitClip;

    //DATA GETTERS
    public AudioClip OperateClip { get {return operateClip;} }
    public AudioClip OperateCooldownClip { get {return operateCooldownClip;} }
    public AudioClip HitClip { get {return hitClip;} }
}
