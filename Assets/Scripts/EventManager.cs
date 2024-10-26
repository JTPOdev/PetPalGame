using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameStartManager : MonoBehaviour
{
    public Slider BGMusicSlider;
    public Slider SFXMusicSlider;
    public AudioMixer BGmixer;
    public AudioMixer SFXmixer;
    private float value;

    private void Start()
    {
        // Set initial volumes based on saved preferences
        BGMusicSlider.value = PlayerPrefs.GetFloat("BGvolume", value);
        SFXMusicSlider.value = PlayerPrefs.GetFloat("SFXvolume", value);

        SetBGMusicVolume();
        SetSFXMusicVolume();

        // Play home background audio
        AudioManager.instance.Play("HomeBGaudio");
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

    public void OnPlayButtonPressed()
    {
        if (!PlayerProgress.HasName())
        {
            SceneManager.LoadScene("NameScene");
        }
        else if (string.IsNullOrEmpty(PlayerProgress.GetSelectedEgg()))
        {
            SceneManager.LoadScene("EggSelectionScene");
        }
        else
        {
            string mainScene = PlayerProgress.GetSelectedEgg() == "dog" ? "MainDogScene" : "MainCatScene";
            SceneManager.LoadScene(mainScene);
        }
    }
}
