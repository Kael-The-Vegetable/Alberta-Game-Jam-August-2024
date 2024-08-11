using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventTrigger : MonoBehaviour
{
    public Section section;

    [field: SerializeField]
    public string EventName { get; set; }

    [field: SerializeField, TextArea]
    public string EventDescription { get; set; }

    [HideInInspector]
    public bool isRunning;

    public virtual void StartEvent()
    {
        isRunning = true;
        section.runningEvent = this;
    }
    public virtual void UpdateEvent() { }
    public virtual void EndEvent() 
    {
        isRunning = false;
        section.runningEvent = null;
    }

    private void OnValidate()
    {
        if (section != null)
        {
            section.OnValidate();
        }
    }
}
