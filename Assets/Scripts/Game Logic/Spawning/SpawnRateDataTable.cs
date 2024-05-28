using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRateDataTable : ScriptableObject
{
    //DATA
    [SerializeField] List<SpawnWaveData> orderedWaves = new();
    [Range(0.0f, 60.0f)][SerializeField] float lastWaveExtraCooldown = 30.0f;


    //DATA GETTERS
    public List<SpawnWaveData> OrderedWaves { get { return orderedWaves; } }
    public float LastWaveExtraCooldown { get { return lastWaveExtraCooldown; } }

}
