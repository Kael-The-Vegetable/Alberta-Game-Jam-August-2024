using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public float timePerSwitch = 2;
    private Toggle[] _switchToggles;
    private bool[] _states;

    private void Awake()
    {
        _switchToggles = new Toggle[switches.Length];
        _states = new bool[switches.Length];
        for (int i = 0; i < switches.Length; i++)
        { _switchToggles[i] = switches[i].GetComponent<Toggle>(); }
    }

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

        switch (state)
        {
            case OnOff.None: // NONE
                bool flipped = false;
                for (int i = 0; i < _switchToggles.Length; i++)
                {
                    if (_states[i] != _switchToggles[i].isOn)
                    {
                        flipped = true;
                        Singleton.Global.GameManager.Intensity += 5;
                    }
                }
                if (!flipped)
                {
                    Singleton.Global.GameManager.Intensity -= 5;
                }
                break;
            case OnOff.On: // ON
                int numToFlip = _numToFlip;
                for (int i = 0; i < _switchToggles.Length; i++)
                {
                    if (_switchToggles[i].isOn)
                    {
                        numToFlip--;
                    }
                }
                if (numToFlip != 0)
                {
                    Singleton.Global.GameManager.Intensity += 15;
                }
                else
                {
                    Singleton.Global.GameManager.Intensity -= 5;
                }
                break;
            case OnOff.Off: // OFF
                numToFlip = _numToFlip;
                for (int i = 0; i < _switchToggles.Length; i++)
                {
                    if (!_switchToggles[i].isOn)
                    {
                        numToFlip--;
                    }
                }
                if (numToFlip != 0)
                {
                    Singleton.Global.GameManager.Intensity += 15;
                }
                else
                {
                    Singleton.Global.GameManager.Intensity -= 5;
                }
                break;
        }
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
            _numToFlip = 8;
            for (int i = 0; i < _switchToggles.Length; i++)
            {
                int swap = Singleton.Global.Random.Next(2);
                if (swap == 0)
                {
                    _switchToggles[i].isOn = !_switchToggles[i].isOn;
                }
                _states[i] = _switchToggles[i].isOn;
            }
        }
        StartCoroutine(Wait(timePerSwitch * _numToFlip));
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EndEvent();
    }
}
