using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider BgmSlider;
    [SerializeField] Slider SFXSlider;

    const string MIXER_MUSIC = "BgmVol";
    const string MIXER_SFX = "SFXVol";

    public float BgmValue;
    public float SFXValue;
    private void Awake()
    {
        BgmSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Update()
    {
        
    }

    void SetMusicVolume(float BgmValue)
    {
        mixer.SetFloat(MIXER_MUSIC, BgmValue);
    }

    void SetSFXVolume(float SFXValue)
    {
        mixer.SetFloat(MIXER_SFX, SFXValue);
    }
}
