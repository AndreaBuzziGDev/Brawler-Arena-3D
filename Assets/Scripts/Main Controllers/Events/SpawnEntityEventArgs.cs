using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEntityEventArgs : ManagedEvent
{
    //DATA
    private int spawnPointInstanceID;
    public int SpawnPointInstanceID { get { return spawnPointInstanceID; } }


    //CONSTRUCTOR
    public SpawnEntityEventArgs(int spawnPointInstanceID, )
    {
        this.spawnPointInstanceID = spawnPointInstanceID;
    }


    //ABSTRACT CONCRETIZATION
    public override int EventId { get { return (int) spawnPointInstanceID; } }
}
