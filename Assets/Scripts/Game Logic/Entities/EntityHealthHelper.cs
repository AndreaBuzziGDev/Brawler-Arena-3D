using System.Text;
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
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;



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
        NotifyValueChange();
        Debugger.Log(DebugProperties, LogType.ENTITY_PARAMS);
    }
    
    
    //NOTIFICATION
    private void NotifyValueChange(){
        switch(entityType){
            case EntityData.EEntityType.PLAYER:
                EventManager<PlayerDamageEventArgs>.Instance.Notify(this, new PlayerDamageEventArgs(EntityDamageEventArgs.EDamageType.HEALTH, maxHealth, currentHealth));
                break;
            case EntityData.EEntityType.NPC:
            default:
                //EventManager<EntityDamageEventArgs>.Instance.Notify(this, new(EntityDamageEventArgs.EDamageType.HEALTH, maxHealth, currentHealth));
                break;
            
        }
    }


    //DEBUG
    public void DebugProperties(){

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("");
        sb.AppendLine("==== HEALTH HELPER START INFO ===="); //TODO: MASTER ENTITY NAME (ADD IN ENTITY DATA)

        // DATA DEBUG
        sb.AppendLine($"Entity Health Helper - entityType: {entityType}");
        sb.AppendLine($"Entity Health Helper - currentHealth: {currentHealth}");
        sb.AppendLine($"Entity Health Helper - maxHealth: {maxHealth}");

        // FUNCTIONS DEBUG
        sb.AppendLine($"IsAlive: {IsAlive}");

        sb.AppendLine("==== HEALTH HELPER END INFO ====");

        Debug.Log(sb.ToString());
    }

}
