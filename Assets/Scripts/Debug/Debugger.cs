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
    private static DebuggerConfig defaultConfig;
    
    
    //DELEGATE
    public delegate void DelegateDebug();
    
    
    
    //DATA FUNCTIONS
    public static DebuggerConfig Config
    {
        get
        {
            if (currentConfig == null)
            {
                DebugController instance = DebugController.Instance;
                if (instance && instance.Config)
                    currentConfig = instance.Config;
                else
                    currentConfig = BuildDefaultConfig();
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
            Debug.LogWarning("Debugger configuration updated.");
        }
    }
    
    private static DebuggerConfig BuildDefaultConfig()
    {
        //
        defaultConfig = ScriptableObject.CreateInstance<DebuggerConfig>();
        defaultConfig.EnableDebugging = true;//TODO: MIGHT NOT BE NECESSARY
        defaultConfig.LogLevel = LogLevel.Info;//TODO: MIGHT NOT BE NECESSARY
        
        //TODO: MIGHT NOT BE NECESSARY
        foreach (var entry in defaultConfig.GetDebugEntries()){
            entry.enabled = false;
        }
        defaultConfig.SetDebugFlag(LogType.DEFAULT, true);
        
        return defaultConfig;
    }

    
    //FUNCTIONALITIES
    
    ///DELEGATED LOG
    public static void Log(DelegateDebug method, LogType logType = LogType.DEFAULT, LogLevel level = LogLevel.Debug){
        
        /*
        Debug.Log("Test 0 " + method);
        Debug.Log("Test 0 " + logType);
        Debug.Log("Test 0 " + level);
        */
        
        if (!Config.EnableDebugging || level < Config.LogLevel)
            return;
        
        if(MapType.Count < 1)
            MapDebugging();
        
        if(MapType.GetValueOrDefault(logType, true))
            method();
    }

    ///REGULAR LOG
    public static void Log(String loggedString, LogType logType = LogType.DEFAULT, LogLevel level = LogLevel.Info, LogMode mode = LogMode.Debug)
    {
        if (!Config.EnableDebugging || level < Config.LogLevel)
            return;
        
        if (MapType.Count < 1)
            MapDebugging();
        
        if (MapType.GetValueOrDefault(logType, true))
            Log(loggedString, mode);
    }
    
    ///LOG BEHAVIOUR BASED ON MODE
    private static void Log(String loggedString, LogMode mode = LogMode.Debug){
        switch(mode){
            case LogMode.Warning:
                Debug.LogWarning(loggedString);
                break;
            case LogMode.Error:
                Debug.LogError(loggedString);
                break;
            case LogMode.Debug:
                Debug.Log(loggedString);
                break;
        }
    }
    
    
    

    //UTILITIES
    public static void MapDebugging()
    {
        MapType.Clear();
        foreach (var entry in Config.GetDebugEntries()){
            MapType[entry.logType] = entry.enabled;
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
