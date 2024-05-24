using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //ENUMS
    //TODO: RENAME ENUM
    public enum WeaponType
    {
        Projectile,
        Melee,
        SuicideBomb
    }

    //INSPECTOR REFERENCES
    [SerializeField] WeaponType wType = WeaponType.Projectile;
    //TODO: THIS IS SUPPOSED TO BE A PREFAB - CHECK/IMPROVE INSPECTOR AND EDITOR SETUP
    //TODO: PROJECTILE SHOULD INSTEAD HAVE A DAMAGE INSTANCE AS DATA
    [SerializeField] WeaponProjectile projectile;
    [SerializeField] WeaponData testWeaponData;//TODO: RENAME AS NORMAL DATA OF THIS WEAPON



    //DATA
    //TODO: THIS IMPLEMENTATION IS EARLY AND SUPPORTS ONLY WEAPONS THAT FIRE BULLETS
    //TODO: ONCE ARCHITECTURE HAS BEEN IMPROVED, CHANGE VISIBILITY AND ORGANIZATION OF THESE DATA
    public Vector2 lastDirection2D = Vector2.up;
    private EntityWithHealth owner;//TODO: EVOLVE THIS FEATURE, IT'S NOT ENOUGH POLISHED YET



    
    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //TODO: HANDLE COOLDOWN AND OTHER STUFF?
        owner = GetComponent<EntityWithHealth>();
        if(!owner)
            Debug.LogError("This Weapon doesn't have holder: " + gameObject.name);
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
        switch(wType)
        {
            case WeaponType.Projectile:
                ShootProjectile();
                break;
            case WeaponType.Melee:
                SwingMelee();
                break;
            case WeaponType.SuicideBomb:
                SelfDestruct();
                break;
            default:
                Debug.Log("Default Weapon Type - No Action");
                break;
        }
    }


    //WEAPON TYPE OPERATION
    protected void ShootProjectile(){

        if(!projectile)
        {
            Debug.LogError("No Projectile on weapon: " + gameObject.name);
            return;
        }
        
        //SPAWN PREFAB
        //TODO: IMPROVE/FIX PROJECTILE SHOOTING BY FOLLOWING GUIDE
        Vector3 pDirection = ShootingDirection();
        Debug.Log("Value 1: " + Quaternion.Euler(ShootingDirection()));
        Debug.Log("Value 2: " + projectile.transform.rotation);

        WeaponProjectile pInstance = Instantiate(
            projectile, 
            transform.position,
            projectile.transform.rotation
        );
        pInstance.ProjectileData = new WeaponProjectileData(testWeaponData, pDirection);
    }

    protected void SwingMelee(){
        //TODO: 
    }

    protected void SelfDestruct(){
        //TODO: IMPLEMENT
        //TODO: FIND A WAY TO IMPLEMENT DAMAGE DELIVERY
        //      SHOULD PROBABLY TRY TO INFLICT DAMAGE TO HITTABLES WITHIN A CERTAIN RADIUS
        //      FOR THE TIME BEING THE SOLUTION IS INSTANT DELIVERY OF DAMAGE

        //TODO: CHANGE AND RENDER DIFFERENTLY THE IMPLEMENTATION
        //      FOR NOW IT SIMPLY INFLICS DAMAGE TO THE PLAYER
        if(testWeaponData)
        {
            PlayerController player = GameController.Instance.GetPlayerAnywhere;
            player.HandleHit(new DamageInstance(testWeaponData));
            if(owner) 
                owner.HandleDeath();
        }
    }



    //UTILITIES
    public Vector3 ShootingDirection() => new Vector3(lastDirection2D.x, 0, lastDirection2D.y).normalized;

}
