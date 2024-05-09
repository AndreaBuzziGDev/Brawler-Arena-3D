using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO: IS THIS ACTUALLY USEFUL? SIMPLIFY ARCHITECTURE?
public abstract class ManagedEvent : EventArgs
{
    public abstract int EventId { get; }
}
