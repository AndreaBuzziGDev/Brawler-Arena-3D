using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger
{
    //DATA
    private static DebuggerConfig currentConfig;
    
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
                {
                    currentConfig = instance.Config;
                }
                else
                {
                    // Usa la configurazione di default
                    currentConfig = defaultConfig;
                }
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
    
    //
    public static void Log(DelegateDebug method, LogType logType = LogType.DEFAULT){
        //TODO: FLOW CONTROL LOGIC
        //DEVELOP FUNCTIONALITY THAT RETURNS TRUE VALUE WHEN THE CONFIG IS ENABLED TO DEBUG THAT TYPE SPECIFICALLY
        if(true){
            Debug.Log("This is Delegate Log");
            method();
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
    SPAWNING
}
