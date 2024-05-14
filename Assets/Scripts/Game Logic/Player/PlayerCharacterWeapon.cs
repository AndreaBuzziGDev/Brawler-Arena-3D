using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Weapon", menuName = "Player Data/Player Weapon")]
public class PlayerCharacterWeapon : ScriptableObject
{
    //TODO: EMBELLISH
    
    //DAMAGE
    //TODO: DAMAGE TYPE?
    //TODO: SPECIAL EFFECTS?
    [SerializeField] float damageAmount = 5;
    public float DamageAmount => damageAmount;
}
