using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberConversion : GameEventTrigger
{
    private string[] _messages =
    {
        "Send 135 Watts to the Thrusters by pressing the numbers!",
        "Power is out, Send 2495 Watts out by pressing the numbers!",
        "Power is out, Send 385 Watts out by pressing the numbers!",
        "Send 9502 Watts to the Command Deck by pressing the numbers!",
        "THE SPACE ORANGUTANGS ESCAPED THEIR ENCLOSURE! CLOSE THE BULKHEADS, SEND 7820 WATTS IMMEDIATELYY!",
        "BEEP-BOOP! SEND 872 Watts to Robot Bay 892 for un-nefarious purposes’ Human, BEEP-BOP!",
        "One of the Space Elevators needs some help getting up, send 901 Watts to help it up.",
        "The CEO of Space is putting an order in that we need to have all stations at 4817 Watts all over. Better get to it.",
        "We’re gonna need 842… er scratch that, just send 824 Watts to the lab bay.",
        "Malfunction on bay 62! Reduce the claw power by 9102 Watts! Oh no, Terry watch out for the claw!",
        "The Zorblaxions are complaining that the Glorp dispensers aren’t working right. Increase station power by 109 Watts to help em out.",
        "Scotty needs to be beamed up, juice the teleporter up by 681 Watts.",
        "The doc in the laser surgery lab says that there’s too much power in the laser. Try reducing it by 1283 Watts.",
        "What’s with these Watts, do you think about what the problems with too many Watts might do to your thoughts? Reduce station Wattage by 12 Watts.",
        "The space Orangutang enclosure is getting too cold for them. Increase the heat by 459 Watts."
    };
    private int[] _messageConversions =
    {
        135,
        2495,
        385,
        9502,
        7820,
        872,
        901,
        4817,
        824,
        9102,
        109,
        681,
        1283,
        12,
        459
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
