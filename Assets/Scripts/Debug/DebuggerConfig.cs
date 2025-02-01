using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerConfig
{
    //DATA
    public bool EnableDebugging;
    public LogLevel LogLevel;
    
    //DEBUG FLAG
    //TODO: USE TUPLES OR SOMETHING ELSE TO MAKE THIS MORE SCALABLE
    public bool debugDefault = true;
    public bool debugWeapon = false;
    public bool debugParticle = false;
    public bool debugSound = false;
    public bool debugSpawning = false;
    
    
}
