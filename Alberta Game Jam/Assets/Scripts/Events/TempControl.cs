using System.Collections;
using UnityEngine;

public class TempControl : GameEventTrigger
{
    public string startMessage;
    [Min(0)] public float eventTime;


    public int temperature;
    [Range(50, 100)] public int upperTolerance;
    [Range(0, 50)] public int lowerTolerance;

    public override void StartEvent()
    {
        base.StartEvent();
        temperature = 50;
        Singleton.Global.DialogueManager.BeginDialogue(startMessage);
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();

        int chance = Singleton.Global.Random.Next(2);

        temperature += chance == 0
            ? -5
            : 5;

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
    }

    private IEnumerator EventTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        EndEvent();
    }
}
