using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class FModManager : MonoBehaviour
{
    private List<EventInstance> currentEvents = new List<EventInstance>();

    private void Awake()
    {
        SceneManager.activeSceneChanged += SceneChanged;
    }

    public void PlayOneShot(EventReference sound, Vector3 pos)
        => RuntimeManager.PlayOneShot(sound, pos);

    public EventInstance CreateInstance(EventReference sound)
    {
        EventInstance instance = RuntimeManager.CreateInstance(sound);
        currentEvents.Add(instance);
        return instance;
    }

    private void SceneChanged(Scene old, Scene next) => CleanUpSounds();
    

    private void CleanUpSounds()
    {
        for (int i = 0; i < currentEvents.Count; i++)
        {
            currentEvents[i].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEvents[i].release();
        }
    }
}
