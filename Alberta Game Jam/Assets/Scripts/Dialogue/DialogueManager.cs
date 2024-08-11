using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public float charactersPerSecond = 50;

    public string dialogue;
    public TextMeshProUGUI dialogueLabel;

    public UnityEvent onStartPrint;
    public UnityEvent onFinishPrint;

    private void Awake()
    {
        SceneManager.sceneLoaded += FindDialogueBox;
    }

    private void FindDialogueBox(Scene arg0, LoadSceneMode arg1)
    {
        if (dialogueLabel == null && !GameObject.Find("DialogueBox").TryGetComponent(out dialogueLabel))
        {
            Debug.LogWarning("No gameObject called \"DialogueBox\" was found.");
        }
    }

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
            dialogueLabel.text += dialogue[i];
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(100 * delay);
        onFinishPrint?.Invoke();
        dialogueLabel.text = string.Empty;
    }
}
