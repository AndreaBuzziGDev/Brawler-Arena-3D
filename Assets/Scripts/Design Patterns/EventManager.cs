using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager<T> where T : EventArgs
{
    //DATA
    private List<Action<object, T>> subscribers = new List<Action<object, T>>();


    //EVENT HANDLER
    private event EventHandler<T> MyHandler;


    //SINGLETON INSTANCE
    private static EventManager<T> instance;//TODO: CHECK ISSUE ABOUT READONLY
    public static EventManager<T> Instance
    {
        get
        {
            instance ??= new EventManager<T>();
            return instance;
        }
    }


    //CONSTRUCTOR
    private EventManager()
    {
        //REGISTER EVENT
        MyHandler += TriggerEvent;
    }

    ~EventManager()
    {
        //UN-REGISTER EVENT
        MyHandler -= TriggerEvent;

        //DISPOSING - REMOVING THINGS THAT LISTENED THIS
        subscribers.Clear();
    }


    //FUNCTIONALITIES
    public void StartListening(Action<object, T> listener)
    {
        //SHORTCUT
        if (listener == null) return;

        //
        subscribers.Add(listener);
    }

    public void StopListening(Action<object, T> listener)
    {
        //SHORTCUT
        if(instance == null) return;

        //
        if(subscribers.Contains(listener))
        {
            subscribers.Remove(listener);
        }
    }

    
    //NOTIFICATION
    public void Notify(object sender, T eArgs) => MyHandler?.Invoke(sender, eArgs);

    //NB: EVENT SOURCE MUST BE HANDLED IN THE EVENT ARG ITSELF.
    private void TriggerEvent(object sender, T eArgs)
    {
        //CALL ACTIONS OF INVOLVED ITEMS
        foreach(Action<object, T> act in subscribers)
        {
            act?.Invoke(sender, eArgs);
        }
    }
}
