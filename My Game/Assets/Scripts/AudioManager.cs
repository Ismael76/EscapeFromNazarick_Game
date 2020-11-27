using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;

    public Slider musicSlider, soundEffectSlider;
    private float musicFloat, soundEffectFloat;

    public AudioSource musicAudio;
    public AudioSource[] soundEffectAudio;

    public void Start()
    {

        //On First Playthrough It Will Get Initial Slider Values
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            //Setting All Initial Values Of Sliders On First Playthrough As Well As When The Player Changes Settings First Time etc...
            musicFloat = 1f;
            soundEffectFloat = 1f;
            musicSlider.value = musicFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

        else
        {
            //Getting Values Of Previously Changed Sliders & Setting Them As Current Values
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;

        }


    }

    public void SaveSoundSettings()
    {

        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);

    }

    //If Application Is Existed In An Impropoer Way It Will Save The Slider Values
    public void OnApplicationFocus(bool inFocus)
    {

        if (!inFocus)
        {

            SaveSoundSettings();
        }
    }

    //Linking Slider To Game Audio
    public void UpdateAudio()
    {

        musicAudio.volume = musicSlider.value;

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {

            soundEffectAudio[i].volume = soundEffectSlider.value;
        }

    }
}
