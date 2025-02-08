using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;

[CustomEditor(typeof(WeaponRangedData))]
public class WeaponRangedDataEditor : Editor
{
    //VISIBLE FIELDS LIST
    //TODO: ALWAYS VISIBLE FIELDS
    
    //TODO: ADJUST FIELDS
    private List<string> bowFields = new List<string> { "damage", "range" };
    private List<string> crossbowFields = new List<string> { "damage", "range", "reloadTime" };
    private List<string> firearmFields = new List<string> { "damage", "reloadTime" };


    public override void OnInspectorGUI()
    {
        WeaponRangedData weapon = (WeaponRangedData)target;

        //BASE FIELDS
        //TODO: FIX CLASS
        weapon.weaponName = EditorGUILayout.TextField("Weapon Name", weapon.weaponName);
        weapon.weaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapon.weaponType);

        //GET MATCHING VISIBLE FIELDS
        List<string> visibleFields = GetVisibleFields(weapon.weaponType);

        //HANDLE VISIBILITY
        ShowFields(weapon, visibleFields);

        //SAVE CHANGES
        if (GUI.changed)
        {
            EditorUtility.SetDirty(weapon);
        }
    }


    //GET CORRECT LIST
    //TODO: SHOULD THIS BE IMPLEMENTED AS A DICTIONARY?
    private List<string> GetVisibleFields(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Bow:
                return bowFields;
            case WeaponType.Crossbow:
                return crossbowFields;
            case WeaponType.Firearm:
                return firearmFields;
            default:
                return new List<string>();
        }
    }


    //SHOW MATCHING FIELDS
    private void ShowFields(WeaponRangedData weapon, List<string> visibleFields)
    {
        FieldInfo[] fields = typeof(WeaponRangedData).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (visibleFields.Contains(field.Name))
            {
                object value = field.GetValue(weapon);

                //INT
                if (value is int intValue)
                {
                    field.SetValue(weapon, EditorGUILayout.IntField(ObjectNames.NicifyVariableName(field.Name), intValue));
                }
                //FLOAT
                else if (value is float floatValue)
                {
                    field.SetValue(weapon, EditorGUILayout.FloatField(ObjectNames.NicifyVariableName(field.Name), floatValue));
                }
                //BOOL
                else if (value is bool boolValue)
                {
                    field.SetValue(weapon, EditorGUILayout.Toggle(ObjectNames.NicifyVariableName(field.Name), boolValue));
                }
                //PARTICLE DATA
                else if (value is ParticleData particleData)
                {
                    field.SetValue(weapon, (ParticleData)EditorGUILayout.ObjectField(ObjectNames.NicifyVariableName(field.Name), particleData, typeof(ParticleData), false));
                }
                //WEAPON AUDIO DATA
                else if (value is WeaponAudioData weaponAudioData)
                {
                    field.SetValue(weapon, (WeaponAudioData)EditorGUILayout.ObjectField(ObjectNames.NicifyVariableName(field.Name), weaponAudioData, typeof(WeaponAudioData), false));
                }
            }
        }
    }
}
