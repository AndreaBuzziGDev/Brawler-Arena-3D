
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AudioSourceManager : MonoBehaviour {
    //DATA
    [SerializeField] SoundSourceType audioType = SoundSourceType.UNBOUND;

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
    private void PlayClip(AudioClipData clipData){
        
        //TODO: TO AVOID SPAMMING THE SAME SOUND, INTRODUCE A LOGIC THAT CONTROLS AUDIO CLIP FLOWS
        //      FOR EXAMPLE, SOME CLIPS MIGHT BE TAGGED SO THAT THEY CAN ONLY BE PLAYED ONCE AT A TIME
        //      OTHER CLIPS MIGHT RE-SET THAT SOUND INSTEAD (WITH A COOLDOWN?)
        //      SOME MAY NEED TO LOOP INSTEAD
        
        //TODO: IMPLEMENT LOGIC BASED ON PLAYBACK MODE
        switch(clipData.PlaybackMode){
            case SoundPlaybackMode.RateLimited:
                PlayRateLimited(clipData);
                break;
            case SoundPlaybackMode.AmountLimited:
                PlayAmountLimited(clipData);
                break;
            case SoundPlaybackMode.UniqueInstance:
                PlayUniqueInstance(clipData);
                break;
            case SoundPlaybackMode.Normal:
            default:
                PlayNormal(clipData);
                break;
        }
    }
    
    
    
    private void PlayNormal(AudioClipData clipData){
        foreach(AudioSource aSource in sources){
            if(!aSource.isPlaying){
                aSource.clip = clipData.Clip;
                aSource.Play();
                break;
            }
        }
    }
    
    private void PlayRateLimited(AudioClipData clipData){
        
        AudioSource playingSource = null;
        foreach(AudioSource aSource in sources){
            if(aSource.isPlaying && aSource.clip == clipData.Clip){
                playingSource = aSource;
                break;
            }
        }
        
        if(playingSource != null && (playingSource.time > clipData.RateLimitTime))
            playingSource.Play();
        else 
            PlayNormal(clipData);
    }
    
    private void PlayAmountLimited(AudioClipData clipData){
        
        int playingSources = 0;
        foreach(AudioSource aSource in sources){
            if(aSource.isPlaying && aSource.clip == clipData.Clip){
                playingSources++;
            }
        }

        if(playingSources < clipData.AmountLimit)
            PlayNormal(clipData);
    }
    
    private void PlayUniqueInstance(AudioClipData clipData){
        //TODO: IMPLEMENT

        
    }
    
    
    
    
    //EVENT HANDLING
    private void HandleAudioEvent(object sender, SoundFXEventArgs e){
        
        if(e.ClipData.Clip != null){
            if(audioType == e.EventType)
                PlayClip(e.ClipData);
        } else {
            Debugger.Log("Received from: " + sender + " a null audio clip.", LogType.SOUND, LogLevel.Debug, LogMode.Warning);
        }
    }
}
