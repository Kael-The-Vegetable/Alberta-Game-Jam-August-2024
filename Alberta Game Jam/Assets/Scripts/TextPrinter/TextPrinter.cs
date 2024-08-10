using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextPrinter : MonoBehaviour
{
    public float charactersPerSecond;

    public TextMeshProUGUI label;
    [TextArea]
    string text;

    public UnityEvent onStartPrint;
    public UnityEvent onFinishPrint;
    private void Awake()
    {
        // cache the labels text.
        text = label.text;
        label.text = string.Empty;

        // TODO: set charactersPerSecond the variable set in the settings object
    }

    public void BeginPrint()
    {
        onStartPrint?.Invoke();
        StartCoroutine(ShowLetters(1 / charactersPerSecond));
    }

    private IEnumerator ShowLetters(float delay)
    {
        for (int i = 0; i < text.Length; i++)
        {
            label.text += text[i];
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(10 * delay);
        onFinishPrint?.Invoke();
    }
}
