using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPickupHelper
{
    //DATA
    private static Dictionary<PickupController.EPickupTypes, List<Action<object, EntityPickupEventArgs>>> subscribers = new();
    private static Boolean initialized = false;


    //DATA GETTERS
    public static Dictionary<PickupController.EPickupTypes, List<Action<object, EntityPickupEventArgs>>> Subscribers 
    { 
        get 
        {
            if(initialized)
                return subscribers;
            else
            {
                initialized = true;
                foreach(PickupController.EPickupTypes pickupType in Enum.GetValues(typeof(PickupController.EPickupTypes)))
                    subscribers.Add(pickupType, new());
                
                return subscribers;
            }
        } 
        
    }



    //FUNCTIONALITIES
    public static void SubscribePlayerPickup(PickupController.EPickupTypes type, Action<object, EntityPickupEventArgs> listener)
    {
        if (listener == null) 
            return;

        subscribers[type].Add(listener);
    }
    public static void UnsubscribePlayerPickup(PickupController.EPickupTypes type, Action<object, EntityPickupEventArgs> listener)
    {
        if(listener == null || !subscribers.ContainsKey(type)) 
            return;

        //
        if(subscribers[type].Contains(listener))
            subscribers[type].Remove(listener);
    }

}
