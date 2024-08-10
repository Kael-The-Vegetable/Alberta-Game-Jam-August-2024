using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [Min(0)] public float timeBetweenEvents;
    public bool eventWasTriggered;


}

public interface IPanelSection
{
    public delegate void Callback();
    public delegate void Event(Callback callback);

    public EventController EventController { get; }
    public Event[] Events { get; }

    public void ChooseRandomEvent(Callback callback)
    {
        Events.SelectRandomElement()(callback);
    }
}
