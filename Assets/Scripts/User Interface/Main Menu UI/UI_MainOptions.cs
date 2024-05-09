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

        musicVolumeSlider.value = UtilsPrefs.Options.GetVolumeMusic();
        soundFXVolumeSlider.value = UtilsPrefs.Options.GetVolumeEffects();
    }


    //UI ELEMENTS
    //DROPDOWN MENUS
    public void HandleDifficultyChange(int newValue) => UtilsPrefs.GameSettings.SetGameSpeed((UtilsPrefs.GameSettings.DIFFICULTY) newValue);


    //SLIDERS
    //TODO: THESE REALLY SHOULD DEBOUNCE.
    //TODO: COULD THESE BE UNIFIED? SHOULD THESE HANDLE EVENT TYPES VIA ENUMERATIONS INSTEAD?
    public void HandleVolumeMusicChange()
    {
        UtilsPrefs.Options.SetVolumeMusic(musicVolumeSlider.value);
        EventManager<VolumeChangeEventArgs>.Instance.Notify(this, new VolumeChangeEventArgs());
    }
    public void HandleVolumeSoundFXChange()
    {
        UtilsPrefs.Options.SetVolumeEffects(soundFXVolumeSlider.value);
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
