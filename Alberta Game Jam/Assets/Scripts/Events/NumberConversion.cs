using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ThreeColours;

public class NumberConversion : GameEventTrigger
{
    private string[] _messages =
    {
        "Send 135 Watts to the Thrusters by pressing the numbers!",
        "Power is out, Send 2495 Watts out by pressing the numbers!",
        "Power is out, Send 385 Watts out by pressing the numbers!"
    };
    private int[] _messageConversions =
    {
        135,
        2495,
        385
    };
    private int _chosenInteger;
    private int _integerGiven = 0;
    public GameObject[] buttonObjects;
    private Button[] _buttons;

    public float delayTime;

    private void Awake()
    {
        _buttons = new Button[buttonObjects.Length];
        for (int i = 0; i < buttonObjects.Length; i++)
        {
            _buttons[i] = buttonObjects[i].GetComponent<Button>();
        }
        _buttons[0].onClick.AddListener(() => AddOne());
        _buttons[1].onClick.AddListener(() => AddTwo());
        _buttons[2].onClick.AddListener(() => AddThree());
        _buttons[3].onClick.AddListener(() => AddFour());
        _buttons[4].onClick.AddListener(() => AddFive());
        _buttons[5].onClick.AddListener(() => AddSix());
        _buttons[6].onClick.AddListener(() => AddSeven());
        _buttons[7].onClick.AddListener(() => AddEight());
        _buttons[8].onClick.AddListener(() => AddNine());
        _buttons[9].onClick.AddListener(() => AddZero());
    }


    private void AddOne() => AddValue(1);
    private void AddTwo() => AddValue(2);
    private void AddThree() => AddValue(3);
    private void AddFour() => AddValue(4);
    private void AddFive() => AddValue(5);
    private void AddSix() => AddValue(6);
    private void AddSeven() => AddValue(7);
    private void AddEight() => AddValue(8);
    private void AddNine() => AddValue(9);
    private void AddZero() => AddValue(0);
    public void AddValue(int value)
    {
        if (_integerGiven == 0)
        { _integerGiven = value; }
        else
        { _integerGiven = int.Parse(_integerGiven.ToString() + value.ToString()); }
    }

    public override void EndEvent()
    {
        base.EndEvent();

        if (_integerGiven == _chosenInteger)
        {
            Singleton.Global.GameManager.Intensity -= 5;
        }
        else
        {
            Singleton.Global.GameManager.Intensity += 15;
        }
    }

    public override void UpdateEvent()
    {
        
        base.UpdateEvent();
    }

    public override void StartEvent()
    {
        base.StartEvent();

        _integerGiven = 0;
        int chosenMessage = Singleton.Global.Random.Next(_messages.Length);
        Singleton.Global.DialogueManager.BeginDialogue(_messages[chosenMessage]);

        _chosenInteger = _messageConversions[chosenMessage];

        StartCoroutine(Wait(delayTime));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        EndEvent();
    }
}
