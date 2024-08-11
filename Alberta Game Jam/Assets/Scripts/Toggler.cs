using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Toggler : MonoBehaviour
{
    public Toggle toggle;
    public Image background;

    private void Update()
    {
        toggle = toggle != null ? toggle : GetComponent<Toggle>();
        background = background != null ? background : GetComponentInChildren<Image>();

        if (toggle != null)
        {
            background.color = toggle.isOn
                ? new Color(background.color.r, background.color.g, background.color.b, 0)
                : new Color(background.color.r, background.color.g, background.color.b, 1);
        }
    }
}
