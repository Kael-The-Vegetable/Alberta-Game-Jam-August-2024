using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FModEvents : MonoBehaviour
{
    [field: Header("SFX Events")]
    [field: SerializeField] public EventReference buttonPress { get; private set; }
    [field: SerializeField] public EventReference leverPull { get; private set; }
    [field: SerializeField] public EventReference uiClick { get; private set; }

    [field: Header("Music Events")]
    [field: SerializeField] public EventReference menuMusic { get; private set; }
    [field: SerializeField] public EventReference gameMusic { get; private set; }
    [field: SerializeField] public EventReference overMusic { get; private set; }

    [field: Header("Misc Events")]
    [field: SerializeField] public EventReference cigarettes { get; private set; }

    //public EventInstance music;
    //public void Start()
    //{
    //    music = Singleton.Global.FModManager.CreateInstance(menuMusic);
    //    music.start();
    //}
}
