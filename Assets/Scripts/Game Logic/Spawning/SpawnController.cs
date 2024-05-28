using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour
{
    //DATA
    List<SpawnPoint> spawnPoints = new();
    Dictionary<int, SpawnPoint> spDictionary = new();


    //WAVE DATA
    [SerializeField] int waveManualOverride = 0;
    int waveIndex = 0;

    [SerializeField] float gameStartDelay = 5.0f;
    float waveCooldownTimer = 0.0f;


    //PREFAB REFERENCES
    [SerializeField] SpawnRateDataTable sDataTable;



    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //ERROR CHECK
        if(sDataTable == null || sDataTable.OrderedWaves.Count == 0)
            Debug.LogError("SpawnController - No Waves have been set. Please configure and assign SpawnRateDataTable");

        //SPAWN POINT INITIALIZATION
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
        foreach(SpawnPoint sp in spawnPoints)
            spDictionary.Add(sp.gameObject.GetInstanceID(), sp);

        //GAMEPLAY LOOP INITIALIZATION
        waveCooldownTimer = gameStartDelay;
        waveIndex = Mathf.Clamp(waveManualOverride, 0, sDataTable.OrderedWaves.Count);
        Debug.Log("SpawnController - waveIndex: " + waveIndex);
    }

    void Update()
    {
        //...
        if(GameController.Instance.IsPlaying)
            HandleTimer();

    }

    //FUNCTIONALITIES
    private void HandleTimer()
    {
        if(waveCooldownTimer > 0)
            waveCooldownTimer -= Time.deltaTime;
        else
            HandleWave();
    }

    private void HandleWave()
    {
        //SPAWN ENTITIES
        foreach(int sId in spDictionary.Keys)
            NotifySpawner(sId);

        //SET COOLDOWN TIMER
        waveCooldownTimer = sDataTable.OrderedWaves[waveIndex].NextWaveCooldown;

        //MANAGE WAVE INDEX
        if(waveIndex < sDataTable.OrderedWaves.Count)
            waveIndex++;
        else
        {
            //EXTRA COOLDOWN AT THE END
            waveCooldownTimer += sDataTable.LastWaveExtraCooldown;
            waveIndex = 0;
        }

    }


    private void NotifySpawner(int spawnerToNotifyId)
    {
        //TODO: NEEDS RANDOMIZATION - RIGHT NOW EVERY SPAWNER SPAWNS THE CONTENT OF THE WAVES
        //TODO: NEEDS TO ENABLE SPAWN TYPE DIVERSIFICATION
        
        //int spawnPointInstanceID, List<SpawnRateData> rateData
        EventManager<SpawnEntityEventArgs>.Instance.Notify(
            this, 
            new(spawnerToNotifyId, sDataTable.OrderedWaves[waveIndex].Spawns)
        );
    }

}
