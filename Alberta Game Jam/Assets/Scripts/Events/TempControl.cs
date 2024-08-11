using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempControl : GameEventTrigger
{
    public string startMessage;

    public override void StartEvent()
    {
        base.StartEvent();
        Singleton.Global.DialogueManager.BeginDialogue(startMessage);
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();

    }
}
