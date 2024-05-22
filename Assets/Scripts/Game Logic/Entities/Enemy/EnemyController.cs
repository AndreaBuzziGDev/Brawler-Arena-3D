using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : EntityWithHealth
{
    private Transform target;
    private NavMeshAgent myNavAgent;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        myNavAgent = GetComponent<NavMeshAgent>();
        target = GameController.Instance.GetPlayerAnywhere.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        //TODO: ALT SOLUTION FOR THIS?
        if(GameController.Instance.IsPaused)
            myNavAgent.destination = transform.position;
        else
            myNavAgent.destination = target.position;
    }


    //FUNCTIONALITIES
    public override void HandleDeath()
    {
        //TODO: DEVELOP
        Debug.Log("EnemyController - Handle Death - TODO DEVELOP");
    }
}
