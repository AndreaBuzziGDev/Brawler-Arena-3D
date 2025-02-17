using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleEffectEventArgs : EventArgs
{
    //DATA
    //USE THIS SIMPLIFIED SINTAX IN OTHER EVENTS
    public GameObject ToSpawn { get; }
    public Vector3 Position { get; }
    public string Name { get; }
    public float Duration { get; }


    //CONSTRUCTOR
    public ParticleEffectEventArgs(ParticleData particleData, Vector3 position)
    {
        this.ToSpawn = particleData?.ParticleFX?.particle;
        this.Position = position;
        this.Name = particleData?.ParticleFX?.particle?.name ?? "Null Particle FX";
        this.Duration = particleData?.ParticleFX?.duration ?? 1.0f;
    }
}