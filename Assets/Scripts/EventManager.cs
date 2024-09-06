using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EventManager : MonoBehaviour
{
    public Slider BGMusicSlider;
    public Slider SFXMusicSlider;
    public AudioMixer BGmixer;
    public AudioMixer SFXmixer;
    private float value;


    // Start is called before the first frame update
    private void Start()
    {
        AudioManager.instance.Play("HomeBGaudio");
        BGMusicSlider.value = PlayerPrefs.GetFloat("BGvolume", value);
        SFXMusicSlider.value = PlayerPrefs.GetFloat("SFXvolume", value);
    }
    public void SetBGMusicVolume()
    {
        BGmixer.SetFloat("BGvolume", BGMusicSlider.value);
        BGmixer.GetFloat("BGvolume", out value);
        PlayerPrefs.SetFloat("BGvolume", value);
    }
    public void SetSFXMusicVolume()
    {
        SFXmixer.SetFloat("SFXvolume", SFXMusicSlider.value);
        SFXmixer.GetFloat("SFXvolume", out value);
        PlayerPrefs.SetFloat("SFXvolume", value);
    }


}
