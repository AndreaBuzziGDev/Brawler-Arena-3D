using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgentController : MonoBehaviour
{
    //DATA
    private Transform target;
    private NavMeshAgent myNavAgent;


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        myNavAgent = GetComponent<NavMeshAgent>();
        target = GameController.Instance.GetPlayerAnywhere.transform;
    }

    void Update()
    {
        if(GameController.Instance.IsPlaying)
            myNavAgent.destination = target.position;
        else if(target != null)
            myNavAgent.destination = transform.position;
    }
}
