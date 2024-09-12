using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Particles/Mob Particles")]
public class EntityParticleData : ScriptableObject
{
    //DATA - PARTICLE EFFECTS
    //TODO: THIS CAN BE IMPROVED BY DEVELOPING ANOTHER SCRIPTABLE OBJECT FOR DEDICATED USE CASE
    [SerializeField] GameObject deathParticleFX;

    //DATA GETTERS
    public GameObject DeathParticleFX { get { return deathParticleFX; } }
    
    //METHODS
    private void OnValidate()
    {
        //TODO: IN CASE OF MULTIPLE PARTICLE FX, USE A FOR CYCLE
        if(deathParticleFX != null && deathParticleFX.GetComponent<ParticleSystem>() == null)
        {
            Debug.LogError($"{deathParticleFX.name} must contain ParticleSystem!");
        }
    }
    
}
