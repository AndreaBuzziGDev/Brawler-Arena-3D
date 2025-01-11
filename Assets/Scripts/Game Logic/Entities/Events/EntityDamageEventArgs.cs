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
    public EDamageType DamageType { get; }
    public float MaxFill { get; }
    public float CurrentFill { get; }
    public float PercentFill { get { return (float) (CurrentFill / MaxFill); } }



    //CONSTRUCTOR
    public EntityDamageEventArgs(EDamageType damageType, float maxFill, float currentFill){
        this.DamageType = damageType;
        this.MaxFill = maxFill;
        this.CurrentFill = currentFill;
    }
}
