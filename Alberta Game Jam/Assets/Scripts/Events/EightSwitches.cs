using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ThreeColours;

public class EightSwitches : GameEventTrigger
{
    public enum OnOff
    {
        None = 0, On = 1, Off = 2
    }
    public OnOff state;

    private string[] _messages =
    {
        "DO NOTHING TO THE SWITCHES!",  // 0    0
        "Flip one switch on!",          // 1    1
        "Flip two switches on!",        // 2    2
        "Flip three switches on!",      // 3    3
        "Flip four switches on!",       // 4    4
        "Flip five switches on!",       // 5    5
        "Flip six switches on!",        // 6    6
        "Flip seven switches on!",      // 7    7
        "Flip all switches on!",        // 8    0
        "Flip one switch off!",         // 9    1
        "Flip two switches off!",       // 10   2
        "Flip three switches off!",     // 11   3
        "Flip four switches off!",      // 12   4
        "Flip five switches off!",      // 13   5
        "Flip six switches off!",       // 14   6
        "Flip seven switches off!",     // 15   7
        "Flip all switches off!"        // 16   0
    };
    [SerializeField] private string _chosenMessage;
    [SerializeField] private int _numToFlip;

    public GameObject[] switches;
    private Toggle[] _switchToggles;

    private void ResetSwitches(bool value)
    {
        for (int i = 0; i < switches.Length; i++)
        {
            _switchToggles[i].isOn = value;
        }
    }

    public override void EndEvent()
    {
        base.EndEvent();
    }

    public override void UpdateEvent()
    {
        base.UpdateEvent();
    }

    public override void StartEvent()
    {
        base.StartEvent();

        int chosenMessage = Singleton.Global.Random.Next(_messages.Length);
        _chosenMessage = _messages[chosenMessage];
        Singleton.Global.DialogueManager.BeginDialogue(_chosenMessage);

        if (chosenMessage != 0)// DON'T DO NOTHING
        {
            if (chosenMessage > 8) // TURN SIWTCHES OFF
            {
                ResetSwitches(true);
                state = OnOff.Off;
                _numToFlip = chosenMessage - 8;
            }
            else
            {
                ResetSwitches(false);
                state = OnOff.On;
                _numToFlip = chosenMessage;
            }
        }
        else // DO NOTHING
        {
            state = OnOff.None;
        }
    }
}
