using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Self-Destruct")]
public class WeaponSBombData : WeaponData
{
    //TODO: EMBELLISH
    [SerializeField] float effectiveRadius = 10;
    public float EffectiveRadius => effectiveRadius;

}
