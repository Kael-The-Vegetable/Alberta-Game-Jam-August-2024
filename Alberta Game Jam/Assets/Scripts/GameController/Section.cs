using UnityEngine;
using UnityEngine.Events;

public abstract class Section : MonoBehaviour
{
    public delegate void Event(out bool success);

    [field: SerializeField]
    public EventController EventController { get; private set; }
    protected virtual UnityAction[] Events { get; set; }

    public void ChooseRandomEvent(EventController.Callback callback)
    {
        var randomEvent = Events.SelectRandomElement();
        string msg;
        bool success = false;
        try
        {
            randomEvent.Invoke();
            msg = $"Event {randomEvent.Method.Name} was triggered";
            success = true;
        }
        catch (System.Exception)
        {
            msg = $"Event {randomEvent.Method.Name} failed to trigger.";
        }

        callback(success, msg);
    }
}