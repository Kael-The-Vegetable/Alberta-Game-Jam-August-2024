using UnityEngine;

public abstract class Section : MonoBehaviour
{
    public delegate bool Event(out bool success);

    [field:SerializeField]
    public EventController EventController { get; private set; }
    public Event[] Events { get; set; }

    public void ChooseRandomEvent(EventController.Callback callback)
    {
        var randomEvent = Events.SelectRandomElement();
        randomEvent(out var success);

        string msg = success
            ? $"Event {randomEvent.Method.Name} was triggered"
            : $"Event {randomEvent.Method.Name} failed to trigger.";
        callback(success, msg);
    }
}