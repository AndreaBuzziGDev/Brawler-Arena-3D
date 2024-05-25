using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeAdjuster : MonoBehaviour
{
    //ENUM
    //TODO: USE THIS ON VolumeChangeEventArgs FOR EVENT ID TYPES?
    public enum EVolumeType
    {
        MUSIC,
        SOUND_FX,
        VOICE,
        MISC
    }


    //DATA
    [SerializeField] EVolumeType volumeType = EVolumeType.MUSIC;
    [SerializeField] bool pauseAudioOnGamePause = true;

    //TODO: USARE UN REQUIRE? 
    //TODO: MAKE IT AUTOMATIC?
    [SerializeField] List<AudioSource> sources = new();


    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        EventManager<VolumeChangeEventArgs>.Instance.StartListening(HandleVolumeChangeEvent);
        
        SetVolume();
    }

    void Update()
    {
        //TODO: CHANGE IMPLEMENTATION. THIS SHOULD LISTEN TO PAUSE AND UNPAUSE EVENTS INSTEAD!!!
        //NB: THIS HAS BEEN DISABLED TO AVOID BUGS
        if(GameController.Instance.IsPaused)
        {
            foreach(AudioSource aSource in sources)
            {
                if(aSource.isPlaying)
                {
                    aSource.Pause();
                    //USE UnPause() WHEN NEEDING UNPAUSE
                }
            }
        }
    }

    void OnDestroy()
    {
        EventManager<VolumeChangeEventArgs>.Instance.StopListening(HandleVolumeChangeEvent);
    }


    //FUNCTIONALITIES
    private float GetMatchingPref(EVolumeType targetType)
    {
        switch (volumeType)
        {
            //TODO: SUPPORT MORE EVENT TYPES
            case EVolumeType.MUSIC:
                return UtilsPrefs.Options.GetVolumeMusic();
            default:
                return UtilsPrefs.Options.GetVolumeEffects();
        }
    }

    private void SetVolume()
    {
        float value = GetMatchingPref(volumeType);
        foreach(AudioSource aSource in sources)
        {
            aSource.volume = value-1;//TODO: IMPROVE THIS?
        }
    }


    //EVENT HANDLING
    private void HandleVolumeChangeEvent(object sender, VolumeChangeEventArgs e)
    {
        SetVolume();
    }
}
