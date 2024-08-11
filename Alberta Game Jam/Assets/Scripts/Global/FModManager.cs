using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class FModManager : MonoBehaviour
{
    
    public float MasterVolume
    {
        get
        {
            RuntimeManager.StudioSystem.getParameterByName(_masterParameter, out float val);
            return val;
        }
        set => RuntimeManager.StudioSystem.setParameterByName(_masterParameter, value);
    }
    private string _masterParameter = "master_bus_vol";

    public float SFXVolume
    {
        get
        {
            RuntimeManager.StudioSystem.getParameterByName(_sfxParameter, out float val);
            return val;
        }
        set => RuntimeManager.StudioSystem.setParameterByName(_sfxParameter, value);
    }
    private string _sfxParameter = "sfx_bus_vol";

    public float MusicVolume
    {
        get
        {
            RuntimeManager.StudioSystem.getParameterByName(_musicParameter, out float val);
            return val;
        }
        set => RuntimeManager.StudioSystem.setParameterByName(_musicParameter, value);
    }
    private string _musicParameter = "music_bus_vol";

    public float DialogueVolume
    {
        get
        {
            RuntimeManager.StudioSystem.getParameterByName(_dialogueParameter, out float val);
            return val;
        }
        set => RuntimeManager.StudioSystem.setParameterByName(_dialogueParameter, value);
    }
    private string _dialogueParameter = "dialogue_bus_vol";

    private List<EventInstance> currentEvents;
    private List<StudioEventEmitter> eventEmitters;

    private EventInstance _music;

    private void Awake()
    {
        currentEvents = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

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

    public StudioEventEmitter CreateEmitter(EventReference sound, GameObject emitterObj)
    {
        if (emitterObj.TryGetComponent(out StudioEventEmitter emitter))
        {
            emitter.EventReference = sound;
            eventEmitters.Add(emitter);
            return emitter;
        }
        else
        {
            Debug.LogError("Given Object doesn't have a StudioEventEmitter.");
            return null;
        }
    }

    private void SceneChanged(Scene old, Scene next)
    {
        switch (next.buildIndex)
        {
            case 0:// intro
                break;
            case 1:// main menu
                break;
            case 2:// game
                InitializeMusic(Singleton.Global.FModEvents.gameMusic);
                break;
            default:// game over
                break;
        }
        CleanUpSounds();
    }

    private void InitializeMusic(EventReference sound)
    {
        _music = CreateInstance(sound);
        _music.start();
    }

    private void CleanUpSounds()
    {
        for (int i = 0; i < currentEvents.Count; i++)
        {
            currentEvents[i].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEvents[i].release();
        }

        for (int i = 0; i < eventEmitters.Count; i++)
        { eventEmitters[i].Stop(); }
    }
}
