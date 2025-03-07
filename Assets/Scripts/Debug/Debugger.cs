using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger
{
    //DATA
    private static DebuggerConfig currentConfig;
    private static Dictionary<LogType, Boolean> MapType = new();
    
    
    //DEFAULT CONFIG
    private static DebuggerConfig defaultConfig;
    
    
    //DELEGATE
    public delegate void DelegateDebug();
    
    
    //TODO: EXTENDED DEBUG CONTROLS
    /*
    I need an extended debug control to avoid spam of multiple entities in the log, flooding it with useless informations.

    To begin with, it might be useful to add debug flags to some parts of the code, in order to puntually control debug behaviour.
    However, this alone might not be enough to reach a satisfying implementation of the requirement.

    Another thing to do might be adding flags to override behaviours on debugs, like a flag that debugs only the player entity in a given context
    OR that allows to debug the player EVEN IF the flag is normally disabled.
    
    However, this again might not be the ideal path to go through, so i might need to look up for new debugging solutions online.
    */
    
    
    //DATA FUNCTIONS
    public static DebuggerConfig Config
    {
        get{
            if (currentConfig == null){
                DebugController instance = DebugController.Instance;
                if (instance && instance.Config)
                    currentConfig = instance.Config;
                else
                    Config = BuildDefaultConfig();
            }
            
            return currentConfig;
        }
        
        set{
            if (value == null){
                Debug.LogWarning("Attempted to set Debugger.Config to null. Ignored.");
                return;
            }
            currentConfig = value;
            Debug.LogWarning("Debugger configuration updated.");
            MapDebugging();
            RunDiagnostic();
        }
    }
    
    private static DebuggerConfig BuildDefaultConfig(){
        
        defaultConfig = ScriptableObject.CreateInstance<DebuggerConfig>();
        
        //DESIRED FALLBACK DEBUG TYPES
        defaultConfig.SetDebugFlag(LogType.DEFAULT, true);
        defaultConfig.SetDebugFlag(LogType.WEAPON, true);
        
        return defaultConfig;
    }

    
    //FUNCTIONALITIES
    
    ///DELEGATED LOG
    public static void Log(DelegateDebug method, LogType logType = LogType.DEFAULT, LogLevel level = LogLevel.Debug){
        
        if (!Config.EnableDebugging || level < Config.LogLevel)
            return;
        
        if(MapType.Count < 1)
            MapDebugging();
        
        if(MapType.GetValueOrDefault(logType, true))
            method();
    }

    ///REGULAR LOG
    public static void Log(String loggedString, LogType logType = LogType.DEFAULT, LogLevel level = LogLevel.Debug, LogMode mode = LogMode.Debug)
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
    
    //SELF DIAGNOSIS
    public static void RunDiagnostic(){
        SelfDebug();
    }
    
    private static void SelfDebug(){
        StringBuilder sb = new();
        sb.AppendLine("");
        sb.AppendLine("DEBUGGER IS REPORTING ALL ENABLED DEBUG FLAGS");
        sb.AppendLine("");

        foreach (LogType lt in MapType.Keys){
            if (MapType[lt]){
                sb.AppendLine($"+ {lt}");
            }
        }

        Debug.Log(sb.ToString());
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
