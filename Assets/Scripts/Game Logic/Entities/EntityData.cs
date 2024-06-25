using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Parameters", menuName = "Entity Data/Entity Params")]
public class EntityData : ScriptableObject
{

    //HEALTH
    [Tooltip("The maximum amount of damage that can be absorbed after being shielded.")]
    [Min(0)]
    [SerializeField] int maxHealth = 5;
    public int MaxHealth => maxHealth;


    //SHIELD CHARGE
    [Tooltip("Shield absorbs damage before health. Any damage instance with at least 1 shield charge is completely denied.")]
    [Min(0)]
    [SerializeField] int maxShield = 5;
    public int MaxShield => maxShield;


    //SHIELD RECHARGE RATE
    [Tooltip("The amount of shield recharged per second.")]
    [Min(0)]
    [SerializeField] float shieldRechargeRate = 1;
    public float ShieldRechargeRate => shieldRechargeRate;


    //SHIELD RECHARGE DELAY
    [Tooltip("The amount of time before the shield starts recharging.")]
    [Min(0)]
    [SerializeField] int shieldCooldownTimer = 7;
    public int ShieldCooldownTimer => shieldCooldownTimer;

    //...

}
