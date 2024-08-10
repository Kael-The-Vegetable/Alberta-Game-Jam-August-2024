using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingEvent : MonoBehaviour, IGameEvent
{
    [field: SerializeField]
    public GameEventTrigger Trigger { get; set; }

    public void OnEventEnd()
    {
        Debug.Log("Doing nothing on end");
    }

    public void OnEventStart()
    {
        Debug.Log("Doing nothing on start");
    }


    public void OnEventUpdate()
    {
        Debug.Log("Doing nothing on update");
    }
}
