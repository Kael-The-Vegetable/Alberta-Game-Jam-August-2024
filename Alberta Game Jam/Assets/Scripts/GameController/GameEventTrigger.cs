﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameEventTrigger : MonoBehaviour
{
    public Section section;

    [field: SerializeField]
    public string EventName { get; set; }

    [field: SerializeField, TextArea]
    public string EventDescription { get; set; }

    [HideInInspector]
    public bool isRunning;

    [Space]
    public UnityEvent onEventStart;
    public UnityEvent onEventUpdate;
    public UnityEvent onEventEnd;

    public void StartEvent()
    {
        section.runningEvent = this;
        onEventStart?.Invoke();
    }

    public void UpdateEvent()
    {
        onEventUpdate?.Invoke();
    }

    public void EndEvent()
    {
        section.runningEvent = null;
        onEventEnd?.Invoke();
    }

    private void OnValidate()
    {
        if (section != null)
        {
            section.OnValidate();
        }
    }
}
