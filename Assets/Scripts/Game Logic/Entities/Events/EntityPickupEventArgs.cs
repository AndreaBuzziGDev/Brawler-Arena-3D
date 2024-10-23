using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityPickupEventArgs : EventArgs
{
    //DATA
    private object carriedInfo;
    
    //DATA GETTERS
    public object CarriedInfo { get { return carriedInfo; } }

    //CONSTRUCTOR
    public EntityPickupEventArgs(object carriedInfo){
        this.carriedInfo = carriedInfo;
    }

}
