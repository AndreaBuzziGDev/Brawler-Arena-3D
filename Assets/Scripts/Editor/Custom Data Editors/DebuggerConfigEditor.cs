using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(DebuggerConfig))]
public class DebuggerConfigEditor : Editor
{
    private SerializedProperty enableDebugging;
    private SerializedProperty logLevel;
    private SerializedProperty debugEntries;

    private void OnEnable(){
        enableDebugging = serializedObject.FindProperty("EnableDebugging");
        logLevel = serializedObject.FindProperty("LogLevel");
        debugEntries = serializedObject.FindProperty("debugEntries");
    }



    //TODO: BUTTON/FLAG TO DEBUG EVERYTHING
    
    public override void OnInspectorGUI(){
        serializedObject.Update();

        // GENERAL SECTION
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
        
        EditorGUILayout.PropertyField(enableDebugging);
        EditorGUILayout.PropertyField(logLevel);
        
        
        //LOG TYPE FLAGS
        EditorGUILayout.LabelField("Log Type Flags", EditorStyles.boldLabel);
        
        if (debugEntries.isArray){
            for (int i = 0; i < debugEntries.arraySize; i++){
                SerializedProperty entry = debugEntries.GetArrayElementAtIndex(i);
                SerializedProperty logType = entry.FindPropertyRelative("logType");
                SerializedProperty enabled = entry.FindPropertyRelative("enabled");

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(logType.enumNames[logType.enumValueIndex], GUILayout.Width(150));
                enabled.boolValue = EditorGUILayout.Toggle(enabled.boolValue);
                EditorGUILayout.EndHorizontal();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
