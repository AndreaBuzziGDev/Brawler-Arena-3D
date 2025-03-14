
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AudioSourceManager : MonoBehaviour
{
    //DATA
    [SerializeField] SoundFXEventArgs.EType audioType = SoundFXEventArgs.EType.UNBOUND;

    List<AudioSource> sources = new();


    //LIFECYCLE FUNCTIONS
    void Start(){
        sources = gameObject.GetComponents<AudioSource>().ToList();
        EventManager<SoundFXEventArgs>.Instance.StartListening(HandleAudioEvent);
    }

    void OnDestroy(){
        EventManager<SoundFXEventArgs>.Instance.StopListening(HandleAudioEvent);
    }

    //PLAY SOUNDS
    private void PlayClip(AudioClip aClip){
        
        //TODO: TO AVOID SPAMMING THE SAME SOUND, INTRODUCE A LOGIC THAT CONTROLS AUDIO CLIP FLOWS
        //      FOR EXAMPLE, SOME CLIPS MIGHT BE TAGGED SO THAT THEY CAN ONLY BE PLAYED ONCE AT A TIME
        //      OTHER CLIPS MIGHT RE-SET THAT SOUND INSTEAD (WITH A COOLDOWN?)
        //      SOME MAY NEED TO LOOP INSTEAD
        
        foreach(AudioSource aSource in sources){
            if(!aSource.isPlaying){
                aSource.clip = aClip;
                aSource.Play();
                break;
            }
        }
    }

    //EVENT HANDLING
    private void HandleAudioEvent(object sender, SoundFXEventArgs e){
        if(e.CarriedAudioClip != null){
            if(audioType == e.EventType)
                PlayClip(e.CarriedAudioClip);
        } else {
            Debugger.Log("Received from: " + sender + " a null audio clip.", LogType.SOUND, LogLevel.Debug, LogMode.Warning);
        }
    }
}
