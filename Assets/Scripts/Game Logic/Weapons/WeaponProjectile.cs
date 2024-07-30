using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    //DATA
    public WeaponProjectileData ProjectileData { get; set; }


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
        
        ProjectileData.HandleLifetime(Time.fixedDeltaTime);
        if(ProjectileData.HasExpired)
            Destroy(this.gameObject);
        else
            rb.velocity = ProjectileData.Speed * ProjectileData.Direction;
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
            hittable.HandleHit(ProjectileData.DamageInstance);
        }

        Destroy(gameObject);
    }
}
