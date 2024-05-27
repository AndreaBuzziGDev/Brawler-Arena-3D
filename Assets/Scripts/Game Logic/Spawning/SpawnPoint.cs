using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //ENUMS
    public enum SpawnPointType
    {
        GROUND,
        COPTER
    }


    //DATA
    [SerializeField] SpawnPointType type = SpawnPointType.GROUND;
    [SerializeField] Color gizmoColor = Color.green;
    [SerializeField] float spawnRadius = 1.0f;
    [SerializeField] bool spawnStrictlyOnRadius = false;

    //TODO: REMOVE SerializeField?
    [SerializeField] int spawnerId;



    //LIFECYCLE FUNCTIONS
    void Start()
    {
        spawnerId = gameObject.GetInstanceID();
        EventManager<SpawnEntityEventArgs>.Instance.StartListening(HandleSpawnEntityEvent);
    }


    //FUNCTIONALITIES
    public void SpawnEntity(EntityWithHealth toSpawn)
    {
        Vector3 spawnDistance = GetRandomSpawnVector();
        Instantiate(toSpawn, transform.position + spawnDistance, Quaternion.identity);
    }


    //
    public Vector3 GetRandomSpawnVector()
    {
        Vector3 spawnVector = UtilsRadius.RandomPositionOnCircleRadius(spawnRadius);
        if(spawnStrictlyOnRadius)
            return spawnVector;
        else 
            return Vector3.Lerp(Vector3.zero, spawnVector, UnityEngine.Random.Range(0.0f, 1.0f));
    }


    //EVENT HANDLING
    private void HandleSpawnEntityEvent(object sender, SpawnEntityEventArgs e)
    {
        if(spawnerId.Equals(e.SpawnPointInstanceID))
        {
            for(int i=0; i < e.Data.Quantity; i++)
                SpawnEntity(e.Data.TargetPrefab);
        }
    }


    //GIZMOS
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
