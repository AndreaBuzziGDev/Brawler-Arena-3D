using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityWithHealth : MonoBehaviour, IHittable
{
    [Header("Scriptable Object References")]
    //SCRIPTABLE OBJECTS
    [SerializeField] protected EntityData data;
    [SerializeField] protected EntityAudioData audioData;
    [SerializeField] protected EntityParticleData particleData;


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        if (data == null)
            Debug.LogWarning("No Entity EntityData Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if(audioData == null)
            Debug.LogWarning("No Entity EntityAudioData Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if(particleData == null)
            Debug.LogWarning("No Entity EntityParticleData Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //DATA HELPERS
    EntityHealthHelper health;
    EntityShieldHelper shield;

    //SHIELD
    float currentShield = 1;
    float maxShield = 1;

    //SHIELD RECHARGE
    float shieldCooldownTimer = 0;
    float maxShieldCooldownTimer = 1;
    float shieldRechargeRate = 1;


    //DATA-RELATED FUNCTIONS
    bool IsAlive { get { return health.CurrentHealth > 0; } }
    bool IsShielded { get { return currentShield > 0; } }
    bool IsWaitingRecharge { get { return shieldCooldownTimer > 0; } }
    bool IsRecharging { get { return currentShield < maxShield; } }



    //LIFECYCLE FUNCTIONS
    protected virtual void Start()
    {
        DataInitialization();
    }

    protected virtual void Update()
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;

        if(IsAlive)
            HandleShieldAndHealthLogic();
        else
            HandleDeath();
    }




    //INITIALIZATION
    public void DataInitialization()
    {
        health = new EntityHealthHelper(data);
        shield = new EntityShieldHelper(data);


        currentShield = data.MaxShield;
        maxShield = data.MaxShield;

        shieldCooldownTimer = 0;
        maxShieldCooldownTimer = data.ShieldCooldownTimer;
        shieldRechargeRate = data.ShieldRechargeRate;
    }




    
    //TODO: MOVE TO PROTECTED OR DO SOMETHING ELSE
    //      THE SOLUTION MIGHT BE DEVELOPING A DELEGATE METHOD THAT IS THEN SENT TO SOMETHING ELSE FOR EXECUTION.
    //      DATA PROVIDED IN THE METHOD SIGNATURE COULD HELP PROVIDE THE NECESSARY 
    //IHittable INTERFACE IMPLEMENTATION
    public void HandleHit(DamageInstance dInstance)
    {
        Debug.Log(gameObject.name + " has been Hit for " + dInstance.DamageAmount + " Damage.");
        ReceiveDamage(dInstance.DamageAmount);
    }

    public virtual void HandleDeath()
    {
        //DEAHT SOUND
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(audioData.Type, audioData.DeathClip));
        //DEATH PARTICLES
        EventManager<ParticleEffectEventArgs>.Instance.Notify(this, new ParticleEffectEventArgs(particleData.DeathParticleFX, transform.position));
        //DESTROY
        Destroy(this.gameObject);
    }




    //HEALTH AND SHIELD FUNCTIONALITIES
    public void ReceiveDamage(float damageAmount)
    {
        if(IsShielded)
            DamageShield(damageAmount);
        else
            health.DamageHealth(damageAmount);
        
        //SHIELD RECHARGE STUFF
        shieldCooldownTimer = data.ShieldCooldownTimer;
    }


    private void DamageShield(float damageAmount) => currentShield = Mathf.Clamp(currentShield - damageAmount, 0, maxShield);
    private float GetShieldRecharge() => Time.deltaTime * shieldRechargeRate;
    private void RechargeShield(float rechargedAmount) => currentShield = Mathf.Clamp(currentShield + rechargedAmount, 0, maxShield);
    private void DepleteShieldTimer() => shieldCooldownTimer = Mathf.Clamp(shieldCooldownTimer - Time.deltaTime, 0, maxShieldCooldownTimer);

    protected void HandleShieldAndHealthLogic()
    {
        //
        if(IsWaitingRecharge)
            DepleteShieldTimer();
        else if(IsRecharging)
            RechargeShield(GetShieldRecharge());
    }

}
