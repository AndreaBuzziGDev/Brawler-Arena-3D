using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour
{
    //DATA
    List<SpawnPoint> spawnPoints = new();
    Dictionary<int, SpawnPoint> spDictionary = new();

    //TODO: THIS IS A VERY BASIC IMPLEMENTATION OF WAVE SYSTEM, EVOLUTION EXPECTED
    [SerializeField] float waveCooldownTimerMax = 10.0f;
    float waveCooldownTimer = 0.0f;
    
    //TODO: EMBELLISH
    [SerializeField] int maxSpawnedForWave = 10;

    //PREFAB REFERENCES
    //TODO: INTRODUCE SUPPORT FOR MORE ENTITIES
    [SerializeField] EntityWithHealth entityPrefab;


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
        foreach(SpawnPoint sp in spawnPoints)
            spDictionary.Add(sp.gameObject.GetInstanceID(), sp);

        //INSTANTLY SPAWN
        waveCooldownTimer = waveCooldownTimerMax;
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
        if(waveCooldownTimer < waveCooldownTimerMax)
            waveCooldownTimer += Time.deltaTime;
        else
        {
            foreach(int sId in spDictionary.Keys)
                NotifySpawner(sId);
            
            waveCooldownTimer = 0.0f;
        }
    }

    private void NotifySpawner(int spawnerToNotifyId)
    {
        SpawnData sData = new(entityPrefab, UnityEngine.Random.Range(0, maxSpawnedForWave+1));
        EventManager<SpawnEntityEventArgs>.Instance.Notify(this, new(spawnerToNotifyId, sData));
    }



}
