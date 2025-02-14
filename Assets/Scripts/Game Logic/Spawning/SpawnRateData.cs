using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Rate", menuName = "Spawn Rate")]
public class SpawnRateData : ScriptableObject
{
    //DATA
    [Header("Spawn Rate Parameters")]
    [Tooltip("Which mob to spawn")]
    [SerializeField] EntityWithHealth targetEntityPrefab;

    [Tooltip("How many instances of this mob to create")]
    [Range(1, 100)][SerializeField] int quantity = 10;

    [Tooltip("A variance on top of the given quantity")]
    [Range(0, 100)][SerializeField] int variance = 5;

    [Tooltip("Which type of spawn point to use")]
    [SerializeField] SpawnController.SpawnType spawnType;


    //DATA GETTERS
    public EntityWithHealth TargetEntityPrefab => targetEntityPrefab;
    public int Quantity => quantity;
    public int Variance => variance;
    public SpawnController.SpawnType SpawnType => spawnType;

}
