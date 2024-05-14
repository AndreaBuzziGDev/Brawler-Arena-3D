using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data")]
public class WeaponData : ScriptableObject
{
    //TODO: EMBELLISH
    
    //DAMAGE
    //TODO: DAMAGE TYPE?
    //TODO: SPECIAL EFFECTS?
    [SerializeField] float damageAmount = 1;
    public float DamageAmount => damageAmount;
}

