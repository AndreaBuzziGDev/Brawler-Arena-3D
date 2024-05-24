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
        //TODO: EVALUATE AN EVOLUTION OF THIS SO THAT THE CONTROLLER IS NOTIFIED OF THE TARGET IN ANOTHER WAY
        target = GameController.Instance.GetPlayerAnywhere.transform;
    }

    void Update()
    {
        //TODO: ALTERNATIVELY USE "IsStopped" ON myNavAgent
        if(GameController.Instance.IsPaused)
            myNavAgent.destination = transform.position;
        else if(target != null)
            myNavAgent.destination = target.position;
    }
}
