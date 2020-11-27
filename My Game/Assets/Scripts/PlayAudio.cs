using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";

    private float musicFloat, soundEffectFloat;

    public AudioSource musicAudio;
    public AudioSource[] soundEffectAudio;

    void Awake()
    {
        ContinueSettings();
    }

    //Continue Settings From Main Menu To Other Scenes
    private void ContinueSettings()
    {

        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);

        musicAudio.volume = musicFloat;

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {

            soundEffectAudio[i].volume = soundEffectFloat;
        }

    }
}
