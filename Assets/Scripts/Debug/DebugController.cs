using UnityEngine;

public class DebugController : MonoSingleton<DebugController> {
    [Tooltip("Config the Debug behaviour in this scene.")]
    [SerializeField]
    private DebuggerConfig config;


    //DATA GETTER
    public DebuggerConfig Config => config;
}
