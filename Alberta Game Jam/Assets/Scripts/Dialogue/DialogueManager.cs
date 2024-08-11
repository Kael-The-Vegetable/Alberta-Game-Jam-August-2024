using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public float charactersPerSecond = 1;

    public string dialogue;
    public TextMeshProUGUI dialogueLabel;

    public UnityEvent onStartPrint;
    public UnityEvent onFinishPrint;

    public void BeginDialogue(string text)
    {
        dialogueLabel.text = string.Empty;
        dialogue = text;
        StartCoroutine(ShowLetters(1 / charactersPerSecond));
    }

    private IEnumerator ShowLetters(float delay)
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            label.text += text[i];
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(10 * delay);
        onFinishPrint?.Invoke();
    }
}
