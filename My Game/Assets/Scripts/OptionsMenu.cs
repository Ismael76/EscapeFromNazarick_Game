using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer; //Reference To The Audio Mixer

    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("Volume", volume); //Sets The Value Of The Audio Mixer To The Value Of The Volume Slider

    }
}
