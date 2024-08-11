using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClonkSound : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent(out Toggle toggler))
        {
            toggler.onValueChanged
            .AddListener((Boolean) =>
                Singleton.Global.FModManager.PlayOneShot(
                    Singleton.Global.FModEvents.buttonPress, transform.position));
        }
        else if (TryGetComponent(out Button buttoner))
        {
            buttoner.onClick.AddListener(() =>
                Singleton.Global.FModManager.PlayOneShot(
                    Singleton.Global.FModEvents.buttonPress, transform.position));
        }
    }
}
