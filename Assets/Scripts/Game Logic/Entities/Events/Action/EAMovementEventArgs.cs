using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EAMovementEventArgs : EntityActionEventArgs {
    //DATA
    public Vector2 direction { get; }

    //CONSTRUCTORS
    public EAMovementEventArgs(Vector2 direction) {
        this.direction = direction;
    }

}
