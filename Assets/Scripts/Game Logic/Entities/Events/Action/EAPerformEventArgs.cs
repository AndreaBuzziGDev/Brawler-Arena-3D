using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EAPerformEventArgs : EntityActionEventArgs
{
    //DATA
    public Vector2 direction { get; }

    //CONSTRUCTORS
    public EAPerformEventArgs(Vector2 direction){
        this.direction = direction;
    }


}
