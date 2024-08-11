using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private ValueDisplay display;
    private void Awake()
    {
        display = GetComponent<ValueDisplay>();
    }

    private void Update()
    {
        if (display != null)
        {
            display.value = Singleton.Global.GameManager.timeElapsed;
        }
    }
}
