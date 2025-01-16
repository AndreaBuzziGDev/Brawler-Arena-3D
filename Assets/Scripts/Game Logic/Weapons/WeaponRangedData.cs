using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Ranged")]
public class WeaponRangedData : WeaponData
{
    //ENUM
    public enum EOperateMode
    {
        SINGLE,
        BURST,
        AUTO,
        CHARGED
    }

    //OPERATE MODE
    [Tooltip("How does the weapon operate?")]
    [SerializeField] EOperateMode operateMode = EOperateMode.SINGLE;
    
    //ATTACK RATE
    //TODO: THIS CAN/SHOULD BE EXPORTED TO SUPERCLASS
    [Tooltip("The weapon attack rate (attacks/second)")]
    [Range(0.1f, 30)]//TODO: THERE ARE WORKAROUNDS TO GO HIGHER THAN 30 ON 30FPS, LIKE MAKING IT SHOOT MULTIPLE PROJECTILES AT A TIME
    [SerializeField] float attackRate = 2;//TODO
    
    //PROJECTILE SPEED
    [Tooltip("The speed module of the projectile")]
    [Range(0, 100)]
    [SerializeField] float projectileSpeed = 10;

    //LIFETIME
    [Tooltip("The duration in second before the projectile vanishes")]
    [Range(0, 20)]
    [SerializeField] float maxLifetime = 10;
    
    //OTHER BEHAVIOURS
    [Tooltip("The duration in second before the projectile vanishes")]
    [SerializeField] bool tresspass = false;
    
    
    //PARTICLES
    [Tooltip("Particle effects associated with this projectile")]
    [SerializeField] protected ParticleData particleShooting;
    [SerializeField] protected ParticleData particleHitting;
    [SerializeField] protected ParticleData particleTrespassing;
    
    //AUDIO
    [Tooltip("Reference to WeaponAudioData Scriptable Object.")]
    [SerializeField] protected WeaponAudioData weaponAudioData;//TODO: MIGHT NEED SPECIFIC WeaponAudioData SUBCLASS

    
    

    //DATA GETTER
    public EOperateMode OperateMode => operateMode;
    public float AttackRate => attackRate;
    public float ProjectileSpeed => projectileSpeed;
    public float MaxLifetime => maxLifetime;
    public bool Tresspass => tresspass;
    
    
    public ParticleData ParticleShooting => particleShooting;
    public ParticleData ParticleHitting => particleHitting;
    public ParticleData ParticleTrespassing => particleTrespassing;
    
    
    //ABSTRACT DATA GETTER CONCRETIZATION
    public override WeaponAudioData WAudioData { get {return weaponAudioData; } } //{ get { return weaponAudioData; } }

}
