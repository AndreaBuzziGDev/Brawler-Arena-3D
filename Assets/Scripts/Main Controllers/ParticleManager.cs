using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleManager : MonoSingleton<ParticleManager>
{
    //DATA




    //PREFABS
    /*
    TODO: THIS SCRIPT NEEDS TO BE REWORKED.

    THIS PROBABLY SHOULD USE OBJECT POOLS AND/OR A SYSTEM TO MATCH A PARTICLE EFFECT TO AN EMISSION EVENT BEING CAPTURED.

    */



    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //REGISTER EVENTS

    }

    void OnDestroy()
    {
        //UN-REGISTER EVENTS
        
    }



    //FUNCTIONALITIES
    private void SpawnParticlesAutoDestroy(ParticleSystem toSpawn, Vector3 position, string name = "Orchestrated Particle", float duration = 5)
    {
        ParticleSystem go = Instantiate(toSpawn);
        go.transform.position = position;

        Destroy(go.gameObject, duration);
    }



    //EVENT HANDLING
    /*
    //NB: THIS COULD BE A GREAT USE-CASE FOR OBJECT POOLING
    public void HandleSolutionParticles(object sender, TearEventArgs e)
    {
        ParticleSystem toSpawn;
        switch(e.AffectedTear.TearType)
        {
            case TearOperation.ETearType.GOLD:
                //
                toSpawn = tearSolutionGold;
                break;
            default:
                //
                toSpawn = tearSolutionNormal;
                break;
        }

        //SPAWN PARTICLES
        SpawnParticlesAutoDestroy(toSpawn, e.AffectedTear.gameObject.transform.position, "Tear Solution Particles");
    }
    */
}
