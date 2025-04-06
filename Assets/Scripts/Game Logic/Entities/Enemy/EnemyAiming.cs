using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: REFACTOR THIS. THIS WORKS PERFECTLY AS A SUICIDE BOMBER UNIT, BUT THE GAME WILL NEED TO WORK WITH OTHER SOLUTIONS AS WELL.
public class EnemyAiming : EntityWithAiming{
    
    [Header("Inspector References")]
    [SerializeField] WeaponController enemyWeapon;
    
    
    //TODO: DEVELOP BEHAVIOUR FOR GAINING AIMING
    //      UNITS SHOULD BE ABLE TO AIM
    //      THEIR AIM ACQUISITION SHOULD BE BASED ON PARAMETERS THAT ALLOW TO DISCERN WHAT TYPE OF UNIT IS DOING THE AIMING
    //      BASED ON WHO IS AIMING, BEHAVIOUR CHANGES
    //      EG:
    //      SUICIDE BOMBERS SHOULD TRY TO GET CLOSE TO THE TARGET AND SUICIDE BY COLLIDING AGAINST IT
    //      ENEMIES THAT CAN SHOOT SHOULD TRY TO SHOOT THE TARGET (WHEN ON SIGHT)
    //      
    //ADDITIONAL:
    //      ALL ENEMIES MIGHT BEHAVE AS SUICIDE BOMBERS, WITH LOWERED DAMAGE 
    //      POSSIBLY WITHOUT INTENTIONALLY ACTING AS SUICIDE UNITS IN REGULAR PLAY


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected void OnValidate()
    {
        if (enemyWeapon == null)
            Debug.LogWarning("No Enemy Weapon Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //ON COLLISION
    //TODO: KEEP THIS ONLY FOR ENEMIES THAT ARE SUICIDE BOMBERS
    //      UNITS CAN REACT TO COLLISION
    //      REGULAR UNITS ARE PUSHED BACK 
    private void OnCollisionEnter(Collision other)
    {
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable is PlayerHittable){
            //OPERATE WEAPON
            enemyWeapon.Operate();
        }
    }
}
