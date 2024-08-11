using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClonkSound : MonoBehaviour
{
    private void Awake()
    {           
        GetComponent<Toggle>().onValueChanged
            .AddListener( (Boolean) =>
                Singleton.Global.FModManager.PlayOneShot(
                    Singleton.Global.FModEvents.buttonPress, transform.position));
    }
}
