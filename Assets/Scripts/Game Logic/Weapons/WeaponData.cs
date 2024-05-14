using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data")]
public class WeaponData : ScriptableObject
{
    //TODO: EMBELLISH

    
    //TODO: DAMAGE TYPE?
    //TODO: SPECIAL EFFECTS?
    //DAMAGE
    [SerializeField] float damageAmount = 1;
    public float DamageAmount => damageAmount;


    //
    [SerializeField] float projectileSpeed = 10;
    public float ProjectileSpeed => projectileSpeed;


    [SerializeField] float maxTravelDistance = 50;
    public float MaxTravelDistance => maxTravelDistance;

}

