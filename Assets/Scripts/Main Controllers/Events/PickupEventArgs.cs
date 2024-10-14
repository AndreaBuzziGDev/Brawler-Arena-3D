using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupEventArgs : EventArgs
{
    //DATA
    private PickupController.EPickupTypes eventType;
    public PickupController.EPickupTypes EventType { get { return eventType; } }


    //CONSTRUCTOR
    public PickupEventArgs(PickupController.EPickupTypes eventType)
    {
        this.eventType = eventType;
    }
}
