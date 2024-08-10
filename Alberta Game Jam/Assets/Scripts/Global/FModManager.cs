using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class FModManager : MonoBehaviour
{
    [field: Header("Volume")]
    [field: Range(0, 1)] public float MasterVolume { get; set; }
    private Bus _masterBus;

    [field: Range(0, 1)] public float SFXVolume { get; set; }
    private Bus _sfxBus;

    [field: Range(0, 1)] public float MusicVolume { get; set; }
    private Bus _musicBus;

    [field: Range(0, 1)] public float dialogueVolume { get; set; }
    private Bus _dialogueBus;

    private List<EventInstance> currentEvents;
    private List<StudioEventEmitter> eventEmitters;

    private void Awake()
    {
        currentEvents = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        SceneManager.activeSceneChanged += SceneChanged;

        //***** HOOK UP BUSSES *****
        _masterBus = RuntimeManager.GetBus("bus:/");
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

    private void SceneChanged(Scene old, Scene next) => CleanUpSounds();
    

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
