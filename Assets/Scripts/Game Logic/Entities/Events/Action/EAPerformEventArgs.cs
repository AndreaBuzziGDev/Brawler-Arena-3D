using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EAPerformEventArgs : EntityActionEventArgs
{
    //DATA
    //TODO: THIS SHOULD HANDLE ALL THE DIFFERENT BUTTONS AND THE THINGS THEY DO
    //TODO: CHANGE TYPE
    public Vector2 direction { get; }

    //CONSTRUCTORS
    public EAPerformEventArgs(Vector2 direction){
        this.direction = direction;
    }


}
