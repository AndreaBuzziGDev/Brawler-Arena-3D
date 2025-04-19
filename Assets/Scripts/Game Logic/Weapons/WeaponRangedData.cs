using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Ranged")]
public class WeaponRangedData : WeaponData {
    //ENUM
    public enum EOperateMode {
        SINGLE,
        BURST,
        AUTO,
        CHARGED
    }
    //TODO: IMPROVE CHARGED MODE
    //NEEDS FEEDBACK, LIKE AUDIO AND VISUAL FEEDBACK
    //1) CHARGING SOUND
    //2) (?) EARLY INTERRUPTED CHARGE SOUND
    //3) LASER/SOME GUIDANCE FOR SHOT DIRECTION

    //PROJECTILE
    [Tooltip("Reference to the projectile Prefab.")]
    [SerializeField] WeaponProjectile projectile;

    //OPERATE MODE
    [Tooltip("How does the weapon operate?")]
    [SerializeField] EOperateMode operateMode = EOperateMode.SINGLE;

    //ATTACK RATE
    //TODO: THIS CAN/SHOULD BE EXPORTED TO SUPERCLASS
    [Tooltip("The weapon attack rate (attacks/second)")]
    [Range(0.1f, 30)]
    [SerializeField] float attackRate = 2;

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


    //TYPE SPECIFIC BEHAVIOURS
    //TODO: SET UP EDITOR SO THAT IT SHOWS THESE DATA ONLY WHERE IT MAKES SENSE FOR IT TO DO SO.
    [Tooltip("The times whe weapon fires in a burst")]
    [SerializeField] int burstCount = 3;
    [Tooltip("The minimum time between the end of a burst and the start of a new one")]
    [SerializeField] float burstCooldown = 0.5f;


    //
    //TODO: NEW MECHANIC - MULTIPLE CHARGE LEVELS
    [Tooltip("The overall time required to charge the weapon, expressed in Attack Rate x Seconds")]
    [SerializeField] float chargeTime = 2;





    //PARTICLES
    //TODO: THIS MIGHT BE HANDLED IN A DEDICATED CLASS, LIKE I ALREADY MARKED FOR weaponAudioData
    [Tooltip("Particle effects associated with this projectile")]
    [SerializeField] protected ParticleData particleShooting;
    [SerializeField] protected ParticleData particleHitting;
    [SerializeField] protected ParticleData particleTrespassing;

    //AUDIO
    [Tooltip("Reference to WeaponAudioData Scriptable Object.")]
    [SerializeField] protected WeaponAudioData weaponAudioData;//TODO: MIGHT NEED SPECIFIC WeaponAudioData SUBCLASS




    //DATA GETTER
    public EOperateMode OperateMode => operateMode;
    public WeaponProjectile Projectile => projectile;
    public float AttackRate => attackRate;
    public float ProjectileSpeed => projectileSpeed;
    public float MaxLifetime => maxLifetime;
    public bool Tresspass => tresspass;

    public int BurstCount => burstCount;
    public float BurstCooldown => burstCooldown;

    public float ChargeTime => chargeTime;





    public ParticleData ParticleShooting => particleShooting;
    public ParticleData ParticleHitting => particleHitting;
    public ParticleData ParticleTrespassing => particleTrespassing;


    //ABSTRACT DATA GETTER CONCRETIZATION
    public override WeaponAudioData WAudioData { get { return weaponAudioData; } } //{ get { return weaponAudioData; } }



    //REFERENCE VALIDATION
#if UNITY_EDITOR
    void OnValidate() {
        if (!projectile)
            Debug.LogWarning("No Projectile on Weapon Data: \n" + AssetDatabase.GetAssetPath(this));
    }
#endif

}
