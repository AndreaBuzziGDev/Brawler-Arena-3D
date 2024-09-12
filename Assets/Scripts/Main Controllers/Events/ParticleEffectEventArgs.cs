using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleEffectEventArgs : EventArgs
{
    //DATA
    public GameObject ToSpawn { get; }
    public Vector3 Position { get; }
    public string Name { get; }
    public float Duration { get; }


    //CONSTRUCTOR
    public ParticleEffectEventArgs(ParticleDataStruct particleStruct, Vector3 position)
    {
        this.ToSpawn = particleStruct.particle;
        this.Position = position;
        this.Name = particleStruct.particle.name;
        this.Duration = particleStruct.duration;
    }
}