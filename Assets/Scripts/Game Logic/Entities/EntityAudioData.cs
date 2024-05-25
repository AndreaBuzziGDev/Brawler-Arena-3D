using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Audio")]
public class EntityAudioData : ScriptableObject
{
    //DATA - AUDIO CLIPS
    [SerializeField] AudioClip spawnClip;
    [SerializeField] AudioClip damageShieldClip;
    [SerializeField] AudioClip damageHealthClip;
    [SerializeField] AudioClip deathClip;
    //TODO: MIGHT EVALUATE ADDING MORE SOUND HERE - SHOOTING OR OTHER SOUNDS

    public AudioClip SpawnClip { get {return spawnClip;} }
    public AudioClip DamageShieldClip { get {return damageShieldClip;} }
    public AudioClip DamageHealthClip { get {return damageHealthClip;} }
    public AudioClip DeathClip { get {return deathClip;} }

}
