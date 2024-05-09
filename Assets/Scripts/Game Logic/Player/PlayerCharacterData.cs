using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterData : ScriptableObject
{
    //HEALTH
    [SerializeField] float maxHealth = 5;


    //SHIELD
    [SerializeField] float maxShield = 5;
    [SerializeField] float shieldRechargeRate = 1;
    [SerializeField] float shieldCooldownTimer = 7;


    //MOVEMENT
    [SerializeField] float movementSpeed = 5;

}
