using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEntityEventArgs : ManagedEvent
{
    //DATA
    public int SpawnPointInstanceID { get; }
    public List<SpawnData> Data { get; }


    //CONSTRUCTOR
    public SpawnEntityEventArgs(int spawnPointInstanceID, List<SpawnRateData> rateData)
    {
        this.SpawnPointInstanceID = spawnPointInstanceID;
        this.Data = SpawnData.GetDataFromRate(rateData);
    }


    //ABSTRACT CONCRETIZATION
    public override int EventId { get { return (int) SpawnPointInstanceID; } }
}
