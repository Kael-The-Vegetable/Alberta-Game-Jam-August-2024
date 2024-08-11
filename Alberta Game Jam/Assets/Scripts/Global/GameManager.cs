using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int intensity = 0;
    public string dialogue;
    private ScoreDisplay intensityDisplay;
    private DialogueDisplay dialogueDisplay;
    private void Awake()
    {
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        intensityDisplay = GameObject.Find("IntensityCounter").GetComponent<ScoreDisplay>();
        dialogueDisplay = GameObject.Find("DialogueBox").GetComponent<DialogueDisplay>();
    }

    void Update()
    {
        intensityDisplay.IntensityCount(intensity++);
        if(intensity >= 1000)
        {
            dialogue = "WARNING: SYSTEM OVERRIDE!!!";
        }
        dialogueDisplay.DialoguePrompt(dialogue);
    }


    /// <summary>
    /// Use this method to change the scene as per the build order.
    /// </summary>
    /// <param name="index"></param>
    public static void ChangeScene(int index) => SceneManager.LoadScene(index);

    /// <summary>
    /// Use this method to immediatly exit the program.
    /// </summary>
    public static void ExitGame() => Application.Quit();

    /// <summary>
    /// Use this method to set a variable followed by waiting, then setting the variable later to a different value. <br />
    /// Use ( result => [ your variable name here ] = result ) in place for the variable area.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="variable"></param>
    /// <param name="time"></param>
    /// <param name="initialValue"></param>
    /// <param name="finalValue"></param>
    /// <returns></returns>
    public static IEnumerator DelayedVarChange<T>(Action<T> variable, float time, T initialValue, T finalValue)
    {
        variable(initialValue);
        yield return new WaitForSeconds(time);
        variable(finalValue);
    }


}