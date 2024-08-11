using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MenuController
{
    [Space]
    public GameObject mainCanvas;
    [Space]
    public GameObject[] sliderObjs;
    private Slider[] _sliders;
    internal override void Awake()
    {
        base.Awake();

        _sliders = new Slider[sliderObjs.Length];
        for (int i = 0; i < sliderObjs.Length; i++)
        { 
            _sliders[i] = sliderObjs[i].GetComponent<Slider>();
            _sliders[i].onValueChanged.AddListener(delegate { CheckVolumes(); });
        }

        _buttons[0].onClick.AddListener(() => Outro(2, mainCanvas, new Vector2(-20, 0))); // main canvas button
    }
    internal override void OnEnable()
    {
        base.OnEnable();

        _sliders[0].value = Singleton.Global.FModManager.MasterVolume;
        _sliders[1].value = Singleton.Global.FModManager.SFXVolume;
        _sliders[2].value = Singleton.Global.FModManager.DialogueVolume;
        _sliders[3].value = Singleton.Global.FModManager.MusicVolume;
    }
    private void CheckVolumes()
    {
        Singleton.Global.FModManager.MasterVolume   = _sliders[0].value;
        Singleton.Global.FModManager.SFXVolume      = _sliders[1].value;
        Singleton.Global.FModManager.DialogueVolume = _sliders[2].value;
        Singleton.Global.FModManager.MusicVolume    = _sliders[3].value;
    }
}
