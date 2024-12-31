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
    private EDamageType damageType;
    
    //DATA GETTERS
    public EDamageType DamageType { get { return damageType; } }

    //CONSTRUCTOR
    public EntityDamageEventArgs(EDamageType damageType){
        this.damageType = damageType;
    }
}
