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

    //TODO: WHEN THE GAME IS PAUSED THIS ALSO IS PAUSED
    void FixedUpdate()
    {
        //TODO: MAKE IT MOVE IN THE INTENDED DIRECTION
        lifetime += Time.fixedDeltaTime;
        if(lifetime > data.MaxLifetime)
            Destroy(this.gameObject);
        else
            rb.MovePosition(this.transform.position + (Time.fixedDeltaTime * data.ProjectileSpeed * projectileDirection));

    }

    void OnDestroy()
    {
        //TODO: USE PARTICLE MANAGER TO SPAWN PARTICLES

    }


    //FUNCTIONALITIES


    //COLLISION DETECTION
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        //other.GetComponent<>();

        Destroy(this);
    }


    //UTILITIES

}
