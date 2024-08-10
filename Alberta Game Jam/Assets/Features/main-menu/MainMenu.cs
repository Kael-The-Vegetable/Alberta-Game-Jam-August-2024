using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuController
{
    [Space]
    public GameObject settingsCanvas;
    internal override void Awake()
    {
        base.Awake();

        _buttons[1].onClick.AddListener(() => Outro(2, settingsCanvas)); // settings button
    }
}
