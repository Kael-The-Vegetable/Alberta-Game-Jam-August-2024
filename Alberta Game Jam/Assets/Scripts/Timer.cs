using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private ValueDisplay display;
    private void Awake()
    {
        display = GetComponent<ValueDisplay>();

        Singleton.Global.GameManager.runTimer = true;
    }

    private void Update()
    {
        if (display != null)
        {
            display.value = (float)System.Math.Round(Singleton.Global.GameManager.timeElapsed, 2);
        }
    }
}
