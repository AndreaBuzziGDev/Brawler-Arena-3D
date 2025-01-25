using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger
{
    //DEFAULT CONFIG
    private static DebuggerConfig defaultConfig = new DebuggerConfig
    {
        EnableDebugging = true,
        LogLevel = LogLevel.Info
    };

    private static DebuggerConfig currentConfig;

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
    }

    public static void Log(string message, LogLevel level = LogLevel.Info)
    {
        if (!Config.EnableDebugging || level < Config.LogLevel)
        {
            return;
        }
        Debug.Log($"[{level}] {message}");
    }
}

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}