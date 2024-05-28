using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Rate", menuName = "Spawn Rate")]
public class SpawnRateData : ScriptableObject
{
    //DATA
    [SerializeField] EntityWithHealth targetEntityPrefab;
    [Range(1, 100)][SerializeField] int quantity = 10;
    [Range(1, 100)][SerializeField] int variance = 5;


    //DATA GETTERS
    public EntityWithHealth TargetEntityPrefab { get { return targetEntityPrefab; } }
    public int Quantity { get { return quantity; } }
    public int Variance { get { return variance; } }
    
}