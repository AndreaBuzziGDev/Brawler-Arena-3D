using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthHelper
{
    //DATA
    float currentHealth = 1;
    float maxHealth = 1;
    EntityData.EEntityType entityType;

    //DATA GETTERS
    public float CurrentHealth { get { return currentHealth; } }
    public float MaxHealth { get { return maxHealth; } }



    //DATA FUNCTIONS
    public bool IsAlive { get { return currentHealth > 0; } }




    //CONSTRUCTOR
    public EntityHealthHelper(EntityData data)
    {
        this.entityType = data.EntityType;
        this.currentHealth = data.MaxHealth;
        this.maxHealth = data.MaxHealth;
    }


    //FUNCTIONALITIES
    public void ChangeHealth(float changeAmount){
        currentHealth = Mathf.Clamp(currentHealth + changeAmount, 0, maxHealth);
        
        switch(entityType){
            case EntityData.EEntityType.PLAYER:
                EventManager<PlayerDamageEventArgs>.Instance.Notify(this, new(EntityDamageEventArgs.EDamageType.HEALTH, maxHealth, currentHealth));
                break;
            case EntityData.EEntityType.NPC:
            default:
                //EventManager<EntityDamageEventArgs>.Instance.Notify(this, new(EntityDamageEventArgs.EDamageType.HEALTH, maxHealth, currentHealth));
                break;
            
        }
    }


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
