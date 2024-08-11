using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Global { get; private set; }

    public GameManager GameManager { get; private set; }
    public FModManager FModManager { get; private set; }
    public FModEvents FModEvents { get; private set; }
    public EventController EventController { get; set; }
    public DialogueManager DialogueManager { get; set; }
    public System.Random Random { get; private set; } = new System.Random();

    private void Awake()
    {
        if (Global != null)
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
        FModEvents = GetComponentInChildren<FModEvents>();
        DialogueManager = GetComponentInChildren<DialogueManager>();
    }
}
