using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParticleDataStruct
{
    public GameObject particle;
    
    [Range(0.0f, 20.0f)]
    public float duration = 5.0f;
}
