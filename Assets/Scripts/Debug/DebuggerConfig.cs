using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "NewDebuggerConfig", menuName = "Debug/DebuggerConfig")]
[Serializable]
public class DebuggerConfig : ScriptableObject
{
    //DATA
    //TODO: SERIALIZE FIELDS
    public bool EnableDebugging = true;
    public LogLevel LogLevel = LogLevel.Debug;

    //LOG TYPE ENTRIES
    [SerializeField]
    private List<LogTypeEntry> debugEntries = new List<LogTypeEntry>();



    //FUNCTIONALITIES
    private void OnValidate(){
        EnsureAllLogTypesPresent();
    }

    private void OnEnable(){
        //NB: THIS ENSURES THAT WHEN THE CONFIG IS CREATED OR INSTANTIATED, ALL POSSIBLE DEBUG FLAGS EXIST
        EnsureAllLogTypesPresent();
    }

    private void EnsureAllLogTypesPresent(){
        var logTypes = Enum.GetValues(typeof(LogType)).Cast<LogType>();

        foreach (var logType in logTypes){
            if (!debugEntries.Exists(entry => entry.logType == logType)){
                debugEntries.Add(new LogTypeEntry(logType, false));
            }
        }
    }

    public bool GetDebugFlag(LogType type){
        var entry = debugEntries.Find(e => e.logType == type);
        return entry != null && entry.enabled;
    }

    public void SetDebugFlag(LogType type, bool value){
        var entry = debugEntries.Find(e => e.logType == type);
        if (entry != null)
            entry.enabled = value;
    }

    
    
    //UTILITIES
    public List<LogTypeEntry> GetDebugEntries() => debugEntries;
    
    
    
    //NESTED CLASSES
    [Serializable]
    public class LogTypeEntry{
        public LogType logType;
        public bool enabled;

        public LogTypeEntry(LogType type, bool isEnabled){
            logType = type;
            enabled = isEnabled;
        }
    }
}