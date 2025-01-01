using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityDamageEventArgs : EventArgs
{
    //ENUMS
    public enum EDamageType {
        HEALTH,
        SHIELD
    }
    
    //DATA
    protected EDamageType damageType;
    protected float maxFill;
    protected float currentFill;


    //DATA GETTERS
    public EDamageType DamageType { get { return damageType; } }
    public float MaxFill { get { return maxFill; } }
    public float CurrentFill { get { return currentFill; } }
    public float PercentFill { get { return (float) (currentFill / maxFill); } }



    //CONSTRUCTOR
    public EntityDamageEventArgs(EDamageType damageType, float maxFill, float currentFill){
        this.damageType = damageType;
        this.maxFill = maxFill;
        this.currentFill = currentFill;
    }
}
