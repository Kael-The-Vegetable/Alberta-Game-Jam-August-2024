using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class EventController : MonoBehaviour
{
    [Min(0)] public float timeBetweenEvents;
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
        callback = (b, m) =>
        {
            eventWasTriggered = b;

            if (b)
            {
                Debug.Log(m);
            }
            else
            {
                Debug.LogWarning(m);
            }
        };

        Sections ??= FindObjectsOfType<Section>();

        //TODO: remove later
        StartEventCycle();
    }

    public void StartEventCycle()
    {
        StartCoroutine(EventCycle(timeBetweenEvents));
    }

    private IEnumerator EventCycle(float seconds)
    {
        eventWasTriggered = null;
        yield return new WaitForSeconds(seconds);
        var section = Sections.Where(s => s.enabled && !s.IsEventRunning).ToArray().SelectRandomElement();
        section.ChooseRandomEvent(callback);

        if ((bool)eventWasTriggered)
        {
            // Continue the cycle
            StartCoroutine(EventCycle(seconds));
        }
        else
        {
            // Stop the cycle
            Debug.Log("Stopping event cycle");
        }
    }
}
