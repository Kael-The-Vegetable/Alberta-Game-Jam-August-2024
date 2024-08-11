using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [field: SerializeField]
    public Section[] Sections { get; set; }

    private void Awake()
    {
        callback = EventCallback;

        //TODO: remove later
        StartEventCycle();

        SceneManager.sceneLoaded += FindSections;
    }

    private void FindSections(Scene arg0, LoadSceneMode arg1)
    {
        Sections = FindObjectsOfType<Section>();
    }

    void EventCallback(bool success, string message)
    {
        if (success)
        {
            Debug.Log("An Event Was triggered");
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
        Debug.Log($"Waiting {seconds} seconds to start event");
        yield return new WaitForSeconds(seconds);
        var availableSections = Sections.Where(s => s.enabled && !s.IsEventRunning).ToArray();
        Section section = null;
        if (availableSections.Length > 0)
        {
            section = availableSections.SelectRandomElement();
            section.ChooseRandomEvent(callback);
        }

        StartEventCycle();
    }
}
