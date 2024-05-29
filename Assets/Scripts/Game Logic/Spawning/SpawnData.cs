using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData
{
    //DATA
    public EntityWithHealth TargetPrefab { get; }
    public int Quantity { get; }


    //CONSTRUCTOR
    public SpawnData(EntityWithHealth targetPrefab, int quantity)
    {
        this.TargetPrefab = targetPrefab;
        this.Quantity = quantity;
    }
}
