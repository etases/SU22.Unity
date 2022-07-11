using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventManager : MonoBehaviour
{
    private Dictionary<string, Action<EventData>> m_EventDictionary;

    private void Awake()
    {
        m_EventDictionary ??= new Dictionary<string, Action<EventData>>();
    }

    public void StartListening(string eventName, Action<EventData> listener)
    {
        if (m_EventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent += listener;
            m_EventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public void StopListening(string eventName, Action<EventData> listener)
    {
        if (!m_EventDictionary.TryGetValue(eventName, out var thisEvent)) return;
        thisEvent -= listener;
        m_EventDictionary[eventName] = thisEvent;
    }

    public void TriggerEvent(string eventName, EventData message)
    {
        if (m_EventDictionary.TryGetValue(eventName, out var thisEvent)) thisEvent.Invoke(message);
    }
}

public class EventData : Dictionary<string, object>
{
}