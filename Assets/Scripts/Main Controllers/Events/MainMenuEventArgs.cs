using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuEventArgs : ManagedEvent
{
    //ENUMS
    public enum EType
    {
        MAIN_MENU,
        MAIN_OPTIONS
    }
    
    //DATA
    private EType eventType;
    public EType EventType { get { return eventType; } }



    //CONSTRUCTOR
    public MainMenuEventArgs (EType eventType = EType.MAIN_MENU)
    {
        this.eventType = eventType;
    }

    //ABSTRACT CONCRETIZATION
    public override int EventId{ get { return (int) eventType; } }
}
