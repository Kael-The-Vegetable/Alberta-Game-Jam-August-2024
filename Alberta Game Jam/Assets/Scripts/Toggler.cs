using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggler : MonoBehaviour
{
    public Image background;
    public Sprite on;
    public Sprite off;

    public void Switch(bool val) 
        => background.sprite = val ? on : off;
}
