using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    //ENUMS
    //TODO: THIS IS FUNDAMENTALLY USELESS UNTIL IMPLEMENTED TO HAVE SOME CONSEQUENCES ON GAMEPLAY
    /*
    //TODO: RENAME ENUM
    public enum WeaponType
    {
        Projectile,//TODO: RENAME RANGED
        Melee,
        SuicideBomb
    }

    //INSPECTOR REFERENCES
    [SerializeField] WeaponType wType = WeaponType.Projectile;
    */
    
    //INSPECTOR REFERENCES
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected WeaponAudioData weaponAudioData;



    //DATA
    //TODO: ADDRESS AND POSSIBLY SOLVE THIS
    protected IAimingCapable ownerAiming;
    protected EntityWithHealth ownerEntity;


    
    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //TODO: IMPLEMENT COOLDOWN HANDLING AND OTHER THINGS?
        ownerAiming = GetComponent<IAimingCapable>();
        ownerEntity = GetComponent<EntityWithHealth>();
        if(weaponData == null)
            Debug.LogError("This Weapon doesn't have any data: " + gameObject.name);
        else if((ownerEntity == null) && weaponData.NeedsOwnerToOperate)//TODO: DIFFERENTIATE BETWEEN AIMING AND ENTITY
            Debug.LogError("This Weapon doesn't have holder: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: HANDLE COOLDOWN AND OTHER STUFF?
        
    }


    //FUNCTIONALITIES
    public abstract void Operate();
}
