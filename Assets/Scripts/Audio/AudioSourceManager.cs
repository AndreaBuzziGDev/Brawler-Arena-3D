
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//TODO: RENAME AS SOMETHING ELSE - THIS IS DEDICATED TO SHORT AUDIO FX SPECIFICALLY
public class AudioSourceManager : MonoBehaviour
{

    //DATA
    [SerializeField] SoundFXEventArgs.EType audioType = SoundFXEventArgs.EType.UNBOUND;

    List<AudioSource> sources = new();


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        sources = FindObjectsOfType<AudioSource>().ToList();
        Debug.Log("AudioSourceManager - Sources size: " + sources);

        EventManager<SoundFXEventArgs>.Instance.StartListening(HandleAudioEvent);
    }

    void OnDestroy()
    {
        EventManager<SoundFXEventArgs>.Instance.StopListening(HandleAudioEvent);
    }

    //PLAY SOUNDS
    private void PlaySound()
    {
        foreach(AudioSource aSource in sources)
        {
            if(!aSource.isPlaying)
            {
                aSource.Play();
                break;
            }
        }
    }

    //EVENT HANDLING
    private void HandleAudioEvent(object sender, SoundFXEventArgs e)
    {
        if(audioType == e.EventType)
            PlaySound();
    }
}
