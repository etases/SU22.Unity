using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventManager : MonoBehaviour
{
    private static SimpleEventManager _simpleEventManager;
    private Dictionary<string, Action<EventData>> m_EventDictionary;

    public static SimpleEventManager instance
    {
        get
        {
            if (_simpleEventManager) return _simpleEventManager;

            _simpleEventManager = FindObjectOfType(typeof(SimpleEventManager)) as SimpleEventManager;

            if (!_simpleEventManager)
            {
                Debug.LogError("There needs to be one active SimpleEventManager script on a GameObject in your scene.");
            }
            else
            {
                _simpleEventManager.Init();

                //  Sets this to not be destroyed when reloading scene
                DontDestroyOnLoad(_simpleEventManager);
            }

            return _simpleEventManager;
        }
    }

    private void Init()
    {
        m_EventDictionary ??= new Dictionary<string, Action<EventData>>();
    }

    public static void StartListening(string eventName, Action<EventData> listener)
    {
        if (instance.m_EventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += listener;
            instance.m_EventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, Action<EventData> listener)
    {
        if (_simpleEventManager == null) return;
        if (!instance.m_EventDictionary.TryGetValue(eventName, out var thisEvent)) return;
        thisEvent -= listener;
        instance.m_EventDictionary[eventName] = thisEvent;
    }

    public static void TriggerEvent(string eventName, EventData message)
    {
        if (instance.m_EventDictionary.TryGetValue(eventName, out var thisEvent)) thisEvent.Invoke(message);
    }
}

public class EventData : Dictionary<string, object>
{
}