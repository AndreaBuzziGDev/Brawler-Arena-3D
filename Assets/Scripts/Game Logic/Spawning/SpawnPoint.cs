using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //DATA
    [SerializeField] Color gizmoColor = Color.green;
    [SerializeField] float spawnRadius = 1.0f;
    [SerializeField] bool spawnStrictlyOnRadius = false;



    //FUNCTIONALITIES
    //TODO: DEVELOP FUNCTIONALITY TO CARRY AND HANDLE SPAWN EVENT
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


    //GIZMOS
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
