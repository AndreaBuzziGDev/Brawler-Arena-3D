using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMenuEventArgs : EventArgs {
    //ENUMS
    public enum EType {
        GAME_MENU_PAUSE_OPEN,
        GAME_MENU_PAUSE_CLOSE,
        GAME_OVER
    }

    //DATA
    public EType EventType { get; }


    //CONSTRUCTOR
    public GameMenuEventArgs(EType eventType = EType.GAME_MENU_PAUSE_OPEN) {
        this.EventType = eventType;
    }
}
