using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MenuController
{
    internal override void Awake()
    {
        base.Awake();

        _buttons[0].onClick.AddListener(() => GameManager.ChangeScene(2));// play again
        _buttons[1].onClick.AddListener(() => GameManager.ChangeScene(1)); // settings button
        _buttons[2].onClick.AddListener(GameManager.ExitGame);
    }
}
