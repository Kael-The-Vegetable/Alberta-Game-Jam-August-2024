using System.Collections;
using System.Linq;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [Min(0)] public float timeBetweenEvents;
    [Min(0)] public float timeVariation;
    public bool? eventWasTriggered;

    /// <summary>
    /// Lets <see cref="EventController"/> know that the event was started.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    public delegate void Callback(bool success, string message);

    public Callback callback;

    public Section[] Sections { get; set; }

    private void Awake()
    {
        callback = EventCallback;

        Sections ??= FindObjectsOfType<Section>();
        //TODO: remove later
        StartEventCycle();
    }
    void EventCallback(bool success, string message)
    {
        eventWasTriggered = success;

        if (success)
        {
            Debug.Log(message);
        }
        else
        {
            Debug.LogWarning(message);
        }
    }

    public void StartEventCycle()
    {
        float delay = Singleton.Global.Random.Next(2) == 0
            ? timeBetweenEvents - (float)Singleton.Global.Random.NextDouble() * timeVariation
            : timeBetweenEvents + (float)Singleton.Global.Random.NextDouble() * timeVariation;
        StartCoroutine(EventCycle(delay));
    }

    private IEnumerator EventCycle(float seconds)
    {
        eventWasTriggered = null;
        yield return new WaitForSeconds(seconds);
        var availableSections = Sections.Where(s => s.enabled && !s.IsEventRunning).ToArray();
        Section section = null;
        if (availableSections.Length > 0)
        {
            availableSections.SelectRandomElement();
            section.ChooseRandomEvent(callback);
        }

        if ((bool)eventWasTriggered)
        {
            StartEventCycle();
            Debug.Log("An Event Was triggered");
        }
        else
        {
            Debug.Log("No event was triggered");
        }

    }
}
