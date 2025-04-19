using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Self-Destruct")]
public class WeaponSBombData : WeaponData {
    //RADIUS
    [Tooltip("The radius of the explosion in game units")]
    [Range(0, 50)]
    [SerializeField] float effectiveRadius = 10;

    //AUDIO
    [Tooltip("Reference to WeaponAudioData Scriptable Object.")]
    [SerializeField] protected WeaponAudioData weaponAudioData;




    //DATA GETTER
    public float EffectiveRadius => effectiveRadius;


    //ABSTRACT DATA GETTER CONCRETIZATION
    public override WeaponAudioData WAudioData { get { return weaponAudioData; } }
}
