using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntensityVisualizer : MonoBehaviour
{
    public Toggle warning;
    public Slider intensitySlider;

    private void Update()
    {
        intensitySlider.value = Singleton.Global.GameManager.Intensity;
        if (intensitySlider.value > 80 )
        {
            warning.isOn = true;
        }
        else
        {
            warning.isOn = false;
        }
    }
}
