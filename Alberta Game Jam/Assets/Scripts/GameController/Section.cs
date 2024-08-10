using UnityEngine;
using UnityEngine.Events;

public class Section : MonoBehaviour
{
    [field: SerializeField]
    public EventController EventController { get; private set; }
    
    public GameEventTrigger[] Events { get; set; }

    [HideInInspector]
    public GameEventTrigger runningEvent;
    public bool IsEventRunning => runningEvent != null;

    public void ChooseRandomEvent(EventController.Callback callback)
    {
        string msg;
        bool success = false;
        if (IsEventRunning)
        {
            msg = $"Event \"{runningEvent.EventName}\"";
            callback(success, msg);
        }
        else
        {
            var randomEvent = Events.SelectRandomElement();
            try
            {
                runningEvent = randomEvent;
                randomEvent.StartEvent();
                msg = $"Event {randomEvent.EventName} has started";
                success = true;
            }
            catch (System.Exception)
            {
                msg = $"Event {randomEvent.EventName} failed to start.";
            }

            callback(success, msg);
        }
    }

    private void Awake()
    {
        Events = GetComponentsInChildren<GameEventTrigger>();
    }

    public void OnValidate()
    {
        Events = GetComponentsInChildren<GameEventTrigger>();
        for (int i = 0; i < Events.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(Events[i].EventName))
            {
                throw new System.Exception($"Every event in a {typeof(Section)} must have a name.");
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