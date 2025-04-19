using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityPickupEventArgs : EventArgs {
    //DATA
    public PickupEventArgs OriginalInfo { get; }

    //CONSTRUCTOR
    public EntityPickupEventArgs(PickupEventArgs originalInfo) {
        this.OriginalInfo = originalInfo;
    }

}
