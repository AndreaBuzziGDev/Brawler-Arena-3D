using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //ENUMS
    public enum WeaponType
    {
        Projectile,
        Melee
    }

    //INSPECTOR REFERENCES
    [SerializeField] WeaponProjectile projectile;//TODO: THIS IS SUPPOSED TO BE A PREFAB - CHECK/IMPROVE INSPECTOR AND EDITOR SETUP



    //DATA
    //TODO: THIS IMPLEMENTATION IS EARLY AND SUPPORTS ONLY WEAPONS THAT FIRE BULLETS
    //TODO: ONCE ARCHITECTURE HAS BEEN IMPROVED, CHANGE VISIBILITY AND ORGANIZATION OF THESE DATA
    public Vector2 lastDirection2D = Vector2.up;



    
    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //TODO: HANDLE COOLDOWN AND OTHER STUFF?

    }

    // Update is called once per frame
    void Update()
    {
        //TODO: HANDLE COOLDOWN AND OTHER STUFF?

    }


    //FUNCTIONALITIES
    public void Operate()
    {
        //TODO: THIS IMPLEMENTATION IS EARLY AND SUPPORTS ONLY WEAPONS THAT FIRE BULLETS
        
        
        //TODO: SWITCH ON WEAPON TYPE
        if(projectile)
        {
            //SPAWN PREFAB
            Vector3 pDirection = ShootingDirection();
            Debug.Log("Value 1: " + Quaternion.Euler(ShootingDirection()));
            Debug.Log("Value 2: " + projectile.transform.rotation);

            WeaponProjectile pInstance = Instantiate(
                projectile, 
                transform.position,
                projectile.transform.rotation
            );
            pInstance.projectileDirection = pDirection;
        }

    }


    //UTILITIES
    public Vector3 ShootingDirection() => new Vector3(lastDirection2D.x, 0, lastDirection2D.y).normalized;

}
