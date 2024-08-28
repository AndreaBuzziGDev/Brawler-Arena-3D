using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

//NB: THIS SCRIPT (AS WELL AS UI_MainMenu) CAN BE REFACTORED WITH A COMMON PARENT TO ALLOW CONFIGURATION TO BE MUCH MORE ADAPTABLE AND SIMPLIFIED
public class UI_MainOptions : MonoBehaviour
{
    //DATA


    //EVENTS
    public static event EventHandler<VolumeChangeEventArgs> VolumeChanged;


    //GAMEOBJECT REFERENCES
    [SerializeField] Canvas optionsMenuPanel;

    [SerializeField] TMP_Dropdown difficultyDropDown;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider soundFXVolumeSlider;
    [SerializeField] Slider voiceVolumeSlider;
    [SerializeField] Slider miscVolumeSlider;

    
    

    //LIFECYCLE FUNCTIONS
    void Awake()
    {
        //LISTEN EVENTS
        EventManager<MainMenuEventArgs>.Instance.StartListening(HandleMainMenuEvent);
    }

    void OnDestroy()
    {
        //UN-LISTEN EVENTS
        EventManager<MainMenuEventArgs>.Instance.StopListening(HandleMainMenuEvent);
    }
    


    //FUNCTIONALITIES
    private void RefreshView()
    {
        //PRE-LOADING VALUES
        difficultyDropDown.value = UtilsPrefs.GameSettings.GetGameSpeed();

        musicVolumeSlider.value = UtilsPrefs.Options.GetVolume(VolumeAdjuster.EVolumeType.MUSIC);
        soundFXVolumeSlider.value = UtilsPrefs.Options.GetVolume(VolumeAdjuster.EVolumeType.SOUND_FX);
        voiceVolumeSlider.value = UtilsPrefs.Options.GetVolume(VolumeAdjuster.EVolumeType.VOICE);
        miscVolumeSlider.value = UtilsPrefs.Options.GetVolume(VolumeAdjuster.EVolumeType.MISC);
    }


    //UI ELEMENTS
    //DROPDOWN MENUS
    public void HandleDifficultyChange(int newValue) => UtilsPrefs.GameSettings.SetGameSpeed((UtilsPrefs.GameSettings.DIFFICULTY) newValue);


    //SLIDERS
    //TODO: THESE REALLY SHOULD DEBOUNCE.
    public void HandleVolumeMusicChange()
    {
        UtilsPrefs.Options.SetVolume(VolumeAdjuster.EVolumeType.MUSIC, musicVolumeSlider.value);
        EventManager<VolumeChangeEventArgs>.Instance.Notify(this, new VolumeChangeEventArgs());
    }
    public void HandleVolumeSoundFXChange()
    {
        UtilsPrefs.Options.SetVolume(VolumeAdjuster.EVolumeType.SOUND_FX, musicVolumeSlider.value);
        EventManager<VolumeChangeEventArgs>.Instance.Notify(this, new VolumeChangeEventArgs());
    }
    public void HandleVolumeVoiceChange()
    {
        UtilsPrefs.Options.SetVolume(VolumeAdjuster.EVolumeType.VOICE, musicVolumeSlider.value);
        EventManager<VolumeChangeEventArgs>.Instance.Notify(this, new VolumeChangeEventArgs());
    }
    public void HandleVolumeMiscChange()
    {
        UtilsPrefs.Options.SetVolume(VolumeAdjuster.EVolumeType.MISC, musicVolumeSlider.value);
        EventManager<VolumeChangeEventArgs>.Instance.Notify(this, new VolumeChangeEventArgs());
    }


    //BUTTONS
    public void OpenMainMenu() => EventManager<MainMenuEventArgs>.Instance.Notify(this, new MainMenuEventArgs(MainMenuEventArgs.EType.MAIN_MENU));


    //EVENT HANDLING
    public void HandleMainMenuEvent(object sender, MainMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case MainMenuEventArgs.EType.MAIN_OPTIONS:
                optionsMenuPanel.gameObject.SetActive(true);
                RefreshView();
                break;
            default:
                optionsMenuPanel.gameObject.SetActive(false);
                break;
        }
    }
}
