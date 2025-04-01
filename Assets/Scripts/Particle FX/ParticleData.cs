using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "New Particle Data", menuName = "Particle/Particle Data")]
public class ParticleData : ScriptableObject
{
    [Header("Particle Effect Data")]
    [SerializeField] ParticleDataStruct structParticleFX;

    //DATA GETTERS
    public ParticleDataStruct ParticleFX => structParticleFX;
    
    
    //METHODS
    private void OnValidate()
    {
        foreach (ParticleDataStruct pdsField in GetAllParticleDataStructs())
        {
            //
            if(pdsField?.particle != null && pdsField.particle.GetComponent<ParticleSystem>() == null)
                Debug.LogError($"{pdsField.particle.name} must contain ParticleSystem!");
            //
            if(pdsField?.duration != null && pdsField.duration < 0)
                Debug.LogError($"{pdsField.particle.name} must have a positive duration!");
        }
    }


    //UTILITIES
    private List<ParticleDataStruct> GetAllParticleDataStructs()
    {
        List<ParticleDataStruct> pdsFields = new();
        Type type = this.GetType();
        foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            if (field.FieldType == typeof(ParticleDataStruct))
                pdsFields.Add((ParticleDataStruct) field.GetValue(this));
        }
        return pdsFields;
    }
    
}
