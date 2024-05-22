using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] WeaponData data;


    //DATA
    //TODO: IMPROVE SOLUTION, WEAPON CONTROLLER SHOULD HAVE A BETTER SYSTEM TO PROPAGATE THIS INFORMATION
    //      SHOULD BE ENOUGH TO MAKE A PROPERTY SETTER
    public Vector3 projectileDirection = Vector3.up;
    private float lifetime = 0.0f;

    //TODO: USE REQUIRED ON COMPONENTS LIKE RIGID BODY?
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
        
        lifetime += Time.fixedDeltaTime;
        if(lifetime > data.MaxLifetime)
            Destroy(this.gameObject);
        else
            rb.velocity = data.ProjectileSpeed * projectileDirection;

    }

    void OnDestroy()
    {
        //TODO: USE PARTICLE MANAGER TO SPAWN PARTICLES

        //TODO: COULD BE NICE TO HAVE AN OBJECT POOLER INSTEAD
        Debug.Log("Projectile " + gameObject.name + " Destroyed");

    }


    //FUNCTIONALITIES


    //COLLISION DETECTION
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable != null)
        {
            hittable.HandleHit(new DamageInstance(data));
        }

        Destroy(gameObject);
    }


    //UTILITIES

}
