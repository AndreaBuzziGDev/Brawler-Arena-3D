using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TestUIScript : MonoBehaviour
{
    //A QUICK UI SCRIPT FOR THE SAKE OF HAVING A WORKING GAMEOVER SCREEN
    //DATA
    [SerializeField] CanvasRenderer thisCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        //START LISTENING TO GAME OVER EVENTS
        EventManager<GameMenuEventArgs>.Instance.StartListening(HandleMenuEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        //STOP LISTENING TO GAME OVER EVENTS
        EventManager<GameMenuEventArgs>.Instance.StopListening(HandleMenuEvent);

    }

    //BUTTONS
    //RESTART
    public void HandleRestart() => GameController.Instance.SetState(GameController.EGameState.Restarting);


    //QUIT GAME
    public void HandleQuit() => GameController.Instance.SetState(GameController.EGameState.Quitting);


    //MENU EVENT LISTENING
    private void HandleMenuEvent(object sender, GameMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN:
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE:
                thisCanvas.gameObject.SetActive(false);
                break;
            case GameMenuEventArgs.EType.GAME_OVER:
                thisCanvas.gameObject.SetActive(true);
                break;
        }
    }
}
