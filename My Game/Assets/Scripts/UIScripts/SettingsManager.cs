using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private static readonly string SensitivityPref = "SensitivityPref";
    private int firstPlayInt;

    public static float newSens;

    public Slider musicSlider, soundEffectSlider, sensitivitySlider;
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
            musicFloat = 0.25f;
            soundEffectFloat = 0.5f;
            musicSlider.value = musicFloat;
            soundEffectSlider.value = soundEffectFloat;
            sensitivitySlider.value = CameraMovement.rotationSpeed;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetFloat(SensitivityPref, CameraMovement.rotationSpeed);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

        else
        {
            //Getting Values Of Previously Changed Sliders & Setting Them As Current Values
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;
            CameraMovement.rotationSpeed = PlayerPrefs.GetFloat(SensitivityPref);
            sensitivitySlider.value = CameraMovement.rotationSpeed;

        }


    }


    public void SaveSoundSettings()
    {

        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);
        PlayerPrefs.SetFloat(SensitivityPref, sensitivitySlider.value);

    }

    //If Application Is Existed In An Improper Way It Will Save The Slider Values
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

    public void UpdateSensitivity()
    {

        CameraMovement.rotationSpeed = sensitivitySlider.value;

        newSens = CameraMovement.rotationSpeed;
    }

}
