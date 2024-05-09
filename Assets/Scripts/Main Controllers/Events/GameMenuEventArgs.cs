using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMenuEventArgs : ManagedEvent
{
    //ENUMS
    public enum EType
    {
        GAME_MENU_PAUSE_OPEN,
        GAME_MENU_PAUSE_CLOSE,
        GAME_OVER
    }

    //DATA
    private EType eventType;
    public EType EventType { get { return eventType; } }



    //CONSTRUCTOR
    public GameMenuEventArgs (EType eventType = EType.GAME_MENU_PAUSE_OPEN)
    {
        this.eventType = eventType;
    }

    //ABSTRACT CONCRETIZATION
    public override int EventId{ get { return (int) eventType; } }
}
