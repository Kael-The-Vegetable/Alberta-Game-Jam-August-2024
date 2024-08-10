using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [Min(0)] public float timeBetweenEvents;
    public bool eventWasTriggered;

    /// <summary>
    /// Lets <see cref="EventController"/> know that the event was started.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    public delegate void Callback(string eventName);

    public Callback callback;

    [NonReorderable]
    public Section[] sections;

    private void Awake()
    {
        callback = (n) =>
        {
            eventWasTriggered = true;
            Debug.Log($"Event {n} was triggered.");
        };

        sections ??= FindObjectsOfType<Section>();
    }

    private IEnumerator Wait(float seconds)
    {
        eventWasTriggered = false;
        yield return new WaitForSeconds(seconds);

    }
}
