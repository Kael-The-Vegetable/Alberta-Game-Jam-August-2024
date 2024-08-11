using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeColours : MonoBehaviour, IGameEvent
{
    public enum Colour
    {
        Red = 0, Yellow = 1, Blue = 2
    }

    [field:SerializeField]
    public GameEventTrigger Trigger { get; set; }

    public Colour colour;

    [Min(0)] public float delayTime;
    public bool clickable;

    public void OnEventEnd()
    {
        throw new System.NotImplementedException();
    }

    public void OnEventStart()
    {
        colour = (Colour)Singleton.Global.Random.Next(3);
        StartCoroutine(Wait(delayTime));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

    }

    public void OnEventUpdate()
    {
        throw new System.NotImplementedException();
    }
}
