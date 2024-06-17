using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Ranged")]
public class WeaponRangedData : WeaponData
{
    //PROJECTILE DATA
    [SerializeField] float projectileSpeed = 10;
    public float ProjectileSpeed => projectileSpeed;

    [SerializeField] float maxLifetime = 10;
    public float MaxLifetime => maxLifetime;
}
