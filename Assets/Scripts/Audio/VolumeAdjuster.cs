using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeAdjuster : MonoBehaviour
{
    //ENUM
    public enum EVolumeType
    {
        MUSIC,
        SOUND_FX,
        VOICE,
        MISC
    }

    //ENUM DICTIONARY
    public static readonly Dictionary<EVolumeType, string> EVolumeTypeDictionary = new Dictionary<EVolumeType, string>{
        { EVolumeType.MUSIC, SaveController.volumeMusic },
        { EVolumeType.SOUND_FX, SaveController.volumeSoundFX },
        { EVolumeType.VOICE, SaveController.volumeVoice },
        { EVolumeType.MISC, SaveController.volumeMisc }
    };


    //DATA
    [SerializeField] EVolumeType volumeType = EVolumeType.MUSIC;
    [SerializeField] bool pauseAudioOnGamePause = true;


    //INSPECTOR REFERENCES
    [SerializeField] List<AudioSource> sources = new();

    //AUTOMATICAL ASSIGNMENT OF AUDIOSOURCES
#if UNITY_EDITOR
    private void OnValidate()
    {
        // Clear the list to avoid duplications
        sources.Clear();
        // Get all AudioSource components on this GameObject
        sources.AddRange(GetComponents<AudioSource>());
    }
#endif



    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        EventManager<VolumeChangeEventArgs>.Instance.StartListening(HandleVolumeChangeEvent);
        EventManager<GameMenuEventArgs>.Instance.StartListening(HandleGamePauseEvent);
        
        SetVolume();
    }

    void OnDestroy()
    {
        EventManager<VolumeChangeEventArgs>.Instance.StopListening(HandleVolumeChangeEvent);
        EventManager<GameMenuEventArgs>.Instance.StopListening(HandleGamePauseEvent);
    }


    //FUNCTIONALITIES
    private float GetMatchingPref(EVolumeType targetType) => UtilsPrefs.Options.GetVolume(targetType);

    private void SetVolume()
    {
        float value = GetMatchingPref(volumeType);
        foreach(AudioSource aSource in sources)
        {
            aSource.volume = value-1;//TODO: IMPROVE THIS?
        }
    }



    //PAUSE AUDIO HANDLING
    private void PauseAudio()
    {
        if(!pauseAudioOnGamePause)
            return;
        
        foreach(AudioSource aSource in sources)
            if(aSource.isPlaying)
                aSource.Pause();
    }
    private void UnPauseAudio()
    {
        if(!pauseAudioOnGamePause)
            return;
        
        foreach(AudioSource aSource in sources)
            if(!aSource.isPlaying)
                aSource.UnPause();
    }



    //EVENT HANDLING
    private void HandleVolumeChangeEvent(object sender, VolumeChangeEventArgs e)
    {
        SetVolume();
    }

    private void HandleGamePauseEvent(object sender, GameMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_OPEN:
                PauseAudio();
                break;
            case GameMenuEventArgs.EType.GAME_MENU_PAUSE_CLOSE:
                UnPauseAudio();
                break;
            default:
                Debug.Log("Unhandled Pause Event");
                break;
        }

    }
}
