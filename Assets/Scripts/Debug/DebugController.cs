using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoSingleton<DebugController>
{
    
    
    [SerializeField]
    private DebuggerConfig config = new DebuggerConfig
    {
        EnableDebugging = true,
        LogLevel = LogLevel.Info
    };
    
    
    //DATA GETTER
    public DebuggerConfig Config => config;
}
