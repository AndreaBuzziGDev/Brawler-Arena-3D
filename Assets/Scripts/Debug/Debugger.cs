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
    public delegate void DelegateDebug();
    
    
    
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
    
    /*
    
    TODO: IMPLEMENT LOG DIVERSIFICATION (Log, LogWarning, LogError)
    UNDERSTAND THE DIFFERENCE OF USAGE BETWEEN Info AND Debug
    
    IF NECESSARY, USE ANOTHER ENUM TO ADDRESS FUNCTIONALITY NEEDS
    
    */
    
    ///DELEGATED LOG
    public static void Log(DelegateDebug method, LogType logType = LogType.DEFAULT, LogLevel level = LogLevel.Info){
        
        if (!Config.EnableDebugging || level < Config.LogLevel)
            return;
        
        if(MapType.Count < 1)
            MapDebugging();
        
        if(MapType.GetValueOrDefault(logType, true))
            method();
    }
    
    ///REGULAR LOG
    public static void Log(String loggedString, LogType logType = LogType.DEFAULT, LogLevel level = LogLevel.Info){
        
        if (!Config.EnableDebugging || level < Config.LogLevel)
            return;
        
        if(MapType.Count < 1)
            MapDebugging();
        
        if(MapType.GetValueOrDefault(logType, true))
            Debug.Log(loggedString);
    }
    
    
    

    //UTILITIES
    public static void MapDebugging(){
        
        //
        MapType.Clear();
        DebuggerConfig dConfig = Config;
        FieldInfo[] fields = dConfig.GetType().GetFields();
        
        foreach (FieldInfo field in fields){
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

public enum LogMode
{
    Debug,
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
    EDITOR,
    AI,
    INPUT,
    UI,
    INVENTORY,
    SAVE_LOAD,
    DIALOGUE,
    PROGRESSION,
    NETWORKING,
    ANIMATION,
    RENDERING,
    MEMORY,
    THREADING,
    COLLISION,
    NAVIGATION,
    WEATHER,
    LIGHTING,
    DESTRUCTION,
    ENTITY_PARAMS
}
