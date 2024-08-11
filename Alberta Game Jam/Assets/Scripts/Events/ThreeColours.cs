using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeColours : MonoBehaviour, IGameEvent
{
    public enum Colour
    {
        Red = 0, Yellow = 1, Blue = 2
    }

    [field: SerializeField] public GameEventTrigger Trigger { get; set; }

    public Colour colour;

    [Min(0)] public float delayTime;


    private Colour _selectedColour;
    public Colour selectedColour
    {
        get => _selectedColour;
        set
        {
            if (value != colour)
            {
                // INCREASE INTENSITY
            }
            else
            {
                _selectedColour = value;
            }
        }
    }
    

    public void OnEventEnd()
    {
        if (_selectedColour == null || _selectedColour != colour)
        {
            // INCREASE INTENSITY
        }
        else
        {
            // DECREASE INTENSITY
        }
    }

    public void OnEventStart()
    {
        colour = (Colour)Singleton.Global.Random.Next(3);
        StartCoroutine(Wait(delayTime));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Trigger.EndEvent();
    }

    public void OnEventUpdate() { }
}
