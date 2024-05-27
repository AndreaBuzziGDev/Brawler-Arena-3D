using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData
{
    //DATA
    //TODO: USE A SCRIPTABLEOBJECT TO CARRY PREFABS & OTHER THINGS
    public GameObject TargetPrefab { get; }
    public int Quantity { get; }


    //CONSTRUCTOR
    public SpawnData(GameObject targetPrefab, int quantity)
    {
        this.TargetPrefab = targetPrefab;
        this.Quantity = quantity;
    }


    //FUNCTIONALITIES
    //...
}
