using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    //DATA
    private bool isDataInitialized = false;
    private WeaponProjectileData projectileData;
    
    //DATA SETTER
    public WeaponProjectileData ProjectileData 
    { 
        get => projectileData; 
        set
        {
            if(!isDataInitialized)
            {
                isDataInitialized = true;
                projectileData = value;
            }
            else
                Debug.LogWarning("Projectile Data have already been initialized.");
        } 
    }


    //TECHNICAL DATA
    Rigidbody rb;


    //LIFECYCLE FUNCTIONS
    void Awake()
    {
        //ASSIGN REFERENCES
        //TODO: HANDLE/STREAMLINE/IMPROVE THIS WITH HARD REQUIREMENT?
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //CONDITION
        if(!GameController.Instance.IsPlaying)
            return;
        
        projectileData.HandleLifetime(Time.fixedDeltaTime);
        if(projectileData.HasExpired)
            Destroy(this.gameObject);
        else
            rb.velocity = projectileData.Speed * projectileData.Direction;
    }


    void OnEnable()
    {

    }

    //TODO: IF AN OBJECT POOLER WILL BE USED FOR PROJECTILES, CHANGE THIS TO OnDisable
    //      ALSO, ON DISABLE MIGHT NECESSITATE projectileData DE-INITIALIZATION
    void OnDestroy()
    {
        //TODO: COULD BE NICE TO HAVE AN OBJECT POOLER ON TOP OF THE PARTICLE SPAWNER
        
        //TODO: USE PARTICLE MANAGER TO SPAWN PARTICLES
        
        //Debug.Log("Projectile " + gameObject.name + " Destroyed");
    }


    //FUNCTIONALITIES


    //COLLISION DETECTION
    private void OnTriggerEnter(Collider other)
    {
        //HIT SOUND
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(projectileData.WData.WAudioData.AudioType, projectileData.WData.WAudioData.HitClip));
        //HIT PARTICLES
        //TODO: UNCOMMENT
        //TODO: UPGRADE THE OTHER CLASS LIKE I DID THE AudioSourceManager TO NOTIFY NULL ARGUMENTS
        //EventManager<ParticleEffectEventArgs>.Instance.Notify(this, new ParticleEffectEventArgs(projectileData.WData.ParticleHitting, transform.position));
        
        
        //Debug.Log("Projectile Collision");
        //TODO: DIFFER HITTING HITTABLE WITH HITTING A RANDOM OBSTACLE THAT DESTROYS THE PROJECTILE
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable != null)
        {
            hittable.HandleHit(projectileData.DamageInstance);
        }

        //TODO: TRESPASS MECHANICS
        Destroy(gameObject);
    }
}
