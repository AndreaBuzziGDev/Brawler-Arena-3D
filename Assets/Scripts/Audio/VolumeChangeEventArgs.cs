using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VolumeChangeEventArgs : ManagedEvent
{
    //CONSTRUCTOR
    public VolumeChangeEventArgs(){}

    //ABSTRACT CONCRETIZATION
    public override int EventId{ get { return 0; } }
}
