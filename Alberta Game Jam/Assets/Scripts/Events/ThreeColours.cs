using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeColours : GameEventTrigger
{
    public enum Colour
    {
        Red = 0, Yellow = 1, Blue = 2
    }

    public Colour colour;

    public Image indicator;

    [Min(0)] public float delayTime;

    public string startingMessage;

    private Colour _selectedColour;

    public void SelectColour(int colourInt)
    {
        if ((int)colour == colourInt)
        {
            _selectedColour = colour;
        }
        else
        {
            Singleton.Global.GameManager.Intensity += 15;
        }
    }


    public override void EndEvent()
    {
        base.EndEvent();

        indicator.color = Color.gray;
        if (_selectedColour != colour)
        {
            Singleton.Global.GameManager.Intensity += 15;
        }
        else
        {
            Singleton.Global.GameManager.Intensity -= 5;
        }
    }

    public override void UpdateEvent()
    {
        // do nothing
        base.UpdateEvent();
    }

    public override void StartEvent()
    {
        base.StartEvent();

        Singleton.Global.DialogueManager.BeginDialogue(startingMessage);

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
        EndEvent();
    }
}
