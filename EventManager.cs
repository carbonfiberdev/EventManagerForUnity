using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager {
    private static Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();
    private static Dictionary<string, Action<int>> intEventDictionary = new Dictionary<string, Action<int>>();
    private static Dictionary<string, Action<float>> floatEventDictionary = new Dictionary<string, Action<float>>();
    private static Dictionary<string, Action<bool>> boolEventDictionary = new Dictionary<string, Action<bool>>();
    private static Dictionary<string, Action<string>> stringEventDictionary = new Dictionary<string, Action<string>>();
    private static Dictionary<string, Action<GameObject>> objectEventDictionary = new Dictionary<string, Action<GameObject>>();

    #region AddListeners
    public static void AddListener(string eventName, Action listener) {
        if (eventDictionary.ContainsKey(eventName)) {
            eventDictionary[eventName] += listener;
        } else {
            eventDictionary.Add(eventName, listener);
        }
    }

    public static void AddListener(string eventName, Action<int> listener)
    {
        if (intEventDictionary.ContainsKey(eventName))
        {
            intEventDictionary[eventName] += listener;
        }
        else
        {
            intEventDictionary.Add(eventName, listener);
        }
    }

    public static void AddListener(string eventName, Action<float> listener) {
        if (floatEventDictionary.ContainsKey(eventName)) {
            floatEventDictionary[eventName] += listener;
        } else {
            floatEventDictionary.Add(eventName, listener);
        }
    }

    public static void AddListener(string eventName, Action<bool> listener)
    {
        if (boolEventDictionary.ContainsKey(eventName))
        {
            boolEventDictionary[eventName] += listener;
        }
        else
        {
            boolEventDictionary.Add(eventName, listener);
        }
    }

    public static void AddListener(string eventName, Action<GameObject> listener)
    {
        if (objectEventDictionary.ContainsKey(eventName))
        {
            objectEventDictionary[eventName] += listener;
        }
        else
        {
            objectEventDictionary.Add(eventName, listener);
        }
    }

    public static void AddListener(string eventName, Action<string> listener)
    {
        if (stringEventDictionary.ContainsKey(eventName))
        {
            stringEventDictionary[eventName] += listener;
        }
        else
        {
            stringEventDictionary.Add(eventName, listener);
        }
    }
    #endregion

    #region RemoveListeners
    public static void RemoveListener(string eventName, Action listener) {
        if (eventDictionary.ContainsKey(eventName)) {
            eventDictionary[eventName] -= listener;
        }
    }

    public static void RemoveListener(string eventName, Action<int> listener)
    {
        if (intEventDictionary.ContainsKey(eventName))
        {
            intEventDictionary[eventName] -= listener;
        }
    }

    public static void RemoveListener(string eventName, Action<float> listener) {
        if (floatEventDictionary.ContainsKey(eventName)) {
            floatEventDictionary[eventName] -= listener;
        }
    }

    public static void RemoveListener(string eventName, Action<bool> listener)
    {
        if (boolEventDictionary.ContainsKey(eventName))
        {
            boolEventDictionary[eventName] -= listener;
        }
    }

    public static void RemoveListener(string eventName, Action<GameObject> listener)
    {
        if (objectEventDictionary.ContainsKey(eventName))
        {
            objectEventDictionary[eventName] -= listener;
        }
    }

    public static void RemoveListener(string eventName, Action<String> listener)
    {
        if (stringEventDictionary.ContainsKey(eventName))
        {
            stringEventDictionary[eventName] -= listener;
        }
    }
    #endregion

    #region TriggerEvents
    public static void TriggerEvent(string eventName) {
        Action thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent?.Invoke();
        }
    }

    public static void TriggerEvent(string eventName, int value)
    {
        Action<int> thisEvent = null;
        if (intEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(value);
        }
    }

    public static void TriggerEvent(string eventName, float value) {
        Action<float> thisEvent = null;
        if (floatEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent?.Invoke(value);
        }
    }

    public static void TriggerEvent(string eventName, bool value)
    {
        Action<bool> thisEvent = null;
        if (boolEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(value);
        }
    }

    public static void TriggerEvent(string eventName, GameObject gameObject)
    {
        Action<GameObject> thisEvent = null;
        if (objectEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(gameObject);
        }
    }

    public static void TriggerEvent(string eventName, string gameObject)
    {
        Action<string> thisEvent = null;
        if (stringEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(gameObject);
        }
    }
    #endregion

    public static List<Action> GetListeners(string eventName) {
        Action thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            return new List<Action>((IEnumerable<Action>)thisEvent.GetInvocationList());
        } else {
            return new List<Action>();
        }
    }

    public static List<Action<float>> GetFloatListeners(string eventName) {
        Action<float> thisEvent = null;
        if (floatEventDictionary.TryGetValue(eventName, out thisEvent)) {
            return new List<Action<float>>((IEnumerable<Action<float>>)thisEvent.GetInvocationList());
        } else {
            return new List<Action<float>>();
        }
    }
}

