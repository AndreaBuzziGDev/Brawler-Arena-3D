using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(WeaponRangedData))]
public class WeaponRangedDataEditor : Editor
{
    //VISIBLE FIELDS LIST
    //TODO: ALWAYS VISIBLE FIELDS
    
    //TODO: ADJUST FIELDS
    private List<string> burstFields = new List<string> { "burstCount", "burstCooldown" };
    private List<string> chargeFields = new List<string> { "chargeTime" };


    //TODO: DISABLED BECAUSE SOME THINGS ARE BROKEN
    
    public override void OnInspectorGUI()
    {
        
        serializedObject.Update();
        
        WeaponRangedData weapon = (WeaponRangedData)target;

        //BASE FIELDS
        //TODO: SOLUTION WITH DATA GETTERS MIGHT WORK JUST AS FINE
        // GENERAL SECTION
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("damageAmount"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("needsOwnerToOperate"));
        EditorGUILayout.Space(5);
        
        // COMBAT SETTINGS
        EditorGUILayout.LabelField("Combat Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("operateMode"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("attackRate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("projectileSpeed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("maxLifetime"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("tresspass"));
        EditorGUILayout.Space(5);

        // MODE SPECIFIC BEHAVIOURS
        //TODO: SHOW ONLY IF THERE ARE, OR SHOW "NONE" AS A PLACEHOLDER TEXT
        EditorGUILayout.LabelField("Mode Specific Behaviours", EditorStyles.boldLabel);
        List<string> visibleFields = GetVisibleFields(weapon.OperateMode);
        ShowFields(visibleFields);
        EditorGUILayout.Space(5);
        
        // REFERENCES
        EditorGUILayout.LabelField("References", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("projectile"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponAudioData"));
        EditorGUILayout.Space(5);
        
        Debug.Log("Testing: " + serializedObject.FindProperty("operateMode"));
        Debug.Log("Testing: " + weapon.OperateMode);

        //TODO: MISSING FIELDS, COMPLETE THE EDITOR
        

        //SAVE CHANGES
        serializedObject.ApplyModifiedProperties();
        
    }
    


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
    private void ShowFields(List<string> visibleFields)
    {
        FieldInfo[] fields = typeof(WeaponRangedData).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Debug.Log("fields number: " + fields.Count());
        
        foreach (string field in visibleFields){
            SerializedProperty property = serializedObject.FindProperty(field);
            if (property != null)
            {
                EditorGUILayout.PropertyField(property, true);
            }
        }
    }
}
