using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEntityEventArgs : ManagedEvent
{
    //DATA
    private SpawnPoint.SpawnPointType eventType;
    public SpawnPoint.SpawnPointType EventType { get { return eventType; } }

    private int spawnPointInstanceID;
    public int SpawnPointInstanceID { get { return spawnPointInstanceID; } }


    //CONSTRUCTOR
    public SpawnEntityEventArgs(SpawnPoint.SpawnPointType eventType, int spawnPointInstanceID)
    {
        this.eventType = eventType;
        this.spawnPointInstanceID = spawnPointInstanceID;
    }


    //ABSTRACT CONCRETIZATION
    public override int EventId { get { return (int) eventType; } }
}
