using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleManager : MonoSingleton<ParticleManager>
{
    //DATA


    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //REGISTER EVENTS
        EventManager<ParticleEffectEventArgs>.Instance.StartListening(SpawnParticlesAutoDestroy);
    }

    void OnDestroy()
    {
        //UN-REGISTER EVENTS
        EventManager<ParticleEffectEventArgs>.Instance.StopListening(SpawnParticlesAutoDestroy);
    }



    //FUNCTIONALITIES
    private void SpawnParticlesAutoDestroy(object sender, ParticleEffectEventArgs e)
    {
        //TODO: THIS CAN BE SIGNIFICANTLY IMPROVED BY USING AN OBJECT POOLER
        ParticleSystem go = Instantiate(e.ToSpawn);
        go.transform.position = e.Position;
        go.name = e.Name;

        Destroy(go.gameObject, e.Duration);
    }

}
