using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsPrefs
{
    public static class Options
    {
        public static float GetVolumeEffects()
        {
            return PlayerPrefs.GetFloat(SaveController.volumeSoundFX) == 0 ? 2 : PlayerPrefs.GetFloat(SaveController.volumeSoundFX);
        }

        //WIP REFACTOR
        public static void SetVolume(VolumeAdjuster.EVolumeType type, float value) => PlayerPrefs.SetFloat(VolumeAdjuster.EVolumeTypeDictionary[type], value);

        public static float GetVolume(VolumeAdjuster.EVolumeType type)
        {
            return PlayerPrefs.GetFloat(VolumeAdjuster.EVolumeTypeDictionary[type]) == 0 ? 2 : PlayerPrefs.GetFloat(VolumeAdjuster.EVolumeTypeDictionary[type]);
        }

    }

    public static class GameSettings
    {
        //ENUMS
        public enum DIFFICULTY
        {
            EASY = 0,
            NORMAL = 1,
            HARD = 2
        }



        //FUNCTIONALITIES
        //DIFFICULTY SETTINGS

        //GAME SPEED
        public static void SetGameSpeed(DIFFICULTY value) => PlayerPrefs.SetInt(SaveController.gameSpeed, (int) value);

        public static int GetGameSpeed() => PlayerPrefs.HasKey(SaveController.gameSpeed) ? PlayerPrefs.GetInt(SaveController.gameSpeed) : (int) DIFFICULTY.EASY;
        
        //GRADUAL GAME DIFFICULTY INCREMENT
        //UNUSED...
        public static void SetDifficultyIncrement(DIFFICULTY value)
        {

        }

    }
}
