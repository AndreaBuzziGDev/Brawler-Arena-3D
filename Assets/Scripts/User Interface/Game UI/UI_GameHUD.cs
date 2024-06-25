using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UI_GameHUD : MonoBehaviour
{
    //DATA
    //TODO: THIS SHOULD BE THE EQUIVALENT OF UI_RaindropsGame

    //INSPECTOR REFERENCES
    [SerializeField] CanvasRenderer thisPanel;
    

    //LIFECYCLE FUNCTIONS
    void Start()
    {
        EventManager<GameMenuEventArgs>.Instance.StartListening(HandleMenuEvent);
    }

    void Update()
    {
        EventManager<GameMenuEventArgs>.Instance.Notify(this, new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_OVER));
    }

    void OnDestroy()
    {
        EventManager<GameMenuEventArgs>.Instance.StopListening(HandleMenuEvent);
    }


    //FUNCTIONALITIES
    //...


    //EVENT-HANDLING DELEGATE
    public void HandleMenuEvent(object sender, GameMenuEventArgs e)
    {
        Debug.Log("This Object is: " + this.gameObject.name);
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
