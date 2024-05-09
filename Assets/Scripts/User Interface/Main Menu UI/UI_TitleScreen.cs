using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_TitleScreen : MonoSingleton<UI_TitleScreen>
{
    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private GameInputAction inputPlayer;


    //GAMEOBJECT REFERENCES


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        inputPlayer = new GameInputAction();
        inputPlayer.Enable();

        //ACTION SUBSCRIPTIONS
        //ESCAPE
        inputPlayer.BaseActionMap.Escape.performed += OnEscapePerformed;

        //AUTO-LOAD NEXT SCENE
        StartCoroutine(WaitAndChangeScene());
    }

    void OnDestroy()
    {
        inputPlayer.BaseActionMap.Escape.performed -= OnEscapePerformed;
    }


    
    //FUNCTIONALITIES
    //TODO: JUICYNESS TO UI




    //INPUT EVENTS
    //EVENT-BASED INPUT IMPLEMENTATION
    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.MainMenu);
    }


    //COROUTINES
    IEnumerator WaitAndChangeScene()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.MainMenu);
    }

}
