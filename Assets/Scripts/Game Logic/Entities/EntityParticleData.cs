using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Audio Data", menuName = "Entity Data/Entity Particles/Mob Particles")]
public class EntityParticleData : ScriptableObject
{
    //DATA - PARTICLE EFFECTS
    [SerializeField] ParticleSystem deathParticleFX;

    //DATA GETTERS
    public ParticleSystem DeathParticleFX { get { return deathParticleFX; } }
    
}
