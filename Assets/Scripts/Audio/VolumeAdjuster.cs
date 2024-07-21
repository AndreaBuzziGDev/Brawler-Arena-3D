using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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


    //TODO: MAKE IT AUTOMATIC?
    /*
    BEEN SUGGESTED TO MAKE IT LIKE THIS:

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Clear the list to avoid duplications
        audioSources.Clear();
        // Get all AudioSource components on this GameObject
        audioSources.AddRange(GetComponents<AudioSource>());
    }
#endif

    */
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
    private float GetMatchingPref(EVolumeType targetType) => UtilsPrefs.Options.GetVolume(targetType);

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
