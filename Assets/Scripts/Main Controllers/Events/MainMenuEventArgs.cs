using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        MAIN_MENU,
        MAIN_OPTIONS
    }
    
    //DATA
    public EType EventType { get; }



    //CONSTRUCTOR
    public MainMenuEventArgs (EType eventType = EType.MAIN_MENU)
    {
        this.EventType = eventType;
    }
}
