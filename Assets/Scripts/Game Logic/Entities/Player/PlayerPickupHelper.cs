using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPickupHelper
{
    //DATA
    private static Dictionary<PickupTypes, List<Action<object, EntityPickupEventArgs>>> subscribers = new();
    private static Boolean initialized = false;


    //DATA GETTERS
    public static Dictionary<PickupTypes, List<Action<object, EntityPickupEventArgs>>> Subscribers 
    {
        get 
        {
            if(initialized)
                return subscribers;
            else
            {
                initialized = true;
                foreach(PickupTypes pickupType in Enum.GetValues(typeof(PickupTypes)))
                    subscribers.Add(pickupType, new());
                
                return subscribers;
            }
        }
    }



    //FUNCTIONALITIES
    public static void Subscribe(PickupTypes type, Action<object, EntityPickupEventArgs> listener)
    {
        if (listener == null) 
            return;

        Subscribers[type].Add(listener);
    }

    public static void Unsubscribe(PickupTypes type, Action<object, EntityPickupEventArgs> listener)
    {
        if(listener == null || !Subscribers.ContainsKey(type)) 
            return;

        //
        if(Subscribers[type].Contains(listener))
            Subscribers[type].Remove(listener);
    }

}
