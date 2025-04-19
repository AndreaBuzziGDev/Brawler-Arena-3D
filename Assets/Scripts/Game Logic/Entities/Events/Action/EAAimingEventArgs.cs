using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EAAimingEventArgs : EntityActionEventArgs {
    //DATA
    public Vector2 direction { get; }

    //CONSTRUCTORS
    public EAAimingEventArgs(Vector2 direction) {
        this.direction = direction;
    }
}
