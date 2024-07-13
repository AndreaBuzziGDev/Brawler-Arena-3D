using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Wave Data", menuName = "Spawn Wave")]
public class SpawnWaveData : ScriptableObject
{
    //DATA
    [SerializeField] string waveName = "Wave #_";
    [SerializeField] List<SpawnRateData> spawns = new();
    [Range(10.0f, 180.0f)][SerializeField] float nextWaveCooldown = 30.0f;


    //DATA GETTERS
    public string WaveName { get { return waveName; } }
    public List<SpawnRateData> Spawns { get { return spawns; } }
    public float NextWaveCooldown { get { return nextWaveCooldown; } }

}