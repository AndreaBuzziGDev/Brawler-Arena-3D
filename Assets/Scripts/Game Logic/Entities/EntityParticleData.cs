using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Particle Data", menuName = "Particle/Entity Particles")]
public class EntityParticleData : ScriptableObject{
    
    //DATA
    [SerializeField] protected ParticleData spawnParticleData;
    [SerializeField] protected ParticleData deathParticleData;
    [SerializeField] protected ParticleData shieldParticleData;
    [SerializeField] protected ParticleData healthParticleData;
    
    
    //DATA GETTERS
    public ParticleData SpawnParticleData => spawnParticleData;
    public ParticleData DeathParticleData => deathParticleData;
    public ParticleData ShieldParticleData => shieldParticleData;
    public ParticleData HealthParticleData => healthParticleData;
    
    
}
