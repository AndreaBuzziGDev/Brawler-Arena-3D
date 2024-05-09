using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //ENUMS
    public enum EGameState
    {
        Start,
        Playing,
        Paused,
        GameOver,
        Restarting,
        Quitting,
        Exiting
    }
    

    //DATA
    ///SIMPLE DATA
    private EGameState state = 0;
    public bool IsPaused { get { return this.state == EGameState.Paused; } }
    public bool IsGameOver { get { return this.state == EGameState.GameOver; } }
    public bool IsPlaying { get { return !(IsPaused || IsGameOver); } }


    //GAMEOBJECT REFERENCES




    // Start is called before the first frame update
    void Start()
    {
        //ENFORCES START SEQUENCE
        SetState(EGameState.Start);
    }



    
    //FUNCTIONALITIES
    public void SetState(EGameState targetState)
    {
        state = targetState;
        switch (state)
        {
            case EGameState.Start:
                //RESERVED FOR INITIALIZATION
                SetState(EGameState.Playing);
                break;
            case EGameState.Playing:
                EventManager<GameMenuEventArgs>.Instance.Notify(this, new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE));
                break;
            case EGameState.Paused:
                EventManager<GameMenuEventArgs>.Instance.Notify(this, new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN));
                break;
            case EGameState.GameOver:
                EventManager<GameMenuEventArgs>.Instance.Notify(this, new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_OVER));
                break;
            case EGameState.Restarting:
                RestartGame();
                break;
            case EGameState.Quitting:
                QuitGame();
                break;
            case EGameState.Exiting:
                ExitGame();
                break;
        }
    }





    //STAGE-TRANSITION FUNCTIONALITIES

    //RESTART GAME
    private static void RestartGame() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.GameScene);

    //QUIT GAME (ABANDON SESSION)
    private static void QuitGame() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.MainMenu);


    //EXIT GAME
    private static void ExitGame() => UtilsGeneric.QuitGame();




    //OTHER...
    

}
