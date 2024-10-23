using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityActionEventArgs : EventArgs
{
    //DATA
    //TODO: PERFORMANCE AND USABILITY MIGHT IMPROVE IF THIS HANDLES DEDICATED DATA TYPES FOR ACTION GROUPS (LIKE VECTORS FOR MOVEMENT/AIMING...)
    //      ON A SECOND NOTICE, THIS MIGHT BENEFIT FROM ABSTRACTION + INHERITANCE INTO MULTIPLE SUB-CLASSES
    private object carriedInfo;

    //DATA GETTERS
    public object CarriedInfo { get { return carriedInfo; } }

    //CONSTRUCTOR
    public EntityActionEventArgs(object carriedInfo){
        this.carriedInfo = carriedInfo;
    }
}
