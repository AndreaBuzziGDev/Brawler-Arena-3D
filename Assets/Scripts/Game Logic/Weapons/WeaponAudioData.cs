using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Audio Data", menuName = "Gameplay Data/Weapon Audio Data")]
public class WeaponAudioData : ScriptableObject {
    //DATA - AUDIO CLIPS
    [Header("Audioclips")]
    [Tooltip("The type of this audio data.")]
    [SerializeField] SoundSourceType audioType = SoundSourceType.AUDIO_FX_MOB;

    [Tooltip("Plays when weapon is successfully used.")]
    [SerializeField] AudioClipData operateClipData;

    [Tooltip("Plays when the weapon deals a successful hit.")]
    [SerializeField] AudioClipData hitClipData;

    [Tooltip("Plays when the weapon misses or hits unsuccessfully")]
    [SerializeField] AudioClipData missClipData;



    //DATA GETTERS
    public SoundSourceType AudioType => audioType;
    public AudioClipData OperateClipData => operateClipData;
    public AudioClipData HitClipData => hitClipData;
    public AudioClipData MissClipData => missClipData;

}
