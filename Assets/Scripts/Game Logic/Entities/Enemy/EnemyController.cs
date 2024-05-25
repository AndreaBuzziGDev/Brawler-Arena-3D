using System;
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
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enemy Collision");
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable is PlayerController)
        {
            //OPERATE WEAPON
            enemyWeapon.Operate();
        }
    }

    //FUNCTIONALITIES
    //...


    //EntityWithHealth CONCRETIZATION
    public override void HandleDeath()
    {
        Debug.Log("EnemyController - HandleDeath - TODO: PARTICLE AND OTHER DEATH STUFF");
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(SoundFXEventArgs.EType.A_FX_MOB_DEATH_SUICIDE_BOMBER));
        Destroy(gameObject);
    }
    

}
