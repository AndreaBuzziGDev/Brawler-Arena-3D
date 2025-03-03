using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(WeaponRangedData))]
public class WeaponRangedDataEditor : Editor
{
    //DATA
    private bool useCustomEditor;
    private const string EditorPrefsKey = "WeaponRangedData_UseCustomEditor";

    //VISIBLE FIELDS LIST
    private Dictionary<WeaponRangedData.EOperateMode, List<string>> fieldMappings = new Dictionary<WeaponRangedData.EOperateMode, List<string>>
    {
        { WeaponRangedData.EOperateMode.BURST, new List<string> { "burstCount", "burstCooldown" } },
        { WeaponRangedData.EOperateMode.CHARGED, new List<string> { "chargeTime" } }
    };



    private void OnEnable(){
        useCustomEditor = EditorPrefs.GetBool(EditorPrefsKey, true);
    }
    
    public override void OnInspectorGUI(){
        
        //EDITOR CONTROL
        useCustomEditor = EditorGUILayout.Toggle("Use Custom Editor", useCustomEditor);
        EditorPrefs.SetBool(EditorPrefsKey, useCustomEditor);
        
        //DEFAULT EDITOR
        if (!useCustomEditor){
            DrawDefaultInspector();
            return;
        }
        
        
        //CUSTOM EDITOR
        serializedObject.Update();
        WeaponRangedData weapon = (WeaponRangedData) target;

        //BASE FIELDS
        // GENERAL SECTION
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("damageAmount"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("needsOwnerToOperate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("hasFriendlyFire"));
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
        EditorGUILayout.LabelField("Mode Specific Behaviours", EditorStyles.boldLabel);
        List<string> visibleFields = fieldMappings.TryGetValue(weapon.OperateMode, out var fields) ? fields : new List<string>();
        if(visibleFields.Count > 0)
            ShowFields(visibleFields);
        else
            EditorGUILayout.LabelField("None", EditorStyles.miniLabel);
        EditorGUILayout.Space(5);
        
        // REFERENCES
        EditorGUILayout.LabelField("References", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("projectile"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("particleShooting"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("particleHitting"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("particleTrespassing"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponAudioData"));
        EditorGUILayout.Space(5);
        
        Debugger.Log(DebugEditor, LogType.EDITOR);
        

        //SAVE CHANGES
        serializedObject.ApplyModifiedProperties();
        
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
    
    
    
    //DEBUG
    public void DebugEditor(){
        //...
        Debug.Log("Test Debug in Weapon Ranged Data Editor");
    }
}
