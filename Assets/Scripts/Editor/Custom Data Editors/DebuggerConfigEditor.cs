using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(DebuggerConfig))]
public class DebuggerConfigEditor : Editor
{
    private SerializedProperty enableDebugging;
    private SerializedProperty logLevel;
    private SerializedProperty debugEntries;

    private void OnEnable()
    {
        enableDebugging = serializedObject.FindProperty("EnableDebugging");
        logLevel = serializedObject.FindProperty("LogLevel");
        debugEntries = serializedObject.FindProperty("debugEntries");
    }
    
    //TODO: HEADING INITIAL SECTION
    //TODO: BUTTON/FLAG TO DEBUG EVERYTHING

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Enable Debugging Toggle
        EditorGUILayout.PropertyField(enableDebugging);

        // Log Level Dropdown
        EditorGUILayout.PropertyField(logLevel);

        // Log Type Flags
        EditorGUILayout.LabelField("Log Type Flags", EditorStyles.boldLabel);

        if (debugEntries.isArray)
        {
            for (int i = 0; i < debugEntries.arraySize; i++)
            {
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
