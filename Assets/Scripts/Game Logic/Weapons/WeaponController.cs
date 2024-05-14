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
    [SerializeField] Vector3 projectileShootingPosition = Vector3.zero;


    
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
            WeaponProjectile pInstance = Instantiate(projectile, projectileShootingPosition, Quaternion.identity);
            
            //
            Debug.Log("Shooting Direction: " + ShootingDirection());
            pInstance.projectileDirection = ShootingDirection();
        }

    }


    //UTILITIES
    public Vector3 ShootingDirection() => (projectileShootingPosition - transform.position).normalized;

}
