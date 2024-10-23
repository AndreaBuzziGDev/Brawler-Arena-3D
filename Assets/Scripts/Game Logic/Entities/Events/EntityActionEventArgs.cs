using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityActionEventArgs : EventArgs
{
    //DATA
    private object carriedInfo;

    //DATA GETTERS
    public object CarriedInfo { get { return carriedInfo; } }

    //CONSTRUCTOR
    public EntityActionEventArgs(object carriedInfo){
        this.carriedInfo = carriedInfo;
    }
}
