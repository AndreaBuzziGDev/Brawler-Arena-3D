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



    //TODO: DELETE UPDATE
    void Update()
    {
        Debug.Log("Random Vec3: " + GetRandomSpawnVector());
    }

    //FUNCTIONALITIES
    //...
    public void SpawnEntity(EntityWithHealth toSpawn)
    {
        Vector3 spawnDistance = GetRandomSpawnVector();
        //TODO: FINISH IMPLEMENTING
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
