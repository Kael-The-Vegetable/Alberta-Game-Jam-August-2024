using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TempControl : GameEventTrigger
{
    public string startMessage;
    [Min(0)] public float eventTime;
    public bool raiseTemp = true;
    public ValueDisplay temperatureDisplay;

    [Range(0, 100)] public int temperature;
    [Range(50, 100)] public int upperTolerance;
    [Range(0, 50)] public int lowerTolerance;

    public Image AlertImage;

    public override void StartEvent()
    {
        base.StartEvent();
        temperature = 50;
        Singleton.Global.DialogueManager.BeginDialogue(startMessage);
        StartCoroutine(EventTimer(eventTime));
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();

        int chance = Singleton.Global.Random.Next(2);

        temperature += chance == 0
            ? raiseTemp 
                ? -1
                : -5
            : raiseTemp
                ? 5
                : 1;

        int intesityDelta;
        if (temperature.ValueBetween(lowerTolerance, upperTolerance))
        {
            intesityDelta = 0;
        }
        else
        {
            intesityDelta = 1;
        }

        Singleton.Global.GameManager.Intensity += intesityDelta;
        if (temperatureDisplay != null)
        {
            temperatureDisplay.value = temperature * 10;
        }

        if (AlertImage != null)
        {
            AlertImage.color = temperature.ValueBetween(lowerTolerance, upperTolerance)
                ? Color.green : Color.red;
        }
    }

    public override void EndEvent()
    {
        base.EndEvent();
        if (temperature.ValueBetween(lowerTolerance, upperTolerance))
        {
            Singleton.Global.GameManager.Intensity -= 5;
        }
        else
        {
            Singleton.Global.GameManager.Intensity += 15;
        }

        if (AlertImage != null)
        {
            AlertImage.color = Color.white;
        }
    }

    public void ToggleTemperatureDirection()
    {
        raiseTemp = !raiseTemp;
    }

    private IEnumerator EventTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        EndEvent();
    }
}
