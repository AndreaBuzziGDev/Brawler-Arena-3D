using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: REFACTOR THIS. THIS WORKS PERFECTLY AS A SUICIDE BOMBER UNIT, BUT THE GAME WILL NEED TO WORK WITH OTHER SOLUTIONS AS WELL.
public class EnemyAiming : EntityWithAiming
{
    [Header("Inspector References")]
    [SerializeField] WeaponController enemyWeapon;


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
    //      REGULAR UNITS SHOULD "REACT" BY PUSHING THE PLAYER BACK
    private void OnCollisionEnter(Collision other)
    {
        IHittable hittable = other.gameObject?.GetComponent<IHittable>();
        if(hittable is PlayerHittable){
            //OPERATE WEAPON
            enemyWeapon.Operate();
        }
    }
}
