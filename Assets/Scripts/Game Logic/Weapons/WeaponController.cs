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


    //DATA
    public Vector2 lastDirection2D = Vector2.up;//TODO: SOLVE THE ISSUE WITH DIRECTION PROPAGATION
    protected EntityWithHealth owner;//TODO: EVOLVE THIS FEATURE, IT'S NOT ENOUGH POLISHED YET


    
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
    public abstract void Operate();


    //WEAPON TYPE OPERATION
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
        if(weaponData)
        {
            PlayerController player = GameController.Instance.GetPlayerAnywhere;
            player.HandleHit(new DamageInstance(weaponData));
            if(owner) 
                owner.HandleDeath();
        }
    }

}
