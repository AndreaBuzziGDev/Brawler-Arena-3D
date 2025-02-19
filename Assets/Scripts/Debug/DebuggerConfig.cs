using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Debugger Config", menuName = "Debug/DebuggerConfig")]
[Serializable]
public class DebuggerConfig : ScriptableObject
{
    // DATA
    public bool EnableDebugging = true;
    
    public LogLevel LogLevel;

    // DEBUG FLAGS
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
    
    [LogTypeField(LogType.EDITOR)] 
    public bool debugEditor = false;
    
    [LogTypeField(LogType.AI)] 
    public bool debugAI = false;
    
    [LogTypeField(LogType.INPUT)] 
    public bool debugInput = false;
    
    [LogTypeField(LogType.UI)] 
    public bool debugUI = false;
    
    [LogTypeField(LogType.INVENTORY)] 
    public bool debugInventory = false;
    
    [LogTypeField(LogType.SAVE_LOAD)] 
    public bool debugSaveLoad = false;
    
    [LogTypeField(LogType.DIALOGUE)] 
    public bool debugDialogue = false;
    
    [LogTypeField(LogType.PROGRESSION)] 
    public bool debugProgression = false;
    
    [LogTypeField(LogType.NETWORKING)] 
    public bool debugNetworking = false;
    
    [LogTypeField(LogType.ANIMATION)] 
    public bool debugAnimation = false;
    
    [LogTypeField(LogType.RENDERING)] 
    public bool debugRendering = false;
    
    [LogTypeField(LogType.MEMORY)] 
    public bool debugMemory = false;
    
    [LogTypeField(LogType.THREADING)] 
    public bool debugThreading = false;
    
    [LogTypeField(LogType.COLLISION)] 
    public bool debugCollision = false;
    
    [LogTypeField(LogType.NAVIGATION)] 
    public bool debugNavigation = false;
    
    [LogTypeField(LogType.WEATHER)] 
    public bool debugWeather = false;
    
    [LogTypeField(LogType.LIGHTING)] 
    public bool debugLighting = false;
    
    [LogTypeField(LogType.DESTRUCTION)] 
    public bool debugDestruction = false;
    
    [LogTypeField(LogType.ENTITY_PARAMS)] 
    public bool debugEntityParams = false;
}
