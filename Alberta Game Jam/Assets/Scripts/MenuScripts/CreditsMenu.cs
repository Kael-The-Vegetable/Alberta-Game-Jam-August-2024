using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MenuController
{
    [Space]
    public GameObject mainCanvas;
    internal override void Awake()
    {
        base.Awake();

        _buttons[0].onClick.AddListener(() => Outro(2, mainCanvas, new Vector2(0, -12))); // main canvas button
    }
}
