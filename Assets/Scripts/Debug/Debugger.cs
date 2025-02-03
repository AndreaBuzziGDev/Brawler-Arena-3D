using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public static class Debugger
{
    //DATA
    private static DebuggerConfig currentConfig;
    private static Dictionary<LogType, Boolean> MapType = new();
    
    
    //DEFAULT CONFIG
    private static DebuggerConfig defaultConfig = new DebuggerConfig
    {
        EnableDebugging = true,
        LogLevel = LogLevel.Info
    };
    
    
    //DELEGATE
    public delegate void DelegateDebug();//TODO: THIS NEEDS TO ACCEPT PARAMETERS LIKE DESCRIBED IN THE WeaponRangedHelper TODO
    
    
    
    //DATA FUNCTIONS
    public static DebuggerConfig Config
    {
        get
        {
            if (currentConfig == null)
            {
                // Prova a trovare un MonoSingleton nella scena
                DebugController instance = DebugController.Instance;
                if (instance != null)
                    currentConfig = instance.Config;
                else
                    currentConfig = defaultConfig;
            }
            return currentConfig;
        }
        
        set
        {
            if (value == null)
            {
                Debug.LogWarning("Attempted to set Debugger.Config to null. Ignored.");
                return;
            }
            currentConfig = value;
            MapDebugging();
            Debug.Log("Debugger configuration updated.");
        }
    }

    
    //FUNCTIONALITIES
    public static void Log(string message, LogLevel level = LogLevel.Info){
        if (!Config.EnableDebugging || level < Config.LogLevel)
            return;
        
        //
        Debug.Log($"[{level}] {message}");
    }
    
    //TODO: COMBINE LOG LEVEL AND TYPE FUNCTIONALITIES IN ONE SINGLE METHOD
    public static void Log(DelegateDebug method, LogType logType = LogType.DEFAULT){
        //DEVELOP FUNCTIONALITY THAT RETURNS TRUE VALUE WHEN THE CONFIG IS ENABLED TO DEBUG THAT TYPE SPECIFICALLY
        if(MapType.Count < 1)
            MapDebugging();
        
        if(MapType[logType]){
            Debug.Log("This is Delegate Log");
            method();
        }
    }
    
    
    

    //UTILITIES
    public static void MapDebugging(){
        
        //
        MapType.Clear();
        DebuggerConfig dConfig = Config;
        FieldInfo[] fields = dConfig.GetType().GetFields();
        
        foreach (FieldInfo field in fields)
        {
            LogTypeFieldAttribute attribute = field.GetCustomAttribute<LogTypeFieldAttribute>();
            
            if (attribute != null && field.FieldType == typeof(bool))
                MapType[attribute.LogType] = (bool)field.GetValue(dConfig);
        }
    }
    
    
    
}


//PUBLIC ENUMS
public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}


public enum LogType
{
    DEFAULT,
    WEAPON,
    PARTICLE,
    SOUND,
    SPAWNING,
    PHYSICS,
    AI
}
