using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleEffectEventArgs : EventArgs
{
    //DATA
    public ParticleSystem ToSpawn { get; }
    public Vector3 Position { get; }
    public string Name { get; }
    public float Duration { get; }


    //CONSTRUCTOR
    public ParticleEffectEventArgs(ParticleSystem toSpawn, Vector3 position, string name = "Orchestrated Particle", float duration = 5)
    {
        this.ToSpawn = toSpawn;
        this.Position = position;
        this.Name = name;
        this.Duration = duration;
    }
}