using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Particle Data", menuName = "Particle/Entity Particles")]
public class EntityParticleData : ScriptableObject {

    //DATA
    [SerializeField] protected ParticleData spawnParticleData;
    [SerializeField] protected ParticleData deathParticleData;
    [SerializeField] protected ParticleData shieldParticleData;
    [SerializeField] protected ParticleData healthParticleData;


    //DATA GETTERS
    public ParticleData SpawnPD => spawnParticleData;
    public ParticleData DeathPD => deathParticleData;
    public ParticleData ShieldPD => shieldParticleData;
    public ParticleData HealthPD => healthParticleData;


}
