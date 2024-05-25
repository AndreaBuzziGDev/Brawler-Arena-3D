
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//TODO: RENAME AS SOMETHING ELSE - THIS IS DEDICATED TO SHORT AUDIO FX SPECIFICALLY
public class AudioSourceManager : MonoBehaviour
{
    public enum EnumTest
    {
        CORRECT,
        INCORRECT
    }


    //DATA
    [SerializeField] EnumTest volumeType = EnumTest.INCORRECT;

    List<AudioSource> sources = new();


    //LIFECYCLE FUNCTIONS
    void Start()
    {
        sources = FindObjectsOfType<AudioSource>().ToList();
        Debug.Log("Sources size: " + sources);

        //TODO: REGISTER TO EVENTS FROM EVENT MANAGER ABOUT AUDIO
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
    //1) SHOULD CHECK IF THE EVENT IS IN ANY WAY RELEVANT TO THE NOTIFIED ENTITY

}
