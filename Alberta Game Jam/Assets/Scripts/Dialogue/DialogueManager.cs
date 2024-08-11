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
        if (dialogueLabel == null)
        {
            var go = GameObject.Find("DialogueBox");
            if (go != null && !go.TryGetComponent(out dialogueLabel))
            {
                Debug.LogWarning("No gameObject called \"DialogueBox\" was found.");
            }
        }
    }

    public void BeginDialogue(string text)
    {
        dialogueLabel.text = string.Empty;
        dialogue = text;
        Singleton.Global.FModManager.PlayOneShot(Singleton.Global.FModEvents.cigarettes, transform.position);
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
