using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: MIGHT NEED FURTHER RAMIFICATION WITH SEVERAL LEVELS OF ABSTRACTION TO HANDLE DIFFERENT WEAPON TYPES
//TODO: THIS IS MEANT AS SUICIDE BOMBER ENEMY
public class EnemyController : EntityWithHealth
{
    //DATA
    [SerializeField] WeaponController enemyWeapon;//TODO: IN FURTHER EVOLUTIONS, THIS SHOULD MOVE IN A CHILD SCRIPT OF EntityWithAiming


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        if (enemyWeapon == null)
            Debug.LogWarning("No Enemy Weapon Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //ON COLLISION
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable is PlayerHittable)
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
        EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(SoundFXEventArgs.EType.A_FX_MOB, audioData.DeathClip));
        Destroy(gameObject);
    }

}
