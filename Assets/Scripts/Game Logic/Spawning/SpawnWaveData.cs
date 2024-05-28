using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Wave Data", menuName = "Spawn Wave")]
public class SpawnWaveData : ScriptableObject
{
    //DATA
    //TODO: EVALUATE ADDITIONAL DATA LIKE A NAME FOR A WAVE OR SOMETHING LIKE THAT
    [SerializeField] List<SpawnRateData> spawns = new();
    [Range(10.0f, 180.0f)][SerializeField] float nextWaveCooldown = 30.0f;


    //DATA GETTERS
    public List<SpawnRateData> Spawns { get { return spawns; } }
    public float NextWaveCooldown { get { return nextWaveCooldown; } }

}