using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewDebuggerConfig", menuName = "Debug/DebuggerConfig")]
[Serializable]
public class DebuggerConfig : ScriptableObject
{
    //DATA
    public bool EnableDebugging = true;
    public LogLevel LogLevel;
    
    //DEBUG FLAG
    [LogTypeField(LogType.DEFAULT)]
    public bool debugDefault = true;

    [LogTypeField(LogType.WEAPON)]
    public bool debugWeapon = false;

    [LogTypeField(LogType.PARTICLE)]
    public bool debugParticle = false;

    [LogTypeField(LogType.SOUND)]
    public bool debugSound = false;

    [LogTypeField(LogType.SPAWNING)]
    public bool debugSpawning = false;
    
    [LogTypeField(LogType.PHYSICS)]
    public bool debugPhysics = false;
    
    [LogTypeField(LogType.AI)]
    public bool debugAI = false;
    
}
