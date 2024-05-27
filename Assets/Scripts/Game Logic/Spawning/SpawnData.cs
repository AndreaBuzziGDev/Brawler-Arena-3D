using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData
{
    //DATA
    //TODO: SOME CLASS (NOT NECESSARILY THIS ONE) MIGHT MAKE GOOD USE OF A SCRIPTABLEOBJECT TO CARRY PREFABS & OTHER THINGS
    public EntityWithHealth TargetPrefab { get; }
    public int Quantity { get; }


    //CONSTRUCTOR
    public SpawnData(EntityWithHealth targetPrefab, int quantity)
    {
        this.TargetPrefab = targetPrefab;
        this.Quantity = quantity;
    }


    //FUNCTIONALITIES
    //...
}
