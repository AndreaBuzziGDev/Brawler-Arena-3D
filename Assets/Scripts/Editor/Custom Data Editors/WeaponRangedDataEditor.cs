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
    private List<string> burstFields = new List<string> { "burstCount", "burstCooldown" };
    private List<string> chargeFields = new List<string> { "chargeTime" };


    //TODO: DISABLED BECAUSE SOME THINGS ARE BROKEN
    /*
    public override void OnInspectorGUI()
    {
        
        serializedObject.Update();
        
        WeaponRangedData weapon = (WeaponRangedData)target;

        //BASE FIELDS
        //TODO: SOLUTION WITH DATA GETTERS MIGHT WORK JUST AS FINE
        EditorGUILayout.PropertyField(serializedObject.FindProperty("damageAmount"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("needsOwnerToOperate"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("operateMode"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("attackRate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("projectileSpeed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("maxLifetime"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("tresspass"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("projectile"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponAudioData"));
        
        Debug.Log("Testing: " + serializedObject.FindProperty("operateMode"));
        Debug.Log("Testing: " + weapon.OperateMode);

        //GET MATCHING VISIBLE FIELDS
        
        List<string> visibleFields = GetVisibleFields(weapon.OperateMode);

        //HANDLE VISIBILITY
        ShowFields(weapon, visibleFields);
        

        //SAVE CHANGES
        if (GUI.changed)
            EditorUtility.SetDirty(weapon);
        
    }
    */


    //GET CORRECT LIST
    //TODO: SHOULD THIS BE IMPLEMENTED AS A DICTIONARY?
    private List<string> GetVisibleFields(WeaponRangedData.EOperateMode weaponType)
    {
        switch (weaponType)
        {
            case WeaponRangedData.EOperateMode.BURST:
                return burstFields;
            case WeaponRangedData.EOperateMode.CHARGED:
                return chargeFields;
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
