using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSBombController : WeaponController
{
    public override void Operate(){
        //TODO: CHANGE THE IMPLEMENTATION - FOR NOW IT SIMPLY INFLICS DAMAGE TO THE PLAYER
        //      SHOULD PROBABLY TRY TO INFLICT DAMAGE TO HITTABLES WITHIN A CERTAIN RADIUS
        //      FOR THE TIME BEING THE SOLUTION IS INSTANT DELIVERY OF DAMAGE
        //      COULD EFFECTIVELY WORK WITH AN EVENT-BASED DAMAGE DELIVERY
        if(weaponData)
        {
            PlayerController player = GameController.Instance.GetPlayerAnywhere;
            player.HandleHit(new DamageInstance(weaponData));
            if(owner) 
                owner.HandleDeath();
        }
    }
}
