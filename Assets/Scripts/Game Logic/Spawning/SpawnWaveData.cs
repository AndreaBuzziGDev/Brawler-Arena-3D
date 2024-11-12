using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Wave Data", menuName = "Spawn Wave")]
public class SpawnWaveData : ScriptableObject
{
    //DATA
    [Header("Spawn Wave Parameters")]
    [SerializeField] string waveName = "Wave #_";//TODO: IS IT POSSIBLE/DOES IT MAKE SENSE TO AUTO-NAME THESE?

    [Tooltip("A List of Scriptable objects that defines spawn rates for each mob.")]
    [SerializeField] List<SpawnRateData> spawns = new();

    [Range(10.0f, 180.0f)][SerializeField] float nextWaveCooldown = 30.0f;


    //DATA GETTERS
    public string WaveName { get { return waveName; } }
    public List<SpawnRateData> Spawns { get { return spawns; } }
    public float NextWaveCooldown { get { return nextWaveCooldown; } }

}