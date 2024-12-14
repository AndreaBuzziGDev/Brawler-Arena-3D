using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthHelper
{
    //DATA
    float currentHealth = 1;
    float maxHealth = 1;


    //DATA FUNCTIONS
    public float CurrentHealth { get { return currentHealth; } }
    public float MaxHealth { get { return maxHealth; } }


    //CONSTRUCTOR
    public EntityHealthHelper(EntityData data)
    {
        currentHealth = data.MaxHealth;
        maxHealth = data.MaxHealth;
    }


    //FUNCTIONALITIES
    public void DamageHealth(float damageAmount) => currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
    public void RestoreHealth(float damageAmount) => currentHealth = Mathf.Clamp(currentHealth + damageAmount, 0, maxHealth);

}
