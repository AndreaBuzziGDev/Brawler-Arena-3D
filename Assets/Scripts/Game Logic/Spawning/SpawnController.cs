using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour {
    //ENUMS
    public enum SpawnType {
        FLAT,//QUANTITY
        EQUALIZED,//= QUANTITY/SPAWNS
        RANDOMIZED//FROM 1 UP TO QUANTITY
    }



    //DATA
    [Header("Scriptable Objects")]
    [SerializeField] SpawnRateDataTable sDataTable;


    [Header("Wave Data")]
    [Tooltip("Use this to start at a specific wave.")]
    [SerializeField] int waveManualOverride = 0;

    [Tooltip("How many seconds before the first wave starts?")]
    [SerializeField] float gameStartDelay = 5.0f;

    [Tooltip("Use this to disable spawning of mobs via this controller.")]
    [SerializeField] bool disabledSpawn = false;



    //INNER DATA
    List<SpawnPoint> spawnPoints = new();
    Dictionary<int, SpawnPoint> spDictionary = new();
    float waveCooldownTimer = 0.0f;
    int waveIndex = 0;



    //LIFECYCLE FUNCTIONS
    void Start() {
        //ERROR CHECK
        if (sDataTable == null || sDataTable.OrderedWaves.Count == 0)
            Debug.LogError("SpawnController - No Waves have been set. Please configure and assign SpawnRateDataTable");

        //SPAWN POINT INITIALIZATION
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
        foreach (SpawnPoint sp in spawnPoints)
            spDictionary.Add(sp.gameObject.GetInstanceID(), sp);

        //GAMEPLAY LOOP INITIALIZATION
        waveCooldownTimer = gameStartDelay;
        waveIndex = Mathf.Clamp(waveManualOverride, 0, sDataTable.OrderedWaves.Count);
        Debug.Log("SpawnController - waveIndex: " + waveIndex);
    }

    void Update() {
        //...
        if (GameController.Instance.IsPlaying && !disabledSpawn)
            HandleTimer();

    }



    //FUNCTIONALITIES
    private void HandleTimer() {
        if (waveCooldownTimer > 0)
            waveCooldownTimer -= Time.deltaTime;
        else
            HandleWave();
    }

    private void HandleWave() {
        //SPAWN ENTITIES
        foreach (int sId in spDictionary.Keys)
            NotifySpawner(sId);

        //SET COOLDOWN TIMER
        waveCooldownTimer = sDataTable.OrderedWaves[waveIndex].NextWaveCooldown;

        //MANAGE WAVE INDEX
        if (waveIndex < sDataTable.OrderedWaves.Count)
            waveIndex++;
        else {
            //EXTRA COOLDOWN AT THE END
            waveCooldownTimer += sDataTable.LastWaveExtraCooldown;
            waveIndex = 0;
        }

    }


    private void NotifySpawner(int spawnerToNotifyId) {
        //int spawnPointInstanceID, List<SpawnRateData> rateData
        List<SpawnRateData> spawns = sDataTable.OrderedWaves[waveIndex].Spawns;
        foreach (SpawnRateData sRateData in spawns) {
            EventManager<SpawnEntityEventArgs>.Instance.Notify(
                this,
                new(
                    spawnerToNotifyId,
                    new SpawnData(
                        sRateData.TargetEntityPrefab,
                        CalculateSpawnedQuantity(sRateData)
                    )
                )
            );
        }
    }


    //UTILITIES
    private int CalculateSpawnedQuantity(SpawnRateData sRateData) {
        int variance = UnityEngine.Random.Range(-sRateData.Variance, sRateData.Variance);
        switch (sRateData.SpawnType) {
            case SpawnType.EQUALIZED:
                return (int)((sRateData.Quantity + variance) / spawnPoints.Count);
            case SpawnType.RANDOMIZED:
                int calculatedRate = sRateData.Quantity + variance;
                return Mathf.Clamp(calculatedRate, 0, sRateData.Quantity + sRateData.Variance);
            case SpawnType.FLAT:
            default:
                return (sRateData.Quantity + variance);
        }
    }

}
