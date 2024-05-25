
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//TODO: RENAME AS SOMETHING ELSE - THIS IS DEDICATED TO SHORT AUDIO FX SPECIFICALLY
public class AudioSourceManager : MonoBehaviour
{
    //TODO: IMPROVEMENT
    //THIS SHOULD BE DECOUPLED EVEN FURTHER. 
    //THIS SHOULD ACT AS A POOLER OF SORTS FOR AUDIO SOURCES
    //---> THIS MEANS THAT IT SHOULD GRANT UP TO "N" AUDIO FX TO BE PLAYED, NO MATTER WHAT THE CONTENT.
    //EVENT SYSTEM VIA EVENT MANAGER SHOULD PROPAGATE CLIP AND ASSIGN IT AT RUNTIME TO AUDIO SOURCE INSTEAD.
    //THE AUDIO CLIP SHOULD BE STORED IN SOME DATA IN THE SOURCE (EG: IN A SCRIPTABLE OBJECT)


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
