using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

//TODO: RENAME THIS SCRIPT "UI_GameMenuPause"?
public class UI_GameMenuPanel : MonoBehaviour
{
    //DATA


    //INSPECTOR REFERENCES
    //TODO: USE "REQUIRE"?
    [SerializeField] CanvasRenderer thisPanel;


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //DISABLE BUTTON PANEL
        //TODO: IS THIS NECESSARY? CAN IT BE REFACTORED?
        thisPanel.gameObject.SetActive(false);

        //LISTEN EVENTS
        EventManager<GameMenuEventArgs>.Instance.StartListening(HandleMenuEvent);
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        EventManager<GameMenuEventArgs>.Instance.StopListening(HandleMenuEvent);
    }


    //FUNCTIONALITIES
    //GUI BUTTONS
    public void HandleContinue() => GameController.Instance.SetState(GameController.EGameState.Playing);

    public void HandleMainMenu() => GameController.Instance.SetState(GameController.EGameState.Quitting);

    public void HandleRestart() => GameController.Instance.SetState(GameController.EGameState.Restarting);

    public void HandleQuit() => GameController.Instance.SetState(GameController.EGameState.Exiting);


    //EVENT HANDLING
    public void HandleMenuEvent(object sender, GameMenuEventArgs e)
    {
        //TODO: UPDATE LOGIC WHEN THE IDEA IS UNDERSTOOD BETTER
        switch(e.EventType)
        {
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN:
                thisPanel.gameObject.SetActive(true);
                break;
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE:
            case GameMenuEventArgs.EType.GAME_OVER:
                thisPanel.gameObject.SetActive(false);
                break;
        }
    }
}
