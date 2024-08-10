using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Global { get; private set; }

    public GameManager GameManager { get; private set; }
    public FModManager FModManager { get; private set; }

    private void Awake()
    {
        if (Global == null && Global != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Global = this;
            DontDestroyOnLoad(this.gameObject);
        }
        GameManager = GetComponentInChildren<GameManager>();
        FModManager = GetComponentInChildren<FModManager>();
    }
}
