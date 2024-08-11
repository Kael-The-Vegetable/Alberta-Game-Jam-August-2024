using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuController
{
    [Space]
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;
    internal override void Awake()
    {
        base.Awake();

        _buttons[0].onClick.AddListener(() => GameManager.ChangeScene(2));
        _buttons[1].onClick.AddListener(() => Outro(2, settingsCanvas, new Vector2(-20, 0))); // settings button
        _buttons[2].onClick.AddListener(() => Outro(2, creditsCanvas, new Vector2(-20, 0))); // settings button
        _buttons[3].onClick.AddListener(GameManager.ExitGame);
    }
}
