using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: MIGHT NEED FURTHER RAMIFICATION WITH SEVERAL LEVELS OF ABSTRACTION TO HANDLE DIFFERENT WEAPON TYPES
//TODO: THIS IS MEANT AS SUICIDE BOMBER ENEMY
public class EnemyController : EntityWithHealth
{
    //DATA
    [SerializeField] WeaponController enemyWeapon;


    //ON COLLISION


    //FUNCTIONALITIES


    //WEAPON OPERATE


    //EntityWithHealth CONCRETIZATION
    public override void HandleDeath()
    {
        Debug.Log("EnemyController - HandleDeath - TODO: PARTICLE AND OTHER DEATH STUFF");
        Destroy(gameObject);
    }
    

}
