using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEntityEventArgs : EventArgs
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
}
