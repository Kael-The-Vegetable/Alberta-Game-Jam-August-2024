using UnityEngine;

public class Intesimeter : MonoBehaviour
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
            display.value = Singleton.Global.GameManager.Intensity;
        }
    }
}
