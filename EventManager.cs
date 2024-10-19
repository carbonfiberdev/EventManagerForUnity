using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    private static readonly Dictionary<string, Delegate> eventDictionary = new Dictionary<string, Delegate>();

    #region AddListeners

    public static void AddListener<T>(string eventName, Action<T> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out var existingDelegate))
        {
            eventDictionary[eventName] = Delegate.Combine(existingDelegate, listener);
        }
        else
        {
            eventDictionary[eventName] = listener;
        }
    }

    // Overload for no parameters using Action
    public static void AddListener(string eventName, Action listener)
    {
        AddListener<object>(eventName, _ => listener());
    }

    #endregion

    #region RemoveListeners

    public static void RemoveListener<T>(string eventName, Action<T> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out var existingDelegate))
        {
            eventDictionary.Remove(eventName);
        }
    }

    public static void RemoveListener(string eventName, Action listener)
    {
        RemoveListener<object>(eventName, _ => listener());
    }

    #endregion

    #region TriggerEvents

    public static void TriggerEvent<T>(string eventName, T value)
    {
        if (eventDictionary.TryGetValue(eventName, out var existingDelegate))
        {
            var action = existingDelegate as Action<T>;
            action?.Invoke(value);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        TriggerEvent<object>(eventName, null);
    }

    #endregion
}
