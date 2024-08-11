using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    public TMP_Text dialogueText;
    public void DialoguePrompt(string dialogue)
    {
        dialogueText.text = Singleton.Global.GameManager.dialogue;
    }
}
