using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PULLTHELEVERSOUND : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent(out Toggle toggler))
        {
            toggler.onValueChanged
            .AddListener((PULLTHELEVER) =>
                Singleton.Global.FModManager.PlayOneShot(
                    Singleton.Global.FModEvents.leverPull, transform.position));
        }
    }
}
