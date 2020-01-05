using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer musicmixer; // get AudioMixer called Mixer

    public void SetLevelMusic(float sliderValue)
    {
        musicmixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20); // The music mixer is set to a float value and can be altered on the volume slider
    }
}
