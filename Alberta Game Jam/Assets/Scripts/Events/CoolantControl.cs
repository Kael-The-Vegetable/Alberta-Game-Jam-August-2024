using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolantControl : GameEventTrigger
{
    public string startMessage;
    [Min(0)] public float eventTime;
    public bool raiseTemp = true;
    public ValueDisplay temperatureDisplay;

    public float temperature;
    public int upperTolerance;
    public int lowerTolerance;

    public Image AlertImage;

    public override void StartEvent()
    {
        base.StartEvent();
        temperature = 300;
        Singleton.Global.DialogueManager.BeginDialogue(startMessage);
        StartCoroutine(EventTimer(eventTime));
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();

        int chance = Singleton.Global.Random.Next(2);

        temperature += Time.deltaTime * (chance == 0
            ? raiseTemp
                ? 5
                : 10
            : raiseTemp
                ? -10
                : -5);

        float intensityDelta;
        if (temperature.ValueBetween(lowerTolerance, upperTolerance))
        {
            intensityDelta = 0;
        }
        else
        {
            intensityDelta = 1f * Time.deltaTime;
        }

        Singleton.Global.GameManager.Intensity += intensityDelta;
        if (temperatureDisplay != null)
        {
            temperatureDisplay.value = temperature;
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
            Singleton.Global.GameManager.Intensity -= 10;
        }
        else
        {
            Singleton.Global.GameManager.Intensity += 30;
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
