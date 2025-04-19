using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UI_GameHUD : MonoBehaviour {
    //DATA
    //TODO: THIS SHOULD BE THE EQUIVALENT OF UI_RaindropsGame

    //INSPECTOR REFERENCES
    [SerializeField] CanvasRenderer thisCanvas;


    //LIFECYCLE FUNCTIONS
    void Start() {
        EventManager<GameMenuEventArgs>.Instance.StartListening(HandleMenuEvent);
    }

    void Update() {
        //TODO: WHY WAS THIS PUT IN HERE? IS IT A CODE EDIT LEFTOVER?
        //EventManager<GameMenuEventArgs>.Instance.Notify(this, new GameMenuEventArgs(GameMenuEventArgs.EType.GAME_OVER));
    }

    void OnDestroy() {
        EventManager<GameMenuEventArgs>.Instance.StopListening(HandleMenuEvent);
    }


    //FUNCTIONALITIES
    //...


    //EVENT-HANDLING DELEGATE
    public void HandleMenuEvent(object sender, GameMenuEventArgs e) {
        Debugger.Log("This Object is: " + this.gameObject.name, LogType.UI);
        switch (e.EventType) {
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE:
                thisCanvas.gameObject.SetActive(true);
                break;
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN:
            case GameMenuEventArgs.EType.GAME_OVER:
                thisCanvas.gameObject.SetActive(false);
                break;
        }
    }
}
