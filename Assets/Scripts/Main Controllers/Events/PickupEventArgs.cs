using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupEventArgs : EventArgs
{
    //DATA
    private PickupController.EPickupTypes eventType;
    public PickupController.EPickupTypes EventType { get { return eventType; } }
    
    private int pickerId;
    public int PickerId { get { return pickerId; }}


    //CONSTRUCTOR
    public PickupEventArgs(PickupController.EPickupTypes eventType, int pickerId)
    {
        this.eventType = eventType;
        this.pickerId = pickerId;
    }
}
