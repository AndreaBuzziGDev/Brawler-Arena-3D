using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Particles/Mob Particles")]
public class EntityParticleData : ScriptableObject
{
    //DATA - PARTICLE EFFECTS
    [SerializeField] ParticleDataStruct structDeathParticleFX;

    //DATA GETTERS
    public ParticleDataStruct DeathParticleFX { get { return structDeathParticleFX; } }
    
    
    //METHODS
    private void OnValidate()
    {
        //TODO: IN CASE OF MULTIPLE PARTICLE FX, USE A FOR CYCLE
        if(structDeathParticleFX?.particle != null && structDeathParticleFX.particle.GetComponent<ParticleSystem>() == null)
        {
            Debug.LogError($"{structDeathParticleFX.particle.name} must contain ParticleSystem!");
        }
        //TODO: DURATION MUST BE A POSITIVE VALUE
    }
    
}
