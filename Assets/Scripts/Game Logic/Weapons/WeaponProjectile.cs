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


    //LIFECYCLE FUNCTIONS
    void FixedUpdate()
    {
        //TODO: MAKE IT MOVE IN THE INTENDED DIRECTION
        lifetime += Time.fixedDeltaTime;
        if(lifetime>data.MaxLifetime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        //TODO: USE PARTICLE MANAGER TO SPAWN PARTICLES

    }


    //FUNCTIONALITIES


    //COLLISION DETECTION


    //UTILITIES

}
