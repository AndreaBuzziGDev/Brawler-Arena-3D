using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay Data/Weapon Data/Melee")]
public class WeaponMeleeData : WeaponData {
    //AUDIO
    [Tooltip("Reference to WeaponAudioData Scriptable Object.")]
    [SerializeField] protected WeaponAudioData weaponAudioData;


    //TODO: IMPLEMENT THE REST

    //...

    //ABSTRACT DATA GETTER CONCRETIZATION
    public override WeaponAudioData WAudioData { get { return weaponAudioData; } } //{ get { return weaponAudioData; } }
}
