using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Audio")]
public class EntityAudioData : ScriptableObject
{
    //DATA - AUDIO CLIPS
    [SerializeField] public AudioClip SpawnClip { get; }
    [SerializeField] public AudioClip DamageShieldClip { get; }
    [SerializeField] public AudioClip DamageHealthClip { get; }
    [SerializeField] public AudioClip DeathClip { get; }

    //TODO: MIGHT EVALUATE ADDING MORE SOUND HERE - SHOOTING OR OTHER SOUNDS

}
