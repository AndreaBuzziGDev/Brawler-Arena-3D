using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleEffectEventArgs : EventArgs
{
    //DATA
    //TODO: ADOPT THIS SIMPLIFIED SINTAX IN OTHER EVENTS
    public GameObject ToSpawn { get; }
    public Vector3 Position { get; }
    public string Name { get; }
    public float Duration { get; }


    //CONSTRUCTOR
    public ParticleEffectEventArgs(ParticleDataStruct particleDataStruct, Vector3 position)
    {
        this.ToSpawn = particleDataStruct?.particle;
        this.Position = position;
        this.Name = particleDataStruct?.particle?.name ?? "Null Particle FX";
        this.Duration = particleDataStruct?.duration ?? 1.0f;
    }
}