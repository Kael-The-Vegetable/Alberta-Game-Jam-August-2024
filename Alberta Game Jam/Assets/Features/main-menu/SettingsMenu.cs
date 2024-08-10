using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MenuController
{
    [Space]
    public GameObject mainCanvas;
    internal override void Awake()
    {
        base.Awake();

        _buttons[2].onClick.AddListener(() => Outro(2, mainCanvas, new Vector2(-20, 0))); // main canvas button
    }
}
