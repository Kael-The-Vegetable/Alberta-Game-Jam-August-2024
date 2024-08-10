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

        _buttons[2].onClick.AddListener(() => Outro(2, settingsCanvas, new Vector2(20,0) )); // settings button
    }
}
