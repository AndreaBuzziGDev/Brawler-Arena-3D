using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityPickupEventArgs : EventArgs
{
    //DATA
    private PickupEventArgs originalInfo;
    
    //DATA GETTERS
    public PickupEventArgs OriginalInfo { get { return originalInfo; } }

    //CONSTRUCTOR
    public EntityPickupEventArgs(PickupEventArgs originalInfo){
        this.originalInfo = originalInfo;
    }

}
