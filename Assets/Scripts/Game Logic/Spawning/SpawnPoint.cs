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
    //...


    //GIZMOS
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
