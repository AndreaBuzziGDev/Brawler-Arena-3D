using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Parameters", menuName = "Entity Data/Entity Params")]
public class EntityData : ScriptableObject
{
    //TODO: EMBELLISH
    //1) DEFINE RANGES MIN AND MAX
    //2) DEFINE STEP

    //HEALTH
    [SerializeField] int maxHealth = 5;
    public int MaxHealth => maxHealth;

    //SHIELD
    [SerializeField] int maxShield = 5;
    [SerializeField] float shieldRechargeRate = 1;
    [SerializeField] int shieldCooldownTimer = 7;

    public int MaxShield => maxShield;
    public float ShieldRechargeRate => shieldRechargeRate;
    public int ShieldCooldownTimer => shieldCooldownTimer;


    //MOVEMENT
    [SerializeField] float movementSpeed = 5;
    public float MovementSpeed => movementSpeed;


    //...

}
