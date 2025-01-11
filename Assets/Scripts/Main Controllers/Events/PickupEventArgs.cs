using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupEventArgs : EventArgs
{
    //DATA
    public PickupController.EPickupTypes EventType { get;}
    public int PickerId { get; }


    //CONSTRUCTOR
    public PickupEventArgs(PickupController.EPickupTypes eventType, int pickerId)
    {
        this.EventType = eventType;
        this.PickerId = pickerId;
    }
}
