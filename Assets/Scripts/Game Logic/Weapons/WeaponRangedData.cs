using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Ranged")]
public class WeaponRangedData : WeaponData
{
    //SPEED
    [Tooltip("The speed module of the projectile")]
    [Range(0, 100)]
    [SerializeField] float projectileSpeed = 10;


    //LIFETIME
    [Tooltip("The duration in second before the projectile vanishes")]
    [Range(0, 20)]
    [SerializeField] float maxLifetime = 10;
    
    //BEHAVIOUR
    [Tooltip("The duration in second before the projectile vanishes")]
    [SerializeField] bool tresspass = false;
    
    
    //PARTICLES
    [Tooltip("Particle effects associated with this projectile")]
    [SerializeField] protected EntityParticleData particleShooting;
    [SerializeField] protected EntityParticleData particleHitting;
    [SerializeField] protected EntityParticleData particleTrespassing;
    
    //AUDIO
    [Tooltip("Reference to WeaponAudioData Scriptable Object.")]
    [SerializeField] protected WeaponAudioData weaponAudioData;//TODO: MIGHT NEED SPECIFIC WeaponAudioData SUBCLASS

    
    

    //DATA GETTER
    public float ProjectileSpeed => projectileSpeed;
    public float MaxLifetime => maxLifetime;
    public bool Tresspass => tresspass;
    
    
    public EntityParticleData ParticleShooting;
    public EntityParticleData ParticleHitting;
    public EntityParticleData ParticleTrespassing;
    
    
    //ABSTRACT DATA GETTER CONCRETIZATION
    public override WeaponAudioData WAudioData { get {return weaponAudioData; } } //{ get { return weaponAudioData; } }

}
