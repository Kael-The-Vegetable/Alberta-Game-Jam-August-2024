using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _currentBuildID;

    private float _intensity;
    public float Intensity 
    {
        get => _intensity; 
        set
        {
            if (value < 25)
            {
                Singleton.Global.FModManager.SetMusicIntensity("music_intensity", 0);
            }
            else if  (value  < 50)
            {
                Singleton.Global.FModManager.SetMusicIntensity("music_intensity", 1);
            }
            else if (value < 75)
            {
                Singleton.Global.FModManager.SetMusicIntensity("music_intensity", 2);
            }
            else if (value < 100)
            {
                Singleton.Global.FModManager.SetMusicIntensity("music_intensity", 3);
            }
            else
            {
                ChangeScene(3);
            }

            if (value < 0) 
            { value = 0; }
            _intensity = value;
        }
    }

    private void Awake()
    {
        // This is unnecessary
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        //if(objs.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}
        //DontDestroyOnLoad(gameObject);

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