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
    void Start()
    {
        //ASSIGN REFERENCES
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

    void OnDestroy()
    {
        //TODO: USE PARTICLE MANAGER TO SPAWN PARTICLES

        //TODO: COULD BE NICE TO HAVE AN OBJECT POOLER INSTEAD
        //Debug.Log("Projectile " + gameObject.name + " Destroyed");
    }


    //FUNCTIONALITIES


    //COLLISION DETECTION
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Projectile Collision");
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable != null)
        {
            hittable.HandleHit(projectileData.DamageInstance);
        }

        Destroy(gameObject);
    }
}
