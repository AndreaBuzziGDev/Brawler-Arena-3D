using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthHelper
{
    //DATA
    float currentHealth = 1;
    float maxHealth = 1;

    //DATA GETTERS
    public float CurrentHealth { get { return currentHealth; } }
    public float MaxHealth { get { return MaxHealth; } }



    //DATA FUNCTIONS
    public bool IsAlive { get { return currentHealth > 0; } }




    //CONSTRUCTOR
    public EntityHealthHelper(EntityData data)
    {
        currentHealth = data.MaxHealth;
        maxHealth = data.MaxHealth;
    }


    //FUNCTIONALITIES
    public void DamageHealth(float damageAmount) => currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
    public void RestoreHealth(float damageAmount) => currentHealth = Mathf.Clamp(currentHealth + damageAmount, 0, maxHealth);


    //DEBUG
    public void PrintDebug()
    {
        //DATA DEBUG
        Debug.Log("currentHealth: " + currentHealth);
        Debug.Log("maxHealth: " + maxHealth);

        //FUNCTIONS DEBUG
        Debug.Log("IsAlive: " + IsAlive);
    }
}
