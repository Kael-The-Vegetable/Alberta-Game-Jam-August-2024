﻿using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Section : MonoBehaviour
{
    [field: SerializeField]
    public EventController EventController { get; private set; }

    [field: SerializeField] public GameEventTrigger[] Events { get; set; }

    [HideInInspector]
    public GameEventTrigger runningEvent;
    public bool IsEventRunning => runningEvent != null;

    public void ChooseRandomEvent(EventController.Callback callback)
    {
        Debug.Log(Events.Length);
        string msg;
        bool success = false;
        if (IsEventRunning)
        {
            msg = $"An Event is already running";
            callback(success, msg);
        }
        else
        {
            var availableEvents = Events.Where(e => !e.isRunning).ToArray();
            var randomEvent = availableEvents.SelectRandomElement();

            try
            {
                runningEvent = randomEvent;
                msg = $"Event {randomEvent.EventName} has started";
                randomEvent.StartEvent();
                success = true;
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                msg = $"Event failed to start.";
            }
            callback(success, msg);
        }
    }

    private void Awake()
    {
        Events = GetComponentsInChildren<GameEventTrigger>();
        EventController = EventController != null ? EventController : Singleton.Global.EventController;
    }

    public void OnValidate()
    {
        Events = GetComponentsInChildren<GameEventTrigger>();
        for (int i = 0; i < Events.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(Events[i].EventName))
            {
                Debug.LogWarning($"Every event in a {typeof(Section)} should have a name.");
            }
        }
    }

    private void Update()
    {
        if (IsEventRunning)
        {
            runningEvent.UpdateEvent();
        }
    }
}