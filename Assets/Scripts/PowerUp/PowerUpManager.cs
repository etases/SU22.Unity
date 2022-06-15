using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class PowerUpManager
{
    private static readonly List<PowerUpPickupEvent> Events = new();
    private static readonly List<UnityAction<BasePowerUp, GameObject>> Listeners = new();
    
    public static void AddListener(UnityAction<BasePowerUp, GameObject> listener)
    {
        Listeners.Add(listener);
        foreach (var e in Events)
        {
            e.AddListener(listener);
        }
    }
    
    public static void AddEvent(PowerUpPickupEvent eventToAdd)
    {
        Events.Add(eventToAdd);
        foreach (var l in Listeners)
        {
            eventToAdd.AddListener(l);
        }
    }
}
