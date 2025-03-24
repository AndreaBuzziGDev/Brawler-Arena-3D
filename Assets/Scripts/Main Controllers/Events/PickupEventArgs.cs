using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupEventArgs : EventArgs
{
    //DATA
    public PickupTypes EventType { get;}
    public int PickerId { get; }
    
    //TODO: TO ADDRESS PROPERTIES RELATED TO PICKUP ITEMS DO THE FOLLOWING:
    //1) INTRODUCE A SCRIPTABLE OBJECT FAMILY THAT CONTAINS THE DATA OF THE ITEM BEING PICKED UP
    //1.1) MIGHT NEED SOME SPECIALIZATION AND SOME DEGREE OF EVOLUTION VIA MULTIPLE CLASSES
    //1.2) INTRODUCE A CUSTOM EDITOR IF NECESSARY
    //2) PUT THE SCRIPTABLEOBJECTS HERE AS VARIABLES AND ON THE PICKED UP ITEM
    //3) IMPLEMENT THE LOGIC IN THE CLASS(ES) THAT REPRESENT ENTITIES THAT CAN PICK UP ITEMS (THE PLAYER, FOR NOW)
    //4) DO ALL THE SCRIPTABLEOBJECT CONFIGURATIONS
    //


    //CONSTRUCTOR
    public PickupEventArgs(PickupTypes eventType, int pickerId)
    {
        this.EventType = eventType;
        this.PickerId = pickerId;
    }
}
