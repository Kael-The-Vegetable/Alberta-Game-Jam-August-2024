using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _currentBuildID;

    private int _intensity;
    public int Intensity 
    {
        get => _intensity; 
        set
        {
            
            if (value >= 100)
            {
                ChangeScene(3);
            }
            _intensity = value;
        }
    }
    private void Awake()
    {
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += SceneChanged;
    }

    private void SceneChanged(Scene old, Scene next)
    {
        _currentBuildID = next.buildIndex;
        switch (_currentBuildID)
        {
            case 0:// intro
                break;
            case 1:// main menu
                Intensity = 0;
                break;
            case 2:// main game
                break;
            case 3:// game over
                Intensity = 0;
                break;
        }
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