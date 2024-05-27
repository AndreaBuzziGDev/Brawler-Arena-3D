using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEntityEventArgs : ManagedEvent
{
    //DATA
    public int SpawnPointInstanceID { get; }

    public SpawnData Data { get; }



    //CONSTRUCTOR
    public SpawnEntityEventArgs(int spawnPointInstanceID, SpawnData data)
    {
        this.SpawnPointInstanceID = spawnPointInstanceID;
        this.Data = data;
    }


    //ABSTRACT CONCRETIZATION
    public override int EventId { get { return (int) SpawnPointInstanceID; } }
}
