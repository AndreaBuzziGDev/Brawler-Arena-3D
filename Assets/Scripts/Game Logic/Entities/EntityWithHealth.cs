using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityWithHealth : MonoBehaviour, IHittable
{
    //SCRIPTABLE OBJECTS
    [Header("Scriptable Object References")]
    [SerializeField] protected EntityData data;
    [SerializeField] protected EntityAudioData audioData;
    [SerializeField] protected ParticleData particleData;


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        if (data == null)
            Debug.LogWarning("No Entity EntityData Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if(audioData == null)
            Debug.LogWarning("No Entity EntityAudioData Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if(particleData == null)
            Debug.LogWarning("No Entity ParticleData Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //DATA HELPERS
    protected EntityHealthHelper health;
    protected EntityShieldHelper shield;
    
    //DATA HELPERS ACCESSORS
    ///HEALTH SUB-ACCESSOR
    public float CurrentHealth { get { return health.CurrentHealth; } }
    public float MaxHealth { get { return health.MaxHealth; } }
    
    ///SHIELD SUB-ACCESSOR
    public float CurrentShield { get { return shield.CurrentShield; } }
    public float MaxShield { get { return shield.MaxShield; } }
    public float ShieldCooldownTimer { get { return shield.ShieldCooldownTimer; } }
    public float MaxShieldCooldownTimer { get { return shield.MaxShieldCooldownTimer; } }
    public float ShieldRechargeRate { get { return shield.ShieldRechargeRate; } }



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

        if(health.IsAlive)
            shield.HandleLogic();
        else
            HandleDeath();
    }




    //INITIALIZATION
    void DataInitialization()
    {
        health = new EntityHealthHelper(data);
        shield = new EntityShieldHelper(data);
    }





    //IHittable INTERFACE IMPLEMENTATION
    
    //TODO: MOVE TO PROTECTED OR DO SOMETHING ELSE
    //      THE SOLUTION MIGHT BE DEVELOPING A DELEGATE METHOD THAT IS THEN SENT TO SOMETHING ELSE FOR EXECUTION.
    //      DATA PROVIDED IN THE METHOD SIGNATURE COULD HELP PROVIDE THE NECESSARY 

    public void HandleHit(DamageInstance dInstance)
    {
        Debug.Log(gameObject.name + " has been Hit for " + dInstance.DamageAmount + " Damage.");
        ReceiveDamage(dInstance.DamageAmount);
    }

    public virtual void HandleDeath()
    {
        //DEATH SOUND
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(audioData.Type, audioData.DeathClip));
        //DEATH PARTICLES
        EventManager<ParticleEffectEventArgs>.Instance.Notify(this, new ParticleEffectEventArgs(particleData.ParticleFX, transform.position));
        //DESTROY
        Destroy(this.gameObject);
    }




    //HEALTH AND SHIELD FUNCTIONALITIES
    //TODO: MAKE PROTECTED
    public void ReceiveDamage(float damageAmount)
    {
        if(shield.IsShielded)
            shield.ChangeShield(-damageAmount);
        else
            health.ChangeHealth(-damageAmount);
        
        //SHIELD RECHARGE STUFF
        shield.ResetShieldTimer();
    }
    
    public void Heal(float healAmount)
    {
        health.ChangeHealth(healAmount);
    }


}
