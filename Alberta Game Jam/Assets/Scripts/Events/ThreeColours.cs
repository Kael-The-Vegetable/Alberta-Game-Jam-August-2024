using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeColours : MonoBehaviour, IGameEvent
{
    public enum Colour
    {
        Red = 0, Yellow = 1, Blue = 2
    }

    [field: SerializeField] public GameEventTrigger Trigger { get; set; }

    public Colour colour;

    public Image indicator;

    [Min(0)] public float delayTime;


    private Colour _selectedColour;
    
    public void SelectColour(int colourInt)
    {
        if ( (int)colour == colourInt)
        {
            _selectedColour = colour;
        }
        else
        {
            // INCREASE INTENSITY
        }
    }
    

    public void OnEventEnd()
    {
        indicator.color = Color.gray;
        if (_selectedColour != colour)
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
        switch (colour)
        {
            case Colour.Red:
                indicator.color = Color.red;
                break;
            case Colour.Yellow:
                indicator.color = Color.yellow;
                break;
            case Colour.Blue:
                indicator.color = Color.blue;
                break;
        }
        StartCoroutine(Wait(delayTime));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Trigger.EndEvent();
    }

    public void OnEventUpdate() { }
}
