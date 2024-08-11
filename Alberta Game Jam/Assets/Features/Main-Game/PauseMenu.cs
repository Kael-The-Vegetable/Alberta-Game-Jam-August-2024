using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MenuController
{
    public GameObject settingsCanvas;
    public GameObject mainPause;
    public GameObject GameBoard;

    internal override void OnEnable()
    {
        base.OnEnable();
        GameBoard.SetActive(false);
    }

    internal override void OnDisable()
    {
        base.OnDisable();
        GameBoard.SetActive(true);
    }

    internal override void Awake()
    {
        base.Awake();

        _buttons[0].onClick.AddListener(() => Outro(2, mainPause, new Vector2(0, -12))); // resume button
        _buttons[1].onClick.AddListener(() => Outro(2, settingsCanvas, new Vector2(0, -12))); // settings button
        _buttons[2].onClick.AddListener(() => GameManager.ChangeScene(1));
    }
}
